using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (healthbar.Healthcurrent - 20 > 0)
        {
            
            healthbar.Healthcurrent = healthbar.Healthcurrent-20;
        }
        else
        {
            healthbar.Healthcurrent = 0;

        }
    }
}
