using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmodle : MonoBehaviour
{
     
    public GameObject obj;
 
    bool iswork;//判断鼠标是否工作
    Vector3 startPoint, startAngle;//保存开始鼠标在屏幕上的数据//保存物体模型Angles的数据
    public float rotateScale = 1f;//控制旋转速度
 
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!iswork)
        {
            iswork = true;
            startPoint=Input.mousePosition;
            startAngle = obj.transform.eulerAngles;
        }
        if (Input.GetMouseButtonUp(0))
        {
            iswork=false;
        }
        if (iswork)
        {
             var x = startPoint.x - Input.mousePosition.x;///
 
            obj.transform.eulerAngles=startAngle+new Vector3(0,x*rotateScale,0);
 
        }
 
    }


}
