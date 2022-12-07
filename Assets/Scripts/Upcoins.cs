using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upcoins : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {

        PublicController.Instance.coins++;
        Destroy(gameObject);
    }
}
