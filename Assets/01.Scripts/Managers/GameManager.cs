using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public BlockController blockController;
    public TetrisBlockSpawner blockSpawner;
    public BlockPool blockPool; 
    public TertrisBoard tertrisBoard;
    private void Awake()
    {
        InitSingleton(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
