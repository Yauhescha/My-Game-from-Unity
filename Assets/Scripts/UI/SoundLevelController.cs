using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundLevelController : MonoBehaviour
{

    private Slider slider;
    public void SoundValueChanged() {

        PlayerPrefs.SetFloat("SoundValue", slider.value);
    }
    void Start()
    {
        slider = GetComponent<Slider>();
        if (!PlayerPrefs.HasKey("SoundValue"))
            slider.value = 100;
        else 
            slider.value = PlayerPrefs.GetFloat("SoundValue");
    }
}
