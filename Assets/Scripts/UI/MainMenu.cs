using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Transform content;

    public Sprite isDone;
    private Button levelButton;
    void Start()
    {
        levelButton = Resources.Load<Button>("UI/LevelButton");
        Time.timeScale = 1;
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {

                Button levelButtonCOPY = null;
                levelButtonCOPY = Instantiate(levelButton, content);

            if (PlayerPrefs.HasKey("LVL_" + i)) {
                int level = PlayerPrefs.GetInt("LVL_" + i);
                Image[] images = levelButtonCOPY.GetComponentsInChildren<Image>();
                for (int j = 1; j < level + 1; j++)
                    images[j].overrideSprite = isDone;
                //images[j].sprite = isDone;
            }
                int isLevelToLoad = i;
                levelButtonCOPY.onClick.AddListener(() => loadLevel(isLevelToLoad)); ;
                levelButtonCOPY.GetComponentInChildren<Text>().text = i.ToString();

                levelButtonCOPY = null;
                Debug.Log("current level "+i);
        }
    }

    public void loadLevel(int id) {
        SceneManager.LoadScene(id);
    }

    public void QuitGame() {
        Application.Quit();
    }

  
}
