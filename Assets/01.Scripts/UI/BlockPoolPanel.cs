using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BlockPoolPanel : MonoBehaviour
{
    public Image firstBlockImage;
    public Image secondBlockimage;
    public Image thirdBlockimage;


    public eTetrominoType firstTetromino;
    public eTetrominoType secondTetromino;
    public eTetrominoType thirdTetromino;


    private void Awake()
    {
        firstBlockImage.color=  new Color (0,0,0,0);
        secondBlockimage.color = new Color(0, 0, 0, 0);
        thirdBlockimage.color = new Color(0, 0, 0, 0);

    }
    // Start is called before the first frame update
    void Start()
    {

    }


    public void Init()
    {
        BlockPool blockPool = GameManager.Instance.blockPool;

        List<eTetrominoType> poolList  = blockPool.tetrominoPoolList;

        firstTetromino  = poolList[0];
        GameSystem.Instance.ChangeBlockImage(firstTetromino , firstBlockImage);
        secondTetromino = poolList[1];
        GameSystem.Instance.ChangeBlockImage(secondTetromino, secondBlockimage);

        thirdTetromino = poolList[2];
        GameSystem.Instance.ChangeBlockImage(thirdTetromino, thirdBlockimage);
    }


    public void SettingPool(List<eTetrominoType> _poolList)
    {
        firstTetromino = _poolList[0];
        GameSystem.Instance.ChangeBlockImage(firstTetromino, firstBlockImage);
        secondTetromino = _poolList[1];
        GameSystem.Instance.ChangeBlockImage(secondTetromino, secondBlockimage);

        thirdTetromino = _poolList[2];
        GameSystem.Instance.ChangeBlockImage(thirdTetromino, thirdBlockimage);
    }
}
