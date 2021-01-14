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



    private GameObject pausedPanel;
    private Button pausedPanel_Quit;
    private Button pausedPanel_Resume;
    private Button pausedPanel_Restart;

    private GameObject deadScreen;
    private Button deadScreen_Restart;
    private Button deadScreen_Quit;


    private void Awake()
    {

        character = FindObjectOfType<Character>();
        characterMovement = FindObjectOfType<CharacterMovement>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;

        initialFinishedLevelPanel();
        initialKeyboardControl();
        initialPausedPanel();
        initialDeadScreen();

        finishedLevelPanel.SetActive(false);
        keyboardControl.SetActive(true);
        pausedPanel.SetActive(false);
        deadScreen.SetActive(false);
    }

    private void initialDeadScreen()
    {
        deadScreen = GameObject.FindGameObjectWithTag("DeadScreen");
        deadScreen_Restart = GameObject.FindGameObjectWithTag("DeadScreen_Restart").GetComponent<Button>();
        deadScreen_Quit = GameObject.FindGameObjectWithTag("DeadScreen_Quit").GetComponent<Button>();

        deadScreen_Restart.onClick.AddListener(() => DeadScreen_Restart());
        deadScreen_Quit.onClick.AddListener(() => DeadScreen_Quit());
    }

    public void DeadScreen_Restart()
    {
        SceneManager.LoadScene(currentScene);
    }
    public void DeadScreen_Quit()
    {
        SceneManager.LoadScene(0);
    }
    public void DeadScreen_ActiveScreen() {
        keyboardControl.SetActive(false);
        deadScreen.SetActive(true);
    }
    private void initialPausedPanel()
    {
        pausedPanel = GameObject.FindGameObjectWithTag("PausedPanel");
        pausedPanel_Quit = GameObject.FindGameObjectWithTag("PausedPanel_Quit").GetComponent<Button>();
        pausedPanel_Resume = GameObject.FindGameObjectWithTag("PausedPanel_Resume").GetComponent<Button>();
        pausedPanel_Restart = GameObject.FindGameObjectWithTag("PausedPanel_Restart").GetComponent<Button>();

        pausedPanel_Quit.onClick.AddListener(() => PausedPanel_Quit());
        pausedPanel_Resume.onClick.AddListener(() => PausedPanel_Resume());
        pausedPanel_Restart.onClick.AddListener(() => PausedPanel_Restart());
    }
    public void PausedPanel_Quit()
    {
        SceneManager.LoadScene(0);
    }
    public void PausedPanel_Resume()
    {
        pausedPanel.SetActive(false);
        keyboardControl.SetActive(true);
        Time.timeScale = 1;
    }
    public void PausedPanel_Restart()
    {
        SceneManager.LoadScene(currentScene);
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
    public void KeyboardControl_Fire()
    {
        characterMovement.IsFire = true;
       
    }
    public void KeyboardControl_Jump()
    {
        characterMovement.IsJump = true;
    }
    public void KeyboardControl_Pause()
    {
        pausedPanel.SetActive(true);
        keyboardControl.SetActive(false);
        Time.timeScale = 0;
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
        finishedLevelPanel_ComplettedLevelStar[4].GetComponentInChildren<Text>().text = timeNormal.ToString();
        finishedLevelPanel_ComplettedLevelStar[5].GetComponentInChildren<Text>().text = timeHard.ToString();
    }

    public void FinishedLevelPanel_setScoreSprites(int score)
    {
        for (int i = 0; i < score; i++)
            finishedLevelPanel_ComplettedLevelStar[i+3].GetComponent<Image>().enabled = false;
    }

    private void finishedLevelPanel_nextLevel()
    {
        int scenesCount = SceneManager.sceneCountInBuildSettings;
        if (scenesCount - 1 > currentScene)
            SceneManager.LoadScene(currentScene + 1);
        else
            SceneManager.LoadScene(0);
    }
    private void finishedLevelPanel_reloadLevel()
    {
        SceneManager.LoadScene(currentScene);
    }




}
