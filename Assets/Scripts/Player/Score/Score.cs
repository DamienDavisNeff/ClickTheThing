using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text ScoreText;
    private Text HighScore;

    [SerializeField]
    private GameObject Spawner;

    void Start() {
        ScoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        HighScore = GameObject.FindGameObjectWithTag("High").GetComponent<Text>();
    }

    void Update() {
        ScoreText.text = "1";
        HighScore.text = "2";
    }
}
