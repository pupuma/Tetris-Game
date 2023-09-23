using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class GameSystem : SingletonMonoBehaviour<GameSystem>
{

    TetrisBlockSpawner blockSpawner = null;
    TertrisBoard tertrisBoard = null;
    BlockPool blockPool = null;
    TetrisGameCanvas tetrisGameCanvas = null;

    BlockController blockController = null;
    int width = 10;
    int height = 20;

    bool isHold = false;

    float timeScale;
    public bool isGameMode = false;
    public bool isGameOver = false;

    public int score = 0;
    private void Awake()
    {
        InitSingleton(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        Clear();
        Init();
    }

    public void Clear()
    {
        blockSpawner = null;
        tertrisBoard = null;
        blockPool = null;
        tetrisGameCanvas = null;
        blockController = null;
    }

    private void Init()
    {

        timeScale = Time.timeScale;
        if (blockSpawner == null)
        {
            blockSpawner = GameManager.Instance.blockSpawner;
        }

        if (tertrisBoard == null)
        {
            tertrisBoard = GameManager.Instance.tertrisBoard;

            tertrisBoard.width = width;
            tertrisBoard.height = height;

            tertrisBoard.CreateBoard();
        }

        // 
        if (blockPool == null)
        {
            blockPool = GameManager.Instance.blockPool;


            blockPool.Init();
        }

        if (tetrisGameCanvas == null)
        {
            tetrisGameCanvas = UIManager.Instance.tetrisGameCanvas;
            tetrisGameCanvas.Init();

        }

        if(blockController == null)
        {
            blockController = GameManager.Instance.blockController; 

        }


    }


    /// <summary>
    /// 블럭을 생성한다.
    /// </summary>
    public void SpawnBlock()
    {
        isHold = false;
        blockPool.CreateBlock();

        score += 10;
        

        if(score % 100 == 0)
        {
            int level = (score / 100) + 1;
            tetrisGameCanvas.levelPanel.AppendLevel(level);
        }
        
        tetrisGameCanvas.scorePanel.AppendScore(score);

        //blockSpawner.InstantiateBlock();
    }


    public void AddToGrid(Transform _block)
    {
        foreach (Transform child in _block.transform)
        {
            int roundedX = Mathf.RoundToInt(child.transform.position.x);
            int roundedY = Mathf.RoundToInt(child.transform.position.y);

            tertrisBoard.AddToGrid(roundedX, roundedY, child);
        }
    }

    /// <summary>
    ///  움직일 수 있는 공간인지 확인..
    /// </summary>
    /// <param name="_block"></param>
    /// <returns></returns>
    public bool VaildMove(Transform _block)
    {
        foreach (Transform child in _block.transform)
        {
            int roundedX = Mathf.RoundToInt(child.transform.position.x);
            int roundedY = Mathf.RoundToInt(child.transform.position.y);

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height + 2)
            {
                return false;
            }


            // 현재 채워진 곳이라면.. 
            if (tertrisBoard.IsFullGrid(roundedX, roundedY))
            {
                return false;
            }
        }

        return true;
    }


    public void CheckForLines()
    {
        // 위에서 부터 하나씩 지운다. 

        for (int i = height - 1; i >= 0; i--)
        {
            // 라인 상태 확인 
            if (tertrisBoard.HasLine(i))
            {
                Debug.Log("HasLine!!");
                tertrisBoard.DeleteLine(i);
                tertrisBoard.RowDown(i);
                SoundManager.Instance.DeleteEffect();
            }
        }
    }

    #region Image 

    public void ChangeBlockImage(eTetrominoType _type, Image _image)
    {

        Sprite _sprite = UIManager.Instance.blockSprites[(int)_type];

        _image.sprite = _sprite;

        _image.color = new Color(1, 1, 1, 1);
    }


    #endregion


    #region Event

    /// <summary>
    /// 누를 때마다 게임이 시작 또는 일시정지
    /// 
    /// 
    /// </summary>
    public void GamePlayMode()
    {
        isGameMode = !isGameMode;

        // 게임 모드 일경우..
        if (isGameMode == true)
        {
            // 게임을 죽었을 경우, 처음 시작일경우..
            if(isGameOver == true)
            {
                ReStartGame();
            }
            else
            {
                StartGame();
            }
        }
        else
        {
            StopGame();
        }

    }



    #endregion
    void ReStartGame()
    {
        Time.timeScale = timeScale;

        isGameOver = false;
        UIManager.Instance.tetrisGameCanvas.pausePanel.gameObject.SetActive(false);



        StartCoroutine(_RestartGame());
    }

    IEnumerator _RestartGame()
    {
        bool isLoop = true;

        tertrisBoard.ResetData();



        while(isLoop)
        {
            if (tertrisBoard.isReset == true)
            {
                isLoop = false;
            }
            yield return null;
        }
        tertrisBoard.isReset = false;

        yield return new WaitForSeconds(1.0f);

        blockPool.DeleteAllBlock();
        isHold = false;
        tetrisGameCanvas.holdBlockPanel.isHold = false;
        tetrisGameCanvas.holdBlockPanel.ClearData();


        blockPool.CreateBlock();
        SoundManager.Instance.audioSource.Play();
    }


    void StartGame()
    {
        Time.timeScale = timeScale;

        UIManager.Instance.tetrisGameCanvas.pausePanel.gameObject.SetActive(false);
        SoundManager.Instance.audioSource.Play();
    }

    void StopGame()
    {
        Time.timeScale = 0.0f;
        SoundManager.Instance.audioSource.Pause();
        UIManager.Instance.tetrisGameCanvas.pausePanel.gameObject.SetActive(true);
    }


    public void HoldBlock()
    {
        if (isHold == false)
        {
            isHold = true;
            if(blockController.currentBlock != null )
            {
                TetrisBlock block = blockController.currentBlock;

                Tetromino terominoType = block.tetromino;

                //tetrisGameCanvas = UIManager.Instance.tetrisGameCanvas;

                HoldBlockPanel holdBlockPanel =tetrisGameCanvas.holdBlockPanel;

                // 블럭을 지우고...
                blockController.DeleteBlock();


                if (holdBlockPanel.IsHold() == true)
                {
                    eTetrominoType prevTrimo = holdBlockPanel.holdType;

                    blockPool.CreateBlock(prevTrimo);
                }
                else
                {
                    blockPool.CreateBlock();
                }

                holdBlockPanel.SettingHold((int)terominoType);
            }
         
            //blockPool.CreateBlock();
        }
    }


    public bool CheckGameOver(Transform _block)
    {
        foreach (Transform child in _block.transform)
        {
            int roundedY = Mathf.RoundToInt(child.transform.position.y);

            if (roundedY >= height)
            {
                return true;
            }
        }

        return false;
    }

    public void AddBlock(GameObject _obj)
    {
        blockPool.AddBlockPool(_obj);
    }
    

    public void GameOver()
    {
        score = 0;
        isGameOver = true;
        isGameMode = false;
        tetrisGameCanvas.scorePanel.Clear();
        tetrisGameCanvas.levelPanel.Clear();
        

        SoundManager.Instance.GameOverEffect();
    }

}
