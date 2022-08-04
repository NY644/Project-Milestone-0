using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarTestScript : MonoBehaviour
{
    public Text textbox;
    public Image healthImage;
    public float testCurrentHealth;
    public float testMaxHealth;
    public Dropdown myDropdown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = testCurrentHealth / testMaxHealth;
        textbox.text = "(" + testCurrentHealth + "%)";
    }
}
