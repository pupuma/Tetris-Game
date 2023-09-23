using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Grid 
{
    public  int gridIndex = 0;

    public TileCell tileCell;
    public Transform blockTrans;

    public bool isFull = false;

    // Start is called before the first frame update
    void Start()
    {

    }


    public void Setting(int _index)
    {

    }

    public void Setting(int _index, int _x, int _y)
    {
        gridIndex = _index; 

        tileCell = new TileCell();

        tileCell.cellX = _x;
        tileCell.cellY = _y;
        isFull = false;
    }

    
    public void AddTo(Transform _trans)
    {
        blockTrans = _trans;

        isFull = true;
    }

}
