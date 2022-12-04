using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarSpeedBar : MonoBehaviour
{
    public  static float spbar;
    

    // Start is called before the first frame update
    void Start()
    {
        spbar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(spbar==1 && Input.GetKey(KeyCode.LeftShift))
            {
            speedbar.speedbarCurrent = 0;
            
        }

    }


}

