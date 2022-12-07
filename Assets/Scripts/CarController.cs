using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // 关于每个轴的信息
    public float maxMotorTorque = 400f; // 电机可对车轮施加的最大扭矩
    public float maxSteeringAngle = 30f; // 车轮的最大转向角
    public float brakeRatio = 2f;
    public float maxSpeed = 80f;
    public float speed
    {
        get
        {
            return rd.velocity.magnitude;
        }
    }

    public float motor;
    public float steering;
    public float steeringRatio;
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
        steeringRatio = 1f - (speed / maxSpeed);
        if (steeringRatio < 0.2f)
        {
            return 0.2f;
        }
        return steeringRatio;
    }

    public void FixedUpdate()
    {
        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering = maxSteeringAngle * Input.GetAxis("Horizontal") * SteeringRatio();
        bool brake = Input.GetKey(KeyCode.Space);
        
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }

            if (brake)
            {
                axleInfo.leftWheel.wheelDampingRate = maxMotorTorque * brakeRatio;
                axleInfo.rightWheel.wheelDampingRate = maxMotorTorque * brakeRatio;
            }
            else
            {
                axleInfo.leftWheel.wheelDampingRate = 0;
                axleInfo.rightWheel.wheelDampingRate = 0;
            }
                   

            if (axleInfo.motor)
            {

                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            
        ApplyLocalPositionToVisuals(axleInfo.leftWheel);
        ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // 此车轮是否连接到电机？
    public bool steering; // 此车轮是否施加转向角？
}