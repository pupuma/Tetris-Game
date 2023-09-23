using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class LevelPanel : MonoBehaviour
{
    public TMP_Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Clear()
    {
        levelText.text = "LEVEL 1";
    }

    public void AppendLevel(int _level)
    {
        string levelHeader = "LEVEL ";

        levelText .text = levelHeader + _level;
    }
}
