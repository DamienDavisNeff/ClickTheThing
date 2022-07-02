using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPref : MonoBehaviour
{
    
    void Update() {
        if(Input.GetKeyDown("r")) {
            PlayerPrefs.DeleteAll();
        }
    }

}
