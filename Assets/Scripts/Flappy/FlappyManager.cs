using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyManager : MonoBehaviour
{
    static FlappyManager gameManager;
    public static FlappyManager instance { get { return gameManager; } }

    private int currentScore = 0;
    private int bestScore = 0;

    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }

    public enum State
    {
        Start,
        Playing,
        Dead
    }

    public State state;

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
        state = State.Start;
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
        if (PlayerPrefs.HasKey("FlappyBestScore")) 
            bestScore = PlayerPrefs.GetInt("FlappyBestScore");
        else
            bestScore = 0;
        uiManager.UpdateBestScore(bestScore);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.GameOver();
        if(bestScore < currentScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("FlappyBestScore", currentScore);
            uiManager.UpdateBestScore(currentScore);
        }
    }

    public void GameStart()
    {
        state = State.Playing;
        uiManager.StartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log($"Score : {currentScore}");
        uiManager.UpdateScore(currentScore);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
}
