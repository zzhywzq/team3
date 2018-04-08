using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag_Click : MonoBehaviour
{
    GameObject soldier;
    Dictionary<string, int> bag;
    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
        soldier= GameObject.Find("Soldier_all_parts");
        bag = soldier.GetComponent<Soldier>().get_bag();
        GameObject.Find("Canvas/Image1/C_Button1/Text").GetComponent<Text>().text = "";
        GameObject.Find("Canvas/Image1/C_Button2/Text").GetComponent<Text>().text = "";
        GameObject.Find("Canvas/Image1/C_Button3/Text").GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    void Update()//持续检测背包的更新，并将更新在UI上表现出来
    {
        int i = 1;
        foreach (KeyValuePair<string, int> item in bag)
        {
            GameObject.Find("Canvas/Image1/C_Button" + i + "/Text").GetComponent<Text>().text = item.Key+": "+ item.Value;
            i++;
        }

    }
    public void Bag_Onclick()//显示或隐藏
    {
        if (gameObject.activeSelf == true)
            gameObject.SetActive(false);
        else if (gameObject.activeSelf == false)
            gameObject.SetActive(true);
    }
}
