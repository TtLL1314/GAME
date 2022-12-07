using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PublicController : MonoBehaviour
{
    //属性值
    public int coins = 0;
    public float time = 0;

    public Text coinText;
    public Text timeText;


    //引用
    

    //单例
    private static PublicController instance;

    public static PublicController Instance
    {
        get {
            return instance;
        }

        set{
            instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(isDead){
        //     GameOver();
        // }
        coinText.text = "Coins:"+coins.ToString();
        //playrTimeText.text = P
        time += Time.deltaTime;
        timeText.text = "Time: " + time.ToString("F2");
    }

    // private void GameOver()
    // {
    //     //返回GameOver界面
    //     return;
    // }
}
