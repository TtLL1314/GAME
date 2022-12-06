using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addspeedbar : MonoBehaviour
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
        if (speedbar.speedbarCurrent + 20 <= speedbar.speedbarMax)
        {
            speedbar.speedbarCurrent = speedbar.speedbarCurrent + 20;
            Destroy(gameObject);
        }
        else
        {
            speedbar.speedbarCurrent = speedbar.speedbarMax;
            Destroy(gameObject);
        }
    }

}
