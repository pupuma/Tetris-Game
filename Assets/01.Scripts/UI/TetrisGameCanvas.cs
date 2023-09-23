using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisGameCanvas : MonoBehaviour
{


    public HoldBlockPanel holdBlockPanel;
    public BlockPoolPanel blockPoolPanel;
    public LevelPanel levelPanel;
    public ScorePanel scorePanel;

    public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init()
    {
        blockPoolPanel.Init();
    }
}
