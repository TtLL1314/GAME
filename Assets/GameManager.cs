using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    CarController car;
    float speed;
    public GameObject needle;

    private float startPosition = 220f;
    private float endPosition = -49f;
    private float desiredPosition;

    public float vehicleSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Player").GetComponent<MonoBehaviour>() as CarController;
    }

    void Update()
    {
        vehicleSpeed = (int)(car.speed * 3.6);
        updateNeedle();
    }



    public void updateNeedle()
    {
        desiredPosition = startPosition - endPosition;
        float ratio = (float)vehicleSpeed / 180;
        needle.transform.eulerAngles = new Vector3(0, 0, (startPosition - ratio * desiredPosition));
    }
}
