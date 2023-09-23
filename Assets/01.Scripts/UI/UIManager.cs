using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    public List<Sprite> blockSprites = new List<Sprite>();

    public TetrisGameCanvas tetrisGameCanvas;

    private void Awake()
    {
        InitSingleton(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
