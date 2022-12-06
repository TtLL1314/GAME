using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogPoint : MonoBehaviour
{
    public GameObject lastPoint;

    CameraFollowPlayer cam;
    Rigidbody rb;

    bool rKeyPressed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MonoBehaviour>() as CameraFollowPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LogPoint"))
        {
            lastPoint = other.gameObject;
        }
    }

    void Update()
    {
        rKeyPressed = Input.GetKeyDown(KeyCode.R);
        if (rKeyPressed)
        {
            Debug.Log("R Pressed");
            if (lastPoint != null)
            {
                JumpBack();
                Reset();
            }
            rKeyPressed = false;
        }
    }

    private void Reset()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void JumpBack()
    {
        transform.SetPositionAndRotation(lastPoint.transform.position, lastPoint.transform.rotation);
        cam.FollowImmediately();
    }
    
}
