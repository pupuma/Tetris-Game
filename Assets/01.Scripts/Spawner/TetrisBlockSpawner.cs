using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlockSpawner : MonoBehaviour
{
    public List<TetrisBlock> tetrisBlocks = new List<TetrisBlock>();

    public Transform startTrans;

    BlockController blockController = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.F1))
        //{
        //    InstantiateBlock();
        //    //GameObject.Instantiate()
        //}
    }

    public void InstantiateBlock(int _index)
    {
        TetrisBlock block = GameObject.Instantiate(tetrisBlocks[_index], startTrans.position, startTrans.rotation);


        if (blockController == null)
        {
            blockController = GameManager.Instance.blockController;
        }

        blockController.ControllTarget(block);
        GameSystem.Instance.AddBlock(block.gameObject);
    }

    public void InstantiateBlock()
    {

        int randIndex = Random.Range(0, 7);

        TetrisBlock block = GameObject.Instantiate(tetrisBlocks[randIndex], startTrans.position, startTrans.rotation);


        if (blockController == null)
        {
            blockController = GameManager.Instance.blockController;
        }

        blockController.ControllTarget(block);
        GameSystem.Instance.AddBlock(block.gameObject);


    }

}
