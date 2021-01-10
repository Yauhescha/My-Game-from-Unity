using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GridLayoutGroup grid;
    [SerializeField]
    private Sprite isDone;
    [SerializeField]
    private Sprite isNotDone;
    void Start()
    {
        Time.timeScale = 1;
        Image[] images =grid.GetComponentsInChildren<Image>();
        for (int i = 0; i < images.Length; i++)
        {
            if (PlayerPrefs.HasKey("LVL_" + (i + 1)))
                images[i].sprite = isDone;
            else
                images[i].sprite = isNotDone;
        }
    }
 

    public void QuitGame() {
        Application.Quit();
    }

  
}
