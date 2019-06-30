using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip gunShot;
    public AudioClip shotHit;
    public AudioClip playerExpolosion;

    private AudioSource audioScr;

    // Start is called before the first frame update
    void Start()
    {
        audioScr = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound(string clip) {
        switch(clip) {
            case "gunShot":
            audioScr.PlayOneShot(gunShot);
            break;

            case "shotHit":
            audioScr.PlayOneShot(shotHit);
            break;

            case "playerExplosion":
            audioScr.PlayOneShot(playerExpolosion);
            break;
        }
    }
}
