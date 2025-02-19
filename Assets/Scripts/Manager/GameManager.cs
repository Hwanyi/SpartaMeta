using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int flappyBest = 0;
    public TextMeshProUGUI flappyBestText;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("FlappyBestScore"))
        {
            flappyBest = PlayerPrefs.GetInt("FlappyBestScore");
        } 
        else
        {
            flappyBest = 0;
        }

        flappyBestText.text = flappyBest.ToString();
    }


    public void PlayFlappyScene()
    {
        SceneManager.LoadScene("FlappyScene");
    }
}
