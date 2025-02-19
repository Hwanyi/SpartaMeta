using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int FlappyBest = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("FlappyBestScore"))
        {
            FlappyBest = PlayerPrefs.GetInt("FlappyBestScore");
        } 
        else
        {
            FlappyBest = 0;
        }
    }


    public void PlayFlappyScene()
    {
        SceneManager.LoadScene("FlappyScene");
    }
}
