using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float moveSpeed;
    [SerializeField] float zoomSpeed;
    [SerializeField] float zoomLevel;
    [SerializeField] float zoomMin;
    [SerializeField] float zoomMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y = moveSpeed / zoomLevel;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y -= moveSpeed / zoomLevel;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x -= moveSpeed / zoomLevel;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x = moveSpeed/zoomLevel;
        }

        if (Input.GetKey(KeyCode.E) && zoomLevel < zoomMax)
        {
            zoomLevel += zoomSpeed;
        } 
        else if (Input.GetKey(KeyCode.Q) && zoomLevel > zoomMin)
        {
            zoomLevel -= zoomSpeed;
        }
        camera.orthographicSize = zoomLevel;
        camera.transform.position += moveDirection;
    }
}
