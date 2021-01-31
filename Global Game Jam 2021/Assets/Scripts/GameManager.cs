using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool IsPaused { get; set; }
    public int levelScene;
    [SerializeField] private int currentScene;
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        ResumeGame();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentScene == 0)
            StartGame();
    }

    #region Pause
    public void PauseGame()
    {
        Time.timeScale = 0;
        IsPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        IsPaused = false;
    }
    #endregion

    #region Load Game
    public void StartGame()
    {
        SceneManager.LoadScene(levelScene);
        currentScene = levelScene;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(levelScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion
}
