using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upspeed : MonoBehaviour
{
    public CarController car;
    public float time = 0f;
    public float ratio = 10f;

    Rigidbody r;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Player").GetComponent<MonoBehaviour>() as CarController;
        r = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.LeftShift) && speedbar.speedbarCurrent == speedbar.speedbarMax)
        {
            speedbar.speedbarCurrent = 0;
            time = 2f;
        }
        if (time > 0)
        {
            time -= Time.deltaTime;
            r.velocity = r.velocity + ratio * Time.deltaTime * transform.forward;
        }
    }
}
