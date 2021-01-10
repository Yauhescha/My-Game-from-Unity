using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour {

    private AudioSource audio;

	void Start () {
        GameObject music = GameObject.FindWithTag("BackgroundMusic");
        if (music != null)
        {
            Destroy(this.gameObject);
        }
        else {
            this.gameObject.tag = "BackgroundMusic";
            DontDestroyOnLoad(transform.gameObject);
        }
        audio = GetComponentInChildren<AudioSource>();
        if (!PlayerPrefs.HasKey("SoundValue"))
            PlayerPrefs.SetFloat("SoundValue", 100f);
        audio.volume = PlayerPrefs.GetFloat("SoundValue");

    }
    private void FixedUpdate()
    {
        if(audio.volume!= PlayerPrefs.GetFloat("SoundValue"))
            audio.volume = PlayerPrefs.GetFloat("SoundValue");
    }

}
