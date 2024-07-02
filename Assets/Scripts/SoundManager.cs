using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource ballSFX, pinSFX, uiSFX;

    [SerializeField] private AudioClip ballThrow, ballRolling, spare, strike, pinCollision;
    

    //Swicth-case statement
    public void PlaySound(string soundClip)
    {
        switch(soundClip)
        {
            case "throw":
                ballSFX.PlayOneShot(ballThrow);
                break;
            case "roll":
                ballSFX.loop = true;
                ballSFX.clip = ballRolling;
                ballSFX.Play();
                break;
            case "collide":
                ballSFX.loop = false;
                ballSFX.Stop();
                pinSFX.PlayOneShot(pinCollision);
                break;
            case "strike":
                uiSFX.PlayOneShot(strike);
                break;
            case "spare":
                uiSFX.PlayOneShot(spare);
                break;
        }
    }
}
