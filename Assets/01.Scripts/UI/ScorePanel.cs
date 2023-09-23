using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AppendScore(int _score)
    {
        scoreText.text = _score.ToString(); 
    }
    public void Clear()
    {
        scoreText.text = "";
    }
    // Update is called once per frame
    
}
