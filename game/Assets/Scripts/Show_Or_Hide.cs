  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_Or_Hide : MonoBehaviour
{
    GameObject obj;//要隐藏的对象

    void Start()
    {
        obj = GameObject.Find("Image1");
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            show_hide();

        }
    }
    public void show_hide()//显示或隐藏
    {
        if (obj.activeSelf == true)
            obj.SetActive(false);
        else if (obj.activeSelf == false)
            obj.SetActive(true);
    }
}

