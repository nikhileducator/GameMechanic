using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            if(backgroundMusic.isPlaying)
            {
                backgroundMusic.Stop();
            }
            else
            {
                backgroundMusic.Play();
            }
        }

        //Pressing P will increase volume and pressing L will decrease volume
        if(Input.GetKeyDown(KeyCode.P))
        {
            backgroundMusic.volume += 0.1f;
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            backgroundMusic.volume -= 0.1f;
        }
    }
}
