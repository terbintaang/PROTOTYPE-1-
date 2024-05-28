using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinsPropeller : MonoBehaviour
{
    // Adjust to change the speed
    public float spinSpeed = 2000f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
    }
}
