using System;
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

            GameUIController uiController = GameObject.FindObjectOfType<GameUIController>();
            uiController.FinishedLevelPanel_setActiveMenuFinishedLevelPanel();
            uiController.FinishedLevelPanel_setFinishedTime(String.Format("{0:0.0}", TimerController.Timer));
            uiController.FinishedLevelPanel_setNormalAndHardTime(secondNormal.ToString(), secondHard.ToString());
            uiController.FinishedLevelPanel_setScoreSprites(getScore());

            PlayerPrefs.SetInt("LVL_" + GameUIController.currentScene, getScore());
        }
    }
    private int getScore() {
        float time = TimerController.Timer;
        if (time <= secondHard) return 3;
        else if (time <= secondNormal) return 2;
        else return 1;
        
    }

}
