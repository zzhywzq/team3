using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour {

    private GameObject RigidBodyFPSController;
    public GameObject prefab;
    public int blood = 100;
    Dictionary<GameObject, int> bag = new Dictionary<GameObject, int>();//键值对数组 <名字，数量>
    public int defend = 5;
    public int jump_high = 5;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void init()
    {
        if (RigidBodyFPSController == null)
        {
            RigidBodyFPSController = Instantiate(prefab);
        }
    }

    public GameObject getRigidBodyFPSController()
    {
        return RigidBodyFPSController;
    }

    public Dictionary<GameObject, int> getBag()
    {
        return bag;
    }

    //处理碰撞体碰撞事件
    public bool dealCollision(Collision col)
    {
        string name = col.gameObject.name;

        switch (name)//根据碰撞体名字判断掉血量，或其它事件处理
        {
            case "Sphere001":
            case "Sphere002":
            case "Sphere003":
                blood -= 30;
                break;

            default:
                break;

        }
        //判断人物血量是否
        if (blood <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void addProp(GameObject prop_name, int prop_num)
    {
        if (bag.ContainsKey(prop_name))
        {
            bag[prop_name] += prop_num;//物品数加一
        }
        else
        {
            bag.Add(prop_name, prop_num);//在字典中添加一个新的物品
        }
    }

    public void useProp(int btn_id)//点下按钮是第几个，给按钮添加脚本后应输入的参数
    {
        ////1. 由于不能直接删除修改字典，所以创建一个存储字典的列表
        //List<string> needChangeList = new List<string>();
        //string[] strArray;//用于截取字符串，创建原对象
        ////2. 场景中创建物品并将字典内容赋值给列表
        //if (bag != null && bag.Count > 0)
        //{
        //    foreach (var item in bag)
        //    {
        //        if (GameObject.Find("Canvas/Image1/C_Button" + btn_id + "/Text").GetComponent<Text>().text.Contains(item.Key))//如果找到拥有此键的
        //        {
        //            strArray = item.Key.name.Split('(');//分割
        //            for (int i = 0; i < item.Value; i++)//创建item.Key对象，数量为item.Value个
        //            {
        //                Instantiate(GameObject.Find(strArray[0]), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3, gameObject.transform.position.z), Quaternion.identity);//xyz次序
        //            }
        //            needChangeList.Add(item.Key.name);
        //        }
        //    }
        //}
        ////3. 对于列表里面存放的物品，将在字典（背包）中删除
        //if (needChangeList.Count > 0)
        //{
        //    foreach (var item in needChangeList)
        //    {
        //        bag.Remove(item);
        //    }
        //}
    }
}
