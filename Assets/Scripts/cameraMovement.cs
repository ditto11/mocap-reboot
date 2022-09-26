using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float speedCoef;
    public float rotateSpeed;
    public static Camera camera;
    public static GameObject canvas;
    public bool canvasVisible;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (Input.GetKeyDown(KeyCode.Space)) {
            canvasVisible = !canvasVisible;
            canvas.SetActive(canvasVisible); 
        }

        if (Input.GetKey(KeyCode.Minus))
        camera.fieldOfView += 0.1f;
        if (Input.GetKey(KeyCode.Equals))
        camera.fieldOfView -= 0.1f;

        if (Input.GetKey(KeyCode.S))
        rb.AddRelativeForce(new Vector3(0,-1,0) * speedCoef);
        if (Input.GetKey(KeyCode.W))
        rb.AddRelativeForce(new Vector3(0,1,0) * speedCoef);
        if (Input.GetKey(KeyCode.D))
        rb.AddRelativeForce(new Vector3(1,0,0) * speedCoef);
        if (Input.GetKey(KeyCode.A))
        rb.AddRelativeForce(new Vector3(-1,0,0) * speedCoef);

        if (Input.GetKey(KeyCode.UpArrow))
        rb.AddRelativeTorque(-1*rotateSpeed,0,0);
        else if (Input.GetKey(KeyCode.DownArrow))
        rb.AddRelativeTorque(1*rotateSpeed,0,0);
        else if (Input.GetKey(KeyCode.LeftArrow))
        rb.AddRelativeTorque(0,-1*rotateSpeed,0);
        else if (Input.GetKey(KeyCode.RightArrow))
        rb.AddRelativeTorque(0,1*rotateSpeed,0);
        else {
            Vector3 eulerRotation = rb.rotation.eulerAngles;
            rb.rotation = Quaternion.Euler(new Vector3(eulerRotation.x,eulerRotation.y,0));
        }

        rb.angularVelocity = new Vector3(0,rb.angularVelocity.y,rb.angularVelocity.z);
    }
}
