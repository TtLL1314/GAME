using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public Text timeText;
    public static float timer;
    private bool istimeout;
    // Start is called before the first frame update
    void Start()
    {
        timer = 60f;
        istimeout = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (istimeout == false)
        {
            timer -= Time.deltaTime;
            timeText.text = '0' + timer.ToString("F2");
            if (timer <= 0)
            {
                istimeout = true;
                timeText.text = "00.00";
            }

        }
    }
}
