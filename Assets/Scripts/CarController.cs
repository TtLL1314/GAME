using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public AxleInfo frontAxle;
    public AxleInfo backAxle;
    public float maxMotorTorque = 400f; // 电机可对车轮施加的最大扭矩
    public float maxSteeringAngle = 30f; // 车轮的最大转向角
    public float brakeTorque = 1000f;
    public float maxSpeed = 200f;
    public float speed
    {
        get
        {
            return rd.velocity.magnitude;
        }
    }

    public float motor;
    public float frontRpm;

    public float steering;
    public float steeringRatio;
    public float minSteeringRatio = 0.1f;
    public List<ParticleSystem> smoke;

    Rigidbody rd;
    float particleEmitTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        if (v != 0)
        {
            particleEmitTime += Time.deltaTime;
            if (particleEmitTime > 0.1f)
            {
                foreach (ParticleSystem particle in smoke)
                {
                    particle.Emit(1);
                }
                particleEmitTime = 0f;
            }
        }
    }

    // 查找相应的可视车轮
    // 正确应用变换
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        collider.GetWorldPose(out Vector3 position, out Quaternion rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    float SteeringRatio()
    {
        frontRpm = (frontAxle.leftWheel.rpm + frontAxle.rightWheel.rpm) / 2;
        steeringRatio = 1f - (frontRpm / maxSpeed);
        if (steeringRatio < minSteeringRatio)
        {
            return minSteeringRatio;
        }
        return steeringRatio;
    }

    public void FixedUpdate()
    {
        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering = maxSteeringAngle * Input.GetAxis("Horizontal") * SteeringRatio();
        bool brake = Input.GetKey(KeyCode.Space);

        frontAxle.leftWheel.steerAngle = steering;
        frontAxle.rightWheel.steerAngle = steering;
            
        if (brake)
        {
            //axleInfo.leftWheel.wheelDampingRate = maxMotorTorque * brakeRatio;
            //axleInfo.rightWheel.wheelDampingRate = maxMotorTorque * brakeRatio;
            frontAxle.leftWheel.brakeTorque = brakeTorque;
            frontAxle.rightWheel.brakeTorque = brakeTorque;
            backAxle.leftWheel.brakeTorque = brakeTorque;
            backAxle.rightWheel.brakeTorque = brakeTorque;
        }
        else
        {
            //axleInfo.leftWheel.wheelDampingRate = 0;
            //axleInfo.rightWheel.wheelDampingRate = 0;
            frontAxle.leftWheel.brakeTorque = 0f;
            frontAxle.rightWheel.brakeTorque = 0f;
            backAxle.leftWheel.brakeTorque = 0f;
            backAxle.rightWheel.brakeTorque = 0f;
        }
               

        backAxle.leftWheel.motorTorque = motor;
        backAxle.rightWheel.motorTorque = motor;
            
        ApplyLocalPositionToVisuals(frontAxle.leftWheel);
        ApplyLocalPositionToVisuals(frontAxle.rightWheel);
        ApplyLocalPositionToVisuals(backAxle.leftWheel);
        ApplyLocalPositionToVisuals(backAxle.rightWheel);
        
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
}