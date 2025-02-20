using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int flappyBest = 0;
    private int StackBest = 0;
    public TextMeshProUGUI flappyBestText;
    public TextMeshProUGUI flappyBoardText;

    public TextMeshProUGUI stackBestText;
    public TextMeshProUGUI stackBoardText;

    // Start is called before the first frame update
    void Start()
    {

        Screen.SetResolution(1920, 1080, false);
        if (PlayerPrefs.HasKey("FlappyBestScore"))
        {
            flappyBest = PlayerPrefs.GetInt("FlappyBestScore");
        } 
        else
        {
            flappyBest = 0;
        }

        if (PlayerPrefs.HasKey("BestStackScore"))
        {
            StackBest = PlayerPrefs.GetInt("BestStackScore");
        }
        else
        {
            StackBest = 0;
        }

        flappyBestText.text = flappyBest.ToString();
        flappyBoardText.text = flappyBest.ToString();
        stackBestText.text = StackBest.ToString();
        stackBoardText.text = StackBest.ToString();
    }


    public void PlayFlappyScene()
    {
        SceneManager.LoadScene("FlappyScene");
    }

    public void PlayStackScene()
    {
        SceneManager.LoadScene("StackScene");
    }
}
