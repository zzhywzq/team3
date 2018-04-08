using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Click : MonoBehaviour
{
    GameObject soldier;//人物
    Dictionary<string, int> bag;//背包
    // Use this for initialization
    void Start()
    {
        soldier = GameObject.Find("Soldier_all_parts");
        bag = soldier.GetComponent<Soldier>().get_bag();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //按钮点击_方法描述
    //1.创建场景中显示的物品
    //2.删除内存背包里的键值对
    //3.清空屏幕上显示的按钮文本
    public void Item_OnClick(int btn_id)//点下按钮是第几个，给按钮添加脚本后应输入的参数
    {
        //由于不能直接删除修改字典，所以创建一个存储字典的列表
        List<string> needChangeList = new List<string>();
        //将字典内容赋值给列表
        if (bag != null && bag.Count > 0)
        {
            foreach (var item in bag)
            {
                if (GameObject.Find("Canvas/Image1/C_Button" + btn_id + "/Text").GetComponent<Text>().text.Contains(item.Key))//如果找到拥有此键的
                {
                    for (int i=0; i<item.Value;i++) {
                        Instantiate(GameObject.Find(item.Key), new Vector3(soldier.transform.position.x, soldier.transform.position.y+3, soldier.transform.position.z), Quaternion.identity);//xyz次序
                    } 
                    needChangeList.Add(item.Key);
                }
            }
        }
        //对于列表里面存放的物品，将在字典（背包）中删除
        if (needChangeList.Count > 0)
        {
            foreach (var item in needChangeList)
            {
                bag.Remove(item);
            }
        }
        //清文本
        GameObject.Find("Canvas/Image1/C_Button1/Text").GetComponent<Text>().text = "";
        GameObject.Find("Canvas/Image1/C_Button2/Text").GetComponent<Text>().text = "";
        GameObject.Find("Canvas/Image1/C_Button3/Text").GetComponent<Text>().text = "";
    }
}
