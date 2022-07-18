using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{



    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.instance.ActivateMainMenuState();
        }

     if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.instance.ActivateMainMenuState();
        }


    }
}
