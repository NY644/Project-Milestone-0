using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    public void ContinueButton()
    {
        GameManager.instance.ActivateMainMenuState();
    }
}
