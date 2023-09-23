using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    // ���ϴ� ����:���� ���� (4:3�� ��� 4, 3)
    public int targetWidth = 4;
    public int targetHeight = 3;

    void Start()
    {
        // ���ϴ� ����:���� ������ �����ϸ鼭 ȭ�� �ػ� ����
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