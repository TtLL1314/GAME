using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTime : MonoBehaviour
{
    public float bonusTime = 10f;

    void OnTriggerEnter(Collider other)
    {

        PublicController.Instance.time -= bonusTime;
        Destroy(gameObject);
    }
}
