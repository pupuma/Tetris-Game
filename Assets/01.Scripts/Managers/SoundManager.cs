using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{

    public AudioSource audioSource;
    public AudioSource oneShotEffect;
    public AudioClip gameOverClip;
    public AudioClip deleteEffect;

    bool isBGM = false;

    private void Awake()
    {
        this.InitSingleton(this);
    }
    // Start is called before the first frame update
    void Start()
    {
         audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F12))
        {
            isBGM = !isBGM;

            if(isBGM )
            {
                //audioSource.Play();
            }
            else
            {
                //audioSource.Stop();
            }
        }
    }

    public void GameOverEffect()
    {
        audioSource.Stop();
        oneShotEffect.PlayOneShot(gameOverClip);
    }

    public void DeleteEffect()
    {
        oneShotEffect.PlayOneShot(deleteEffect);
    }
}
