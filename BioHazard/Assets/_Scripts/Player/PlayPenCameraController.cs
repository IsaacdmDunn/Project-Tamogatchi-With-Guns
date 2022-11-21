using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPenCameraController : MonoBehaviour
{
    public Vector2 xBounds;
    public Vector2 yBounds;
    public Vector2 zBounds;
    public float zoomSpeed = 10.33f;
    public Vector3 zoomVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.up * z + transform.forward * z;

        if (Input.GetKey(KeyCode.E) && gameObject.transform.position.y > zBounds.x)
        {
            move += transform.forward * Time.deltaTime * zoomSpeed;
        }
        else if (Input.GetKey(KeyCode.Q) && this.gameObject.transform.position.y < zBounds.y)
        {
            move -= transform.forward * Time.deltaTime * zoomSpeed;
        }

        gameObject.transform.position += move;
    }
}
