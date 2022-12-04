using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class speedbar : MonoBehaviour
{
    public static int speedbarCurrent;
    public static int speedbarMax;
    private Image speedBar;

    // Start is called before the first frame update
    void Start()
    {
        speedBar = GetComponent<Image>();
        speedbarCurrent = 0;
        speedbarMax = 100;

    }

    // Update is called once per frame
    void Update()
    {
        speedBar.fillAmount = (float)speedbarCurrent / (float)speedbarMax;
    }
}
