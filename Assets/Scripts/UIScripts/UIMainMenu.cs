using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    public void StartButton()
    {
        GameManager.instance.ActivateGameplayState();
    }

    public void OptionsButton()
    {
        GameManager.instance.ActivateOptionsScreenState();
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
