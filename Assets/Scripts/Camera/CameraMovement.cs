using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Transform t_Cursor;
    private Vector2 Mouse;

    private Vector2 MapSize;

    [SerializeField]
    private Transform anchorPoint;

    [Header("Options")]
    [Tooltip("Area Around The Center Of The Screen, Where Movement Is Not Registered")]
    public float DeadZone = 2f;
    [Tooltip("Camera Speed")]
    public float Sensitivity = 1f;


    // Runs Every Time Game Comes Into Focus
    void OnApplicationFocus() {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Start() {
        t_Cursor = GameObject.FindGameObjectWithTag("Cursor").transform;
        MapSize = GameObject.FindGameObjectWithTag("Map").GetComponent<Renderer>().bounds.size / 2f;
        Cursor.visible = false;

        if(PlayerPrefs.HasKey("Sensitivity")) Sensitivity = PlayerPrefs.GetFloat("Sensitivity");
        if(PlayerPrefs.HasKey("DeadZone")) DeadZone = PlayerPrefs.GetFloat("DeadZone");
    }
    
    void FixedUpdate() {

        MousePosition(); // updates mouse position in world space
        t_Cursor.position = new Vector3(Mouse.x,Mouse.y,1); // moves cursor to mouse

        MoveCamera();
        
    }

    void MousePosition() {

        Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition); // converts screen space to world space (mouse position)

    }

    void MoveCamera() {

        float f_Distance = Vector2.Distance(t_Cursor.position, anchorPoint.position);

        Vector2 v_Distance = anchorPoint.position - t_Cursor.position;
        float angle = Mathf.Atan2(-v_Distance.y, -v_Distance.x);
        t_Cursor.rotation = Quaternion.Euler(0f,0f, angle * Mathf.Rad2Deg - 90);
        
        if(f_Distance > DeadZone) Camera.main.transform.position = Vector2.Lerp(Camera.main.transform.position, new Vector2(Mathf.Clamp(t_Cursor.position.x, -MapSize.x, MapSize.x), Mathf.Clamp(t_Cursor.position.y, -MapSize.y, MapSize.y)), Time.deltaTime * Sensitivity);

    }


}
