using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITime : MonoBehaviour
{
    Text time;

    // Start is called before the first frame update
    void Start()
    {
        time = GetComponent<Text>();    
    }

    // Update is called once per frame
    void Update()
    {
        time.text = "Time: " + (int)Time.realtimeSinceStartup;
    }
}
