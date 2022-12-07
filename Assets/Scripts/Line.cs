using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Line : MonoBehaviour
{
	public Image ImageLine;
    Text TextLine;
    //控制进度
    float startValue = 0;
    const float endValue = 100;



    // Start is called before the first frame update
    void Start()
    {
        ImageLine = gameObject.GetComponent<Image>();  // 获取到进度条的图片对象
        TextLine = transform.Find("TextLine").GetComponent<Text>();   // 获取到进度条的百分比显示
    }


    // Update is called once per frame
    void Update()
    {
        if (startValue < endValue)
        {
            startValue += Time.deltaTime * 100;
        }
        //实时更新进度百分比的文本显示 
        TextLine.text = startValue.ToString("F1") + "%";
        //实时更新滑动进度图片的fillAmount值  
        ImageLine.fillAmount = startValue / endValue;  // 因为FillAmount的值是从0-1的
        if (startValue >= endValue)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
