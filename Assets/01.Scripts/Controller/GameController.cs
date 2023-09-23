using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 컨트롤 
/// </summary>
public class GameController : MonoBehaviour
{
    Action OnGamePlayHandler;
    Action OnHoldBlockHandler;

    // Start is called before the first frame update
    void Start()
    {
        BindInit();    
    }

    void BindInit()
    {
        OnGamePlayHandler += GameSystem.Instance.GamePlayMode;
        OnHoldBlockHandler += GameSystem.Instance.HoldBlock;
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 시작 하는 버튼 

        if(Input.GetKeyDown(KeyCode.F12))
        {
            OnGamePlayHandler?.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            OnHoldBlockHandler?.Invoke();
        }


    }


}
