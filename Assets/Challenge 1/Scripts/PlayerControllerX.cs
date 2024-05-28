using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 10.0f;
    public float tiltSpeed = 100.0f;
    public float resetSpeed = 30.0f; // Speed at which the plane returns to its initial pose
    public float verticalInput;

    private Vector3 initialPosition;
    private Quaternion initialRotation; // Initial rotation of the plane

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // get the user's vertical input
        float tiltInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        if (tiltInput != 0)
        {
            // tilt the plane up/down based on up/down arrow keys
            transform.Rotate(Vector3.right, -tiltInput * tiltSpeed * Time.deltaTime);
        }
        else
        {
            // Smoothly return the plane to its initial pose
            transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, resetSpeed * Time.deltaTime); ;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
