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

    void Start() {

        if(Pause == null) Pause = this.GetComponent<PauseMenu>().Pause;
        if(Options == null) Options = this.GetComponent<PauseMenu>().Options;

        Options.SetActive(false);

    }

    public void LoadOptions() {

        Pause.SetActive(false);
        Options.SetActive(true);
        Cursor.visible = true;

        if(!PlayerPrefs.HasKey("Sensitivity")) PlayerPrefs.SetFloat("Sensitivity", Camera.main.GetComponent<CameraMovement>().Sensitivity);
        SensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity");
        if(!PlayerPrefs.HasKey("DeadZone")) PlayerPrefs.SetFloat("DeadZone", Camera.main.GetComponent<CameraMovement>().DeadZone);
        DeadZoneSlider.value = PlayerPrefs.GetFloat("DeadZone");

        Time.timeScale = 0;

    }

    public void UnLoadOptions() {

        Pause.SetActive(false);
        Options.SetActive(false);
        Cursor.visible = false;

        Time.timeScale = 1;

    }

    public void ChangeSensitivity() {

        Camera.main.GetComponent<CameraMovement>().Sensitivity = SensitivitySlider.value;
        Debug.Log(SensitivitySlider.value);
        PlayerPrefs.SetFloat("Sensitivity", SensitivitySlider.value);

    }

    public void ChangeDeadZone() {
        
        Camera.main.GetComponent<CameraMovement>().DeadZone = DeadZoneSlider.value;
        Debug.Log(DeadZoneSlider.value);
        PlayerPrefs.SetFloat("DeadZone", DeadZoneSlider.value);

    }

}
