using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishController : MonoBehaviour
{
    private Button RestartLevel;
    private Button NextLevel;
    private GameObject FinishedLevelPanel;
    private GameObject[] ComplettedLevelStar;
    private Text CurrentLevelNumber;
    private Text LevelFinishedTime;

    [SerializeField]
    private int secondHard;
    [SerializeField]
    private int secondNormal;

    void Start()
    {
        FinishedLevelPanel = GameObject.FindGameObjectWithTag("FinishedLevelPanel");
        CurrentLevelNumber = GameObject.FindGameObjectWithTag("CurrentLevelNumber").GetComponent<Text>();
        LevelFinishedTime = GameObject.FindGameObjectWithTag("LevelFinishedTime").GetComponent<Text>();
        RestartLevel = GameObject.FindGameObjectWithTag("RestartLevel").GetComponent<Button>();
        NextLevel = GameObject.FindGameObjectWithTag("NextLevel").GetComponent<Button>();
        ComplettedLevelStar = GameObject.FindGameObjectsWithTag("ComplettedLevelStar");
        FinishedLevelPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            FinishedLevelPanel.SetActive(true);
            CurrentLevelNumber.text = SceneManager.GetActiveScene().buildIndex.ToString();
            LevelFinishedTime.text = String.Format("{0:0.0}", TimerController.Timer);
            Debug.Log("текущий уровень прохода "+ getScore());
            for (int i = 0; i < getScore(); i++)
              ComplettedLevelStar[i].GetComponent<Image>().overrideSprite = ComplettedLevelStar[3].GetComponent<Image>().sprite;
            NextLevel.onClick.AddListener(()=> nextLevel());
            RestartLevel.onClick.AddListener(() => reloadLevel());
            ComplettedLevelStar[1].GetComponentInChildren<Text>().text = secondNormal.ToString();
            ComplettedLevelStar[2].GetComponentInChildren<Text>().text = secondHard.ToString();

            GameObject.Find("KeyboardControl").SetActive(false);
        }
    }
    private int getScore() {
        float time = TimerController.Timer;
        if (time <= secondHard) return 3;
        else if (time <= secondNormal) return 2;
        else return 1;
        
    }
    private void nextLevel() {
        int scenesCount = SceneManager.sceneCountInBuildSettings;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LVL_" + (currentScene), getScore());
        if (scenesCount - 1 > currentScene)
            SceneManager.LoadScene(currentScene + 1);
        else
            SceneManager.LoadScene(0);
    }
    private void reloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
