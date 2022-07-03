using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{

    [SerializeField]
    private GameObject Spawner;

    void Update() {

        if(Input.GetButtonDown("Fire1")) {
            Debug.Log("Fire");

            Vector2 WorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(WorldPoint, -Vector2.up);

            if(hit.collider != null) {
                Debug.Log(hit.collider.name);

                if(hit.collider.tag == "Enemy") Destroy(hit.transform.gameObject);

                Spawner.GetComponent<Spawn>().CurrentSpawns = Spawner.GetComponent<Spawn>().CurrentSpawns - 1;

            }

        }
    }
}
