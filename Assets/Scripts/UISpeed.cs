using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpeed : MonoBehaviour
{
    Text t;
    CarController car;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Player").GetComponent<MonoBehaviour>() as CarController;
        t = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "Speed: " + (int)(car.speed * 3.6) + " Km/h";
    }
}
