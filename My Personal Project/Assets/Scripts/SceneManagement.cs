using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Restart()
    {
        //player variables are static and do not reset on its own on scene reload
        Player.health = 3;
        Player.score = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        GameManager.isGameActive = true;
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
