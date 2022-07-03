using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timeElapsed = 0;

    [SerializeField]
    private float timeLeft = 300;

    private Text timeLeftText;

    void Start() {
        timeLeftText = GameObject.FindGameObjectWithTag("Time").GetComponent<Text>();
    }

    void Update() {
        timeElapsed = timeElapsed + Time.deltaTime;
        timeLeft = timeLeft - Time.deltaTime;

        timeLeftText.text = Mathf.Round(timeLeft).ToString();

        if(timeLeft <= 0) {
            Cursor.visible = true;
            SceneManager.LoadScene("EndScreen");
        }
    }
}
