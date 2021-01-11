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
    [SerializeField]
    private int secondEasy;
  


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            int scenesCount = SceneManager.GetAllScenes().Length;
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            Debug.Log("scenesCount  "+ scenesCount);
            Debug.Log("currentScene "+ currentScene);

            PlayerPrefs.SetString("LVL_"+(currentScene), "true");
            if(scenesCount> currentScene)
                SceneManager.LoadScene(currentScene + 1);
            else 
                SceneManager.LoadScene(0);
        }
    }
}
