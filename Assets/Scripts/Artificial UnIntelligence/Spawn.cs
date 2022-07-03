using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    [SerializeField]
    private int MaxSpawns = 3;
    [HideInInspector]
    public int CurrentSpawns;

    [SerializeField]
    private GameObject AuI;

    private Vector2 Size;

    void Update() {

        Size = GameObject.FindGameObjectWithTag("Map").GetComponent<Renderer>().bounds.size / 2f;
        Vector3 SpawnPosition = new Vector3(Random.Range(-Size.x, Size.x), Random.Range(-Size.y, Size.y), 3);

        if(CurrentSpawns < MaxSpawns) {
            if(AuI != null) Instantiate(AuI, SpawnPosition, Quaternion.Euler(0,0,0));
            CurrentSpawns++;
        }
    }
}
