using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public GameObject Options;
    public GameObject Pause;

    public Slider SensitivitySlider;
    public Slider DeadZoneSlider;

    private bool opened = false;

    void Start() {

        if(Pause == null) Pause = this.GetComponent<PauseMenu>().Pause; // if there isn't a pause menu set, gets it from pause menu script, in case it is set there
        if(Options == null) Options = this.GetComponent<PauseMenu>().Options; // if options menu is not set, gets it from pause menu script, in case it is set there

        Options.SetActive(false);

    }

    void Update() {
        if(opened) Cursor.visible = true;
    }

    public void LoadOptions() {

        Pause.SetActive(false);
        Options.SetActive(true);
        Cursor.visible = true;
        opened = true;

        // if a sensitivity isn't saved, saves it
        if(!PlayerPrefs.HasKey("Sensitivity")) PlayerPrefs.SetFloat("Sensitivity", Camera.main.GetComponent<CameraMovement>().Sensitivity);
        // loads sensitivity
        SensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity");
        // if a deadzone isn't saved, saves it
        if(!PlayerPrefs.HasKey("DeadZone")) PlayerPrefs.SetFloat("DeadZone", Camera.main.GetComponent<CameraMovement>().DeadZone);
        // loads deadzone
        DeadZoneSlider.value = PlayerPrefs.GetFloat("DeadZone");

        Time.timeScale = 0;

    }

    public void UnLoadOptions() {

        Pause.SetActive(false);
        Options.SetActive(false);
        Cursor.visible = false;

        opened = false;

        Time.timeScale = 1;

    }

    public void ChangeSensitivity() {

        Camera.main.GetComponent<CameraMovement>().Sensitivity = SensitivitySlider.value; // sets sensitivity
        Debug.Log(SensitivitySlider.value);
        PlayerPrefs.SetFloat("Sensitivity", SensitivitySlider.value); // saves sensitivity

    }

    public void ChangeDeadZone() {
        
        Camera.main.GetComponent<CameraMovement>().DeadZone = DeadZoneSlider.value; // sets deadzone
        Debug.Log(DeadZoneSlider.value);
        PlayerPrefs.SetFloat("DeadZone", DeadZoneSlider.value); // saves deadzone

    }

}
