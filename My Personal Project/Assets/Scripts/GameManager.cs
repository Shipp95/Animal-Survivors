using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update


    public static GameManager Instance;
    public static bool isGameActive;
    [SerializeField] GameObject screenFade;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

        void Start()
    {
        isGameActive = true;
    }

    // Update is called once per frame
    void Update() // on game over actiave the game over screen and stop time
    {
        if (isGameActive == false)
        {
            GameObject.Find("Canvas").transform.Find("Game Over").gameObject.SetActive(true);
            Time.timeScale = 0;


        }
    }
    

}
