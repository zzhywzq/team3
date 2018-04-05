using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag_Click : MonoBehaviour
{
    GameObject pnl;//道具栏
    public string pnl_name;//道具栏名字，参数
    public int pnl_size;//道具栏有多少格子，参数
    GameObject[] child_btns;//道具栏里的道具
    Text[] texts;//每个道具的文字
    GameObject soldier;//士兵
    public string soldier_name;//士兵名字，参数

    // Use this for initialization
    void Start()
    {
       
        child_btns = new GameObject[pnl_size];
        texts = new Text[pnl_size];
        soldier = GameObject.Find(soldier_name);//.GetComponent<Soldier>().add_prop("枪", 1);
        
        for (int i=0;i<pnl_size;) {
            i++;
            child_btns[i-1] = GameObject.Find("Child_btn"+i);
            texts[i-1] = child_btns[i-1].transform.GetComponentInChildren<Text>();
            
            
        }

        pnl = GameObject.Find(pnl_name);
        pnl.SetActive(false);
    }

    // Update is called once per frame
    	void Update () {

    }
    public void Bag_Onclick()
    {
        Dictionary<string, int> bag = soldier.GetComponent<Soldier>().get_bag();
        int i = 0;
        foreach (KeyValuePair<string, int> item in bag)
        {
            texts[i].text = "物品：" + item.Key + "    数量：" + item.Value + "\r\n";
            i++;
        }
        //Debug.LogError(btn.GetComponent<Text>());
        if (pnl.activeSelf == true)
            pnl.SetActive(false);
        else if (pnl.activeSelf == false)
            pnl.SetActive(true);
    }
}
