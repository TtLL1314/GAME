using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addblood : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)

    {
        if (healthbar.Healthcurrent + 20 <= healthbar.HealthMax) { 
            healthbar.Healthcurrent = healthbar.Healthcurrent + 20;
        Destroy(gameObject); }
        else
        {
            healthbar.Healthcurrent = healthbar.HealthMax;
            Destroy(gameObject);
        }

    }


}
