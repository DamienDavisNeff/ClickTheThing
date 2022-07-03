using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private Text ScoreText;
    private Text HighScoreText;

    [HideInInspector]
    public int ScoreInt = 0;
    [HideInInspector]
    public int HighScore = 0;

    [SerializeField]
    private GameObject Spawner;

    void Start() {
        ScoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        HighScoreText = GameObject.FindGameObjectWithTag("High").GetComponent<Text>();

        ScoreText.text = "Score: " + ScoreInt.ToString();

        if(PlayerPrefs.HasKey("HighScore")) HighScore = PlayerPrefs.GetInt("HighScore");
        HighScoreText.text = "High Score: " + HighScore.ToString();

        if(SceneManager.GetActiveScene().name == "EndScreen" && PlayerPrefs.HasKey("LastScore")) ScoreText.text = "Last Score: " + PlayerPrefs.GetInt("LastScore");
    }

    public void IncreaseScore() {

        ScoreInt++;
        PlayerPrefs.SetInt("LastScore", ScoreInt);
        Spawner.GetComponent<Spawn>().MaxSpawns++;

        if(ScoreInt > HighScore) {

            HighScore = ScoreInt;
            PlayerPrefs.SetInt("HighScore", HighScore);

        }

        ScoreText.text = "Score: " + ScoreInt.ToString();
        HighScoreText.text = "High Score: " + HighScore;

        Debug.Log("SCORE: " + ScoreInt + "\nHIGH SCORE: " + HighScore);

    }
}
