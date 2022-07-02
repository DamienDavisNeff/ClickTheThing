using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuI : MonoBehaviour
{
    
    private float xBounds;
    private float yBounds;
    private Vector2 Bounds;

    private Vector2 TargetPosition = new Vector2(0,0);

    private Transform Unintelligent;

    void Start() {

        Bounds = GameObject.FindGameObjectWithTag("Map").GetComponent<Renderer>().bounds.size / 1.5f;

        xBounds = Bounds.x;
        yBounds = Bounds.y;

        Unintelligent = gameObject.transform;

    }

    void Update() {

        // ;

        if(Unintelligent.position.x < TargetPosition.x + 10f && Unintelligent.position.x > TargetPosition.x - 10f) {
            if(Unintelligent.position.y < TargetPosition.y + 10f && Unintelligent.position.y > TargetPosition.y - 10f) TargetPosition = new Vector2(Random.Range(-xBounds,xBounds), Random.Range(-yBounds,yBounds));
        }

        Unintelligent.position = Vector2.Lerp(Unintelligent.position, TargetPosition, (Time.deltaTime * 5f) / Vector2.Distance(Unintelligent.position, TargetPosition));
        Unintelligent.position = new Vector3(Unintelligent.position.x, Unintelligent.position.y, 3);
        
    }

}
