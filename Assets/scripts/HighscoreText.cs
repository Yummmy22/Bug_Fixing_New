using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HighscoreText : MonoBehaviour
{
    Text highscore;

    void OnEnable()
    {
        highscore = GetComponent<Text>();
        DisplayHighscore();
    }

    void DisplayHighscore()
    {
        highscore.text = "High Score : " + PlayerPrefs.GetInt("highscore", 0);
    }

    public void UpdateHighscore(int newScore)
    {
        int currentHighScore = PlayerPrefs.GetInt("highscore", 0);
        if (newScore > currentHighScore)
        {
            PlayerPrefs.SetInt("highscore", newScore);
            PlayerPrefs.Save();
            DisplayHighscore(); // Update the display after changing the highscore
        }
    }
}
