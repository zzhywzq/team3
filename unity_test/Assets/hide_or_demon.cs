using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hide_or_demon : MonoBehaviour
{
    GameObject pnl;//道具栏
    public string pnl_name;//道具栏名字，参数
    
    void Start()
    {
        pnl = GameObject.Find(pnl_name);
        pnl.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Bag_Onclick()
    {
        if (pnl.activeSelf == true)
            pnl.SetActive(false);
        else if (pnl.activeSelf == false)
        {
            pnl.SetActive(true);
        }

    }
}
