using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
  

    [SerializeField]
    private int secondHard;
    [SerializeField]
    private int secondNormal;
  


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            int scenesCount = SceneManager.sceneCountInBuildSettings;
            int currentScene = SceneManager.GetActiveScene().buildIndex;

            PlayerPrefs.SetInt("LVL_"+(currentScene), getScore());
            if(scenesCount-1> currentScene)
                SceneManager.LoadScene(currentScene + 1);
            else 
                SceneManager.LoadScene(0);
        }
    }
    private int getScore() {
        float time = GameObject.FindObjectOfType<TimerController>().Timer;
        if (time <= secondHard) return 3;
        else if (time <= secondNormal) return 2;
        else return 1;
        
    }
}
