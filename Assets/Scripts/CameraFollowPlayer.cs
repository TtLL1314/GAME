using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public float Height = 5f;
    public float Distance = 5f;
    public float Speed = 4f;

    Vector3 targetPosition;
    Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Follow()
    {
        targetPosition = target.position + Vector3.up * Height - target.forward * Distance;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Speed * Time.deltaTime);
        transform.LookAt(target);
    }

    public void FollowImmediately()
    {
        transform.position = target.position + Vector3.up * Height - target.forward * Distance;
        transform.LookAt(target);
    }

    void FixedUpdate()
    {
        Follow();
    }
}
