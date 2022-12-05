using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upcoins : MonoBehaviour
{
    //Text GoldNum;

    //public Text coinsText;
    void OnTriggerEnter(Collider other)
    {

        PublicController.Instance.coins++;

    }
}
