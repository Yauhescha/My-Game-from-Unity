using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public static int currentScene;
    private Character character;
    private CharacterMovement characterMovement;

    private GameObject  finishedLevelPanel;
    private GameObject[] finishedLevelPanel_ComplettedLevelStar;
    private Button      finishedLevelPanel_RestartLevel;
    private Button      finishedLevelPanel_NextLevel;
    private Text        finishedLevelPanel_CurrentLevelNumber;
    private Text        finishedLevelPanel_LevelFinishedTime;

 


    private GameObject keyboardControl;    
    private Button keyboardControl_Fire;
    private Button keyboardControl_Jump;
    private Button keyboardControl_Pause;
    public HealthBar keyboardControl_HealthBar;
    private Text keyboardControl_timer;
    private Text keyboardControl_bullets;



    private GameObject pausePanel;

   

    private void Awake()
    {
        character = FindObjectOfType<Character>();
        characterMovement = FindObjectOfType<CharacterMovement>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        initialFinishedLevelPanel();
        initialKeyboardControl();
        finishedLevelPanel.SetActive(false);
        keyboardControl.SetActive(true);







    }

    private void initialKeyboardControl()
    {
        keyboardControl = GameObject.FindGameObjectWithTag("KeyboardControl");
        keyboardControl_Fire = GameObject.FindGameObjectWithTag("KeyboardControl_Fire").GetComponent<Button>();
        keyboardControl_Jump = GameObject.FindGameObjectWithTag("KeyboardControl_Jump").GetComponent<Button>();
        keyboardControl_Pause = GameObject.FindGameObjectWithTag("KeyboardControl_Pause").GetComponent<Button>();
        keyboardControl_HealthBar = GameObject.FindGameObjectWithTag("KeyboardControl_HealthBar").GetComponent<HealthBar>();
        keyboardControl_timer = GameObject.FindGameObjectWithTag("KeyboardControl_Timer").GetComponentInChildren<Text>();
        keyboardControl_bullets = GameObject.FindGameObjectWithTag("KeyboardControl_Bullets").GetComponent<Text>();


        keyboardControl_bullets.text = SceneManager.GetActiveScene().buildIndex.ToString();
        keyboardControl_Fire.onClick.AddListener(() => KeyboardControl_Fire());
        keyboardControl_Jump.onClick.AddListener(() => KeyboardControl_Jump());
        keyboardControl_Pause.onClick.AddListener(() => KeyboardControl_Pause());
    }
    private void KeyboardControl_Fire()
    {
        characterMovement.IsFire = true;
       
    }
    private void KeyboardControl_Jump()
    {
        characterMovement.IsJump = true;
    }
    private void KeyboardControl_Pause()
    {
        Time.timeScale = 0;
        keyboardControl.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void KeyboardControl_SetBulletsCount(int count)
    {
        keyboardControl_Fire.gameObject.SetActive(count > 0);
        keyboardControl_bullets.text = count >= 0 ? count.ToString() : "0";
    }
    public void KeyboardControl_UpdateTimer(string newTime)
    {
        keyboardControl_timer.text = newTime;
    }



    private void initialFinishedLevelPanel()
    {
        finishedLevelPanel = GameObject.FindGameObjectWithTag("FinishedLevelPanel");
        finishedLevelPanel_CurrentLevelNumber = GameObject.FindGameObjectWithTag("CurrentLevelNumber").GetComponent<Text>();
        finishedLevelPanel_LevelFinishedTime = GameObject.FindGameObjectWithTag("FinishedLevelPanel_LevelFinishedTime").GetComponent<Text>();
        finishedLevelPanel_RestartLevel = GameObject.FindGameObjectWithTag("FinishedLevelPanel_RestartLevel").GetComponent<Button>();
        finishedLevelPanel_NextLevel = GameObject.FindGameObjectWithTag("FinishedLevelPanel_NextLevel").GetComponent<Button>();
        finishedLevelPanel_ComplettedLevelStar = GameObject.FindGameObjectsWithTag("FinishedLevelPanel_ComplettedLevelStar");


        finishedLevelPanel_CurrentLevelNumber.text = SceneManager.GetActiveScene().buildIndex.ToString();
        finishedLevelPanel_NextLevel.onClick.AddListener(() => finishedLevelPanel_nextLevel());
        finishedLevelPanel_RestartLevel.onClick.AddListener(() => finishedLevelPanel_reloadLevel());
    }

    public void FinishedLevelPanel_setActiveMenuFinishedLevelPanel()
    {
        finishedLevelPanel.SetActive(true);
    }
    public void FinishedLevelPanel_setFinishedTime(string time)
    {
        finishedLevelPanel_LevelFinishedTime.text = time;
    }
    public void FinishedLevelPanel_setNormalAndHardTime(string timeNormal, string timeHard)
    {
        finishedLevelPanel_ComplettedLevelStar[1].GetComponentInChildren<Text>().text = timeNormal.ToString();
        finishedLevelPanel_ComplettedLevelStar[2].GetComponentInChildren<Text>().text = timeHard.ToString();
    }

    public void FinishedLevelPanel_setScoreSprites(int score)
    {
        for (int i = 0; i < score; i++)
            finishedLevelPanel_ComplettedLevelStar[i].GetComponent<Image>().overrideSprite
                = finishedLevelPanel_ComplettedLevelStar[3].GetComponent<Image>().sprite;
    }

    private void finishedLevelPanel_nextLevel()
    {
        int scenesCount = SceneManager.sceneCountInBuildSettings;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (scenesCount - 1 > currentScene)
            SceneManager.LoadScene(currentScene + 1);
        else
            SceneManager.LoadScene(0);
    }
    private void finishedLevelPanel_reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




}
