using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthbar : MonoBehaviour
{
    public static int Healthcurrent;
    public static int HealthMax=100;
    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
      
        healthBar = GetComponent<Image>();
        Healthcurrent = HealthMax;
 
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)Healthcurrent / (float)HealthMax;
        
    }
}
