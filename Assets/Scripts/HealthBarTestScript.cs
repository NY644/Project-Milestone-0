using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarTestScript : Health
{
    public Text textbox;
    public Image healthImage;
    public float testCurrentHealth;
    public float testMaxHealth;
    public Dropdown myDropdown;

   

    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = currentHealth / maxHealth;
        textbox.text = "(" + currentHealth + "%)";
    }
}
