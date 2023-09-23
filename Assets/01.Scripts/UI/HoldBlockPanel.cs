using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HoldBlockPanel : MonoBehaviour
{
    public Image holdBlockImage;

    public bool isHold = false;
    public eTetrominoType holdType;
    private void Awake()
    {
        holdBlockImage.color = new Color(0, 0, 0, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SettingHold(int  _type)
    {
        isHold = true;
        holdType = (eTetrominoType)_type;
        GameSystem.Instance.ChangeBlockImage((eTetrominoType)_type, holdBlockImage);
    }

    public void ClearData()
    {
        holdBlockImage.color = new Color(0, 0, 0, 0);
    }
    public bool IsHold()
    {
        return isHold;
    }
}
