using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;



public class UIOptionsScreen : MonoBehaviour
{
    public AudioMixer mainAudioMixer;
    // public Slider mainVolumeSlider;

    

    // Start is called before the first frame update
    void Start()
    {
        OnMainVolumeChange();
    }

     void Update()
    {
        AudioMixer.SetFloat("Master", 20.0f); // Set the volume to 20db
    }

    public void OnMainVolumeChange()
    {
        // Start with the slider value (assuming our slider runs from 0 to 1)
        float newVolume = mainVolumeSlider.value;
        if (newVolume <= 0)
        {
            // If we are at zero, set our volume to the lowest value
            newVolume = -80;
        }
        else
        {
            // We are >0, so start by finding the log10 value 
            newVolume = Mathf.Log10(newVolume);
            // Make it in the 0-20db range (instead of 0-1 db)
            newVolume = newVolume * 20;
        }

        // Set the volume to the new volume setting
        mainAudioMixer.SetFloat("MainVolume", newVolume);
    }

}
