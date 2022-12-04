using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upspeed : MonoBehaviour
{
    public CarController car;
    public static float time=2f;
    public bool IsCarFasting = false;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Player").GetComponent<MonoBehaviour>() as CarController;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.LeftShift) && speedbar.speedbarCurrent == speedbar.speedbarMax)
        {
            IsCarFasting = true;
            speedbar.speedbarCurrent = 0;
            car.maxMotorTorque = car.maxMotorTorque + 500;
        }
        if (IsCarFasting == true && time > 0)
        {
            time = time - Time.deltaTime;
        }
        if (time == 0)
        {
            IsCarFasting = false;
            car.maxMotorTorque = car.maxMotorTorque - 400;
        }
    }
}
