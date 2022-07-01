using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private GameObject Pause;

    public bool Paused = false;

    void Awake() {
        Pause = GameObject.FindGameObjectWithTag("Pause");
        Pause.SetActive(false);
    }

    void Update() {
        if(!Paused && Input.GetButtonUp("Pause")) { PauseGame(); return; }
        if(Paused && Input.GetButtonUp("Pause")) { UnPauseGame(); return; }
    }

    public void PauseGame() {
        Debug.Log("Paused");

        Cursor.visible = true;
        Pause.SetActive(true);
        Time.timeScale = 0;

        Paused = true;
    }

    public void UnPauseGame() {
        Debug.Log("UnPaused");

        Cursor.visible = false;
        Pause.SetActive(false);
        Time.timeScale = 1;

        Paused = false;
    }
}
