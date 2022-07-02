using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugKeybinds : MonoBehaviour
{
    
    void Update() {
        if(Input.GetKeyDown("r")) {
            PlayerPrefs.DeleteAll();
        }
        if(Input.GetKeyDown("t")) {
            GameObject.FindGameObjectWithTag("Map").GetComponent<MapGeneration>().CalculateNoise();
        }
    }

}
