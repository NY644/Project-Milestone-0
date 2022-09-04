using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITitleScreen : MonoBehaviour
{
    public AudioSource speaker;
    public AudioClip ButtonClicked;

    public void ActivateMainMenu()
    {
        if (GameManager.instance != null)
        {
            speaker.PlayOneShot(ButtonClicked);
            GameManager.instance.ActivateMainMenuState();
        }
    }

    public void PlaySound()
    {
        speaker.PlayOneShot(ButtonClicked);
    }
}
