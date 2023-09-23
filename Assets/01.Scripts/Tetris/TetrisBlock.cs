using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum Tetromino
{
    I,
    O,
    T,
    J,
    L,
    S,
    Z,
}

public class TetrisBlock : MonoBehaviour
{

    public Tetromino tetromino;

    public Vector3 roationPoint;

    public int posX;
    public int posY;

    bool isRotate = false;

    public List<EffectItem> effectItems = new List<EffectItem>();


    public Color color;
    private void Awake()
    {
        for(int i = 0; i < effectItems.Count; i++)
        {
            effectItems[i].SetColor(color);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      

    }

    public void DestoryObject()
    {
        for (int i = 0; i < effectItems.Count; i++)
        {
            effectItems[i].DeleteEffect();
        }
    }

    public void Rotate(bool _islockwise)
    {
        Vector3 _point = transform.TransformPoint(roationPoint);
        if(_islockwise)
        {
            transform.RotateAround(_point, new Vector3(0,0,1), 90);
        }
        else
        {
            transform.RotateAround(_point, new Vector3(0, 0, 1), -90);

        }
    }

    public void InPlaceRotate(bool _islockwise )
    {
        Vector3 _point = transform.TransformPoint(roationPoint);
        isRotate = !isRotate;

        if (_islockwise)
        {
            if (isRotate == true)
            {
                transform.RotateAround(_point, new Vector3(0, 0, 1), 90);
            }
            else
            {
                transform.RotateAround(_point, new Vector3(0, 0, 1), -90);
            }
        }
        else
        {
            if (isRotate == true)
            {
                transform.RotateAround(_point, new Vector3(0, 0, 1), -90);
            }
            else
            {
                transform.RotateAround(_point, new Vector3(0, 0, 1), 90);
            }
        }
    }

    public void Movement(Vector3 _voc)
    {
        transform.position += _voc;
    }

  
}