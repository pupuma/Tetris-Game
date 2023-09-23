using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPool : MonoBehaviour
{
    public List<eTetrominoType> tetrominoPoolList = new List<eTetrominoType>();


    public TetrisBlockSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public void Init()
    {
        for(int i = 0; i < 3; i++) 
        {
            int _valueIndex  = Random.Range(0, 6);

            tetrominoPoolList[i] = (eTetrominoType)_valueIndex;
        }
    }

    public void CreateBlock(eTetrominoType _type)
    {
        spawner.InstantiateBlock((int)_type);
    }

    public void CreateBlock()
    {
        int _index = (int)tetrominoPoolList[0];
        spawner.InstantiateBlock(_index);
        SettingPool();
    }

    void SettingPool()
    {
        tetrominoPoolList[0] = tetrominoPoolList[1];
        tetrominoPoolList[1] = tetrominoPoolList[2];
        int _valueIndex = Random.Range(0, 6);
        tetrominoPoolList[2] = (eTetrominoType)_valueIndex;

        TetrisGameCanvas _tetrisGameCanvas = UIManager.Instance.tetrisGameCanvas;

        _tetrisGameCanvas.blockPoolPanel.SettingPool(tetrominoPoolList);
    }


    Queue<GameObject> blockPool = new Queue<GameObject>();
    public void AddBlockPool(GameObject _obj)
    {
        blockPool.Enqueue(_obj);
    }

    public void DeleteAllBlock()
    {
        while(blockPool.Count > 0 )
        {
            GameObject.Destroy(blockPool.Dequeue());
        }
    }

}
