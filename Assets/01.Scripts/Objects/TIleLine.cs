using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class TIleLine
{

    public List<Grid> gridList = new List<Grid>();

    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Setting(int width)
    {
        for (int i = 0; i < width; i++)
        {
            Grid grid = new Grid();
            int gridIndex = i;

            grid.gridIndex = gridIndex;
            grid.Setting(gridIndex, i, index);
            
            gridList.Add(grid);
        }
    }


    public void AddToGrid(int _roundX , Transform _trans)
    {
        gridList[_roundX].isFull = true;
        gridList[_roundX].blockTrans = _trans;
    }


    public void AddToGrid()
    {

    }
}
