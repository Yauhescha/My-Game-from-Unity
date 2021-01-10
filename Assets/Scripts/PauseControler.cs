using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControler : MonoBehaviour
{
    public void setGamePause(bool setPause) {

        Time.timeScale = setPause?0:1;
    }
    public void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitToMainMenu() {
        SceneManager.LoadScene(0);
    }
}
