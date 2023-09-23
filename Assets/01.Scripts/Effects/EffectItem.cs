using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectItem : MonoBehaviour
{
    public ParticleSystem particle;

    public Action deleteAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Color GetColorMin()
    {
        return particle.main.startColor.colorMin;
    }

    public void SetColor(Color _color)
    {
        var main = particle.main.startColor;
        main.color = _color;
        deleteAction += DeleteObject;
    }

    public void DeleteObject()
    {
        GameObject.Destroy(gameObject, 0.1f); 
    }
    

    public void DeleteEffect()
    {
        StartCoroutine(_DeleteEffect());
    }

    IEnumerator _DeleteEffect()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        particle.Play();

        while(particle.isPlaying == true)
        {
            yield return null;
        }

        deleteAction?.Invoke();

    }

}
