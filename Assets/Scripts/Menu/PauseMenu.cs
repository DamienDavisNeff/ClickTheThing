using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    // required game objects
    public GameObject Pause;
    public GameObject Options;

    private bool Paused = false;

    void Start() {

        if(Options == null) Options = this.GetComponent<OptionsMenu>().Options; // if there isn't a options menu set, tries to pull it from options scripts, in case it is set there
        if(Pause == null) Options = this.GetComponent<OptionsMenu>().Pause; // if the pause menu isn't set, tries to pull it from options, in case it is set there

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
