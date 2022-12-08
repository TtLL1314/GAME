using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthbar : MonoBehaviour
{
    public static int Healthcurrent;
    public static int HealthMax=100;
    private Image healthBar;
    public GameObject g;
    public GameObject g2;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        Healthcurrent = HealthMax;
        g.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)Healthcurrent / (float)HealthMax;
        if (Healthcurrent <= 0)
        {
            g2.GetComponent<Rigidbody>().velocity = Vector3.zero;
            g.SetActive(true);
        
        }
    }
}
