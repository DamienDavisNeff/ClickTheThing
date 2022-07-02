using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject Pause;
    public GameObject Options;

    private bool Paused = false;

    void Start() {

        if(Options == null) Options = this.GetComponent<OptionsMenu>().Options;
        if(Pause == null) Options = this.GetComponent<OptionsMenu>().Pause;

        Pause.SetActive(false);
        
    }

    void Update() {
        if(!Paused && Input.GetButtonUp("Pause")) { PauseGame(); return; }
        if(Paused && Input.GetButtonUp("Pause")) { UnPauseGame(); return; }
    }

    public void PauseGame() {

        Pause.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;

    }

    public void UnPauseGame() {

        Time.timeScale = 1;
        Pause.SetActive(false);
        Cursor.visible = false;

    }
}
