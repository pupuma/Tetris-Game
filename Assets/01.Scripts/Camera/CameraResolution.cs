using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    // 원하는 가로:세로 비율 (4:3의 경우 4, 3)
    public int targetWidth = 4;
    public int targetHeight = 3;

    void Start()
    {
        // 원하는 가로:세로 비율을 유지하면서 화면 해상도 설정
        SetResolutionWithAspectRatio(targetWidth, targetHeight);
    }

    void SetResolutionWithAspectRatio(int width, int height)
    {
        Resolution[] resolutions = Screen.resolutions;
        foreach (Resolution resolution in resolutions)
        {
            if (resolution.width / (float)resolution.height == width / (float)height)
            {
                Screen.SetResolution(resolution.width, resolution.height, true);
                break;
            }
        }
    }

}