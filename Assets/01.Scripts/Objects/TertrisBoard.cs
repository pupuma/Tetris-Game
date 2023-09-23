using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class TertrisBoard : MonoBehaviour
{
    //public List<Grid> gridList = new List<Grid>();
    public List<TIleLine> tileLineList = new List<TIleLine>();

    public int width = 10;
    public int height = 20;

    public bool isReset = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ResetData()
    {
        for (int j = 0; j < tileLineList.Count; j++)
        {
            for(int i = 0; i < tileLineList[j].gridList.Count; i++)
            {
                Grid _grid = tileLineList[j].gridList[i];
                _grid.isFull = false;

                if(_grid.blockTrans != null)
                {
                    _grid.blockTrans.gameObject.GetComponent<EffectItem>().DeleteEffect();
                }

                _grid.blockTrans = null;
            }
        }

        isReset = true;
    }

    public void CreateBoard()
    {
        int maxCount = width * height;

        tileLineList.Clear();

        for(int j = 0; j  < height; j++)
        {
            TIleLine line = new TIleLine();

            int _index = j;
            line.index = _index;

            line.Setting(width);
            tileLineList.Add(line);

        }




        //for(int j = 0; j < height; j++)
        //{
        //    for(int i = 0; i < width; i++)
        //    {
        //        Grid grid = new Grid();
        //        int index = (j * width) + i;
        //        //int posX = (j * height) + i;
        //        //int posY = j;

        //        int posX = i;
        //        int posY = j;

        //        grid.Setting(index, posX, posY);
        //        gridList.Add(grid);
        //    }
        //}

        //for (int i = 0; i < maxCount; i++) 
        //{
        //    Grid grid = new Grid();

        //    int index = i;

        //    int posX = (index * height) + index;
        //    int posY = index / width;

        //    grid.Setting(index, posX, posY);

        //    gridList.Add(grid);
        //}
    }

    public void AddToGrid(int _roundedX, int _roundedY, Transform _trans)
    {
        tileLineList[_roundedY].AddToGrid(_roundedX, _trans);
    }

    public Grid GetGrid(int x, int y)
    {
        if(y >= tileLineList.Count || y < 0)
        {
            //Debug.LogError("Y" + y);

            return null;
        }
        else
        {
            if (x >= tileLineList[y].gridList.Count || x < 0)
            {
                //Debug.LogError("X" + x);
                return null;

            }

        }





        Grid grid = tileLineList[y].gridList[x];
        
        if(grid == null)
        {
            //Debug.Log("int X : " + x + " / " + "int Y " + y);

            return null;
        }
        return tileLineList[y].gridList[x];
    }


    /// <summary>
    /// 라인이 채워졌는지 확인 
    /// </summary>
    /// <param name="_index"></param>
    /// <returns></returns>
    public bool HasLine(int _index)
    {
        for(int i = 0; i < width; i++)
        {
            if(tileLineList[_index].gridList[i].isFull == false )
            {
                return false;
            }
        }

        return true;
    }



    public void DeleteLine(int _index)
    {
        for (int i = 0; i < width; i++)
        {
            Grid _grid = GetGrid(i, _index);

            if(_grid != null ) 
            {
                Debug.Log("DeleteLine!!" );
                _grid.isFull = false;

                if(_grid.blockTrans.gameObject != null)
                {
                    _grid.blockTrans.gameObject.GetComponent<EffectItem>().DeleteEffect();
                }
                ///GameObject.Destroy(_grid.blockTrans.gameObject);
                _grid.blockTrans = null;
            }
        }
    }


    /// <summary>
    /// _index에 있는 위치부터, 위에 있는 라인을 전부 내린다.
    /// </summary>
    /// <param name="_index"></param>
    public void RowDown(int _index)
    {
        for (int y = _index; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Grid currentGrid = GetGrid(x, y);
                Grid downGrid = GetGrid(x, y-1);

                if (currentGrid != null)
                {
                    // 현재 그리드에 블록이 있으면
                    if (downGrid != null && !downGrid.isFull)
                    {
                        // 아래 그리드에 블록이 있고 아래 그리드가 비어있지 않으면
                        downGrid.blockTrans = currentGrid.blockTrans;
                        downGrid.isFull = currentGrid.isFull;
                        currentGrid.blockTrans = null;
                        currentGrid.isFull = false;
                        if (downGrid.blockTrans != null)
                        {
                            downGrid.blockTrans.position -= new Vector3(0, 1, 0);
                        }
                    }
                    else
                    {
                        // 아래 그리드가 없거나 아래 그리드가 이미 채워져 있으면 현재 그리드를 비움
                        currentGrid.blockTrans = null;
                        currentGrid.isFull = false;
                    }
                }


                //if(currentGrid != null)
                //{
                //    if(downGrid != null)
                //    {
                //        downGrid.blockTrans = currentGrid.blockTrans;
                //        downGrid.isFull = currentGrid.isFull;
                //        if (downGrid.blockTrans != null)
                //        {
                //            downGrid.blockTrans.position -= new Vector3(0, 1, 0);
                //        }
                //    }

                //}
            }
        }
    }


    public bool IsFullGrid(int x , int y )
    {

        Grid grid = GetGrid(x, y);

        if (grid != null)
        {
             return grid.isFull;
        }


        return false;
        //if (grid == null)
        //{
        //    isFullGrid = false;
        //}
        //else
        //{
        //    if ( gridList[_index].isFull == false)
        //    {
        //        isFullGrid = false;
        //    }
        //}

        //return isFullGrid;
    }

}
