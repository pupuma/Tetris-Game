using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    //public TetrisBlock holdBlock;

    public TetrisBlock currentBlock;

    float previousTime;
    public float fallTime = 0.8f;

    public int width;
    public int height;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentBlock != null )
        {
            BlockUpdate(currentBlock.tetromino);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_tetromino"></param>
    void BlockUpdate(Tetromino _tetromino)
    {
        BlockRotation(_tetromino);
        BlockUpdate();
    }


    void BlockRotation(Tetromino _tetromino)
    {
        if(_tetromino == Tetromino.O)
        {
            return;
        }

        bool isInPlace = false;
        switch (_tetromino)
        {
            case Tetromino.I:
                isInPlace = true;
                break;
            case Tetromino.S:
                isInPlace = true;
                break;
            case Tetromino.Z:
                isInPlace = true;
                break;
            default:
                isInPlace = false;
                break;
        }

        if(isInPlace == true)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                currentBlock.InPlaceRotate(false);
                if (!GameSystem.Instance.VaildMove(currentBlock.transform))
                {
                    currentBlock.InPlaceRotate(true);
                }
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                currentBlock.InPlaceRotate(true);
                if (!GameSystem.Instance.VaildMove(currentBlock.transform))
                {
                    currentBlock.InPlaceRotate(false);

                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                currentBlock.Rotate(false);
                if (!GameSystem.Instance.VaildMove(currentBlock.transform))
                {
                    currentBlock.Rotate(true);
                }
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                currentBlock.Rotate(true);
                if (!GameSystem.Instance.VaildMove(currentBlock.transform))
                {
                    currentBlock.Rotate(false);

                }
            }
        }

        
    }


    void BlockUpdate()
    {
     

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentBlock.Movement(new Vector3(-1, 0, 0));
            if(!GameSystem.Instance.VaildMove(currentBlock.transform))
            {
                currentBlock.Movement(new Vector3(1, 0, 0));
            }
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentBlock.Movement(new Vector3(1, 0, 0));

            if (!GameSystem.Instance.VaildMove(currentBlock.transform))
            {
                currentBlock.Movement(new Vector3(-1, 0, 0));
            }
        }
        else if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime * 0.1 : fallTime))
        {
            currentBlock.Movement(new Vector3(0, -1, 0));

            if(!GameSystem.Instance.VaildMove(currentBlock.transform))
            {
                currentBlock.Movement(new Vector3(0, 1, 0));

                if (GameSystem.Instance.CheckGameOver(currentBlock.transform))
                {
                    Debug.Log("GmaeOver!!");
                    currentBlock.DestoryObject();

                    currentBlock = null;
                    //GameSystem.Instance.score = 0;
                    GameSystem.Instance.GameOver();
                }
                else
                {
                    GameSystem.Instance.AddToGrid(currentBlock.transform);
                    GameSystem.Instance.CheckForLines();
                    GameSystem.Instance.SpawnBlock();
                }

            }
            previousTime = Time.time;
        }
    }

    public void ControllTarget(TetrisBlock _block)
    {
        currentBlock = _block;
    }

    public void DeleteBlock()
    {
        if(currentBlock != null)
        {
                
            GameObject.Destroy(currentBlock.gameObject); ;
            currentBlock = null;
        }
    }
}
