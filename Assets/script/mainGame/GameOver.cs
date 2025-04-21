using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject highScoreImageUI;
    [SerializeField] private TextMeshProUGUI highScoreUI;
 
    public void setVar(int score)
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                highScoreImageUI.SetActive(true);
                scoreUI.text = string.Format("Your Score : " + score);
                highScoreUI.text = string.Format("High Score : " + score);
                PlayerPrefs.SetInt("highScore", score);

            }
            else
            {
                highScoreImageUI.SetActive(false);
                scoreUI.text = string.Format("Your Score : " + score);
                highScoreUI.text = string.Format("High Score : " + PlayerPrefs.GetInt("highScore"));
            }
        }
        else
        {
            highScoreImageUI.SetActive(true);
            scoreUI.text = string.Format("Your Score : " + score);
            highScoreUI.text = string.Format("High Score : " + score);
            PlayerPrefs.SetInt("highScore", score);
        }
        
    }


    //for restart and back to main menu button action

    public void RestartAction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
