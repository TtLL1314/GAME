using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class addtime : MonoBehaviour
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
        if (Timer.timer + 10f <= 60f)
        {
            Timer.timer = Timer.timer + 10f;
        }
        else
        {
            Timer.timer = 60f;
        }
    }
}
