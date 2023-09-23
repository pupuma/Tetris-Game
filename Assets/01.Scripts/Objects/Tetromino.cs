using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;
public enum eTetrominoType
{
    I,
    O,
    T,
    J,
    L,
    S,
    Z,
}


[System.Serializable]
public struct TetrominoData
{

    public eTetrominoType type;

    public Tile tile;
    public Vector2Int[] cells { get; private set; }

    public void Initialize()
    {
        this.cells = Data.Cells[this.type];
    }



}
