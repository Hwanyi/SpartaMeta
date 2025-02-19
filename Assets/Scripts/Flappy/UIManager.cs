using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    public GameObject startUI;
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
            Debug.LogError("score text text is null");
    }

    public void StartGame()
    {
        startUI.SetActive(false);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateBestScore(int score)
    {
        bestScoreText.text = score.ToString();
    }

    
}