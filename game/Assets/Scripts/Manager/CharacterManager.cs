using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour {

    private GameObject RigidBodyFPSController;
    public GameObject prefab;
    public int blood = 100;
    Dictionary<string, int> bag = new Dictionary<string, int>();//键值对数组 <名字，数量>
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

    public Dictionary<string, int> getBag()
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
        //判断人物血量
        if (blood <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void addProp(string prop, int prop_num)
    {
        if (bag.ContainsKey(prop))
        {
            bag[prop] += prop_num;//物品数加一
        }
        else
        {
            bag.Add(prop, prop_num);//在字典中添加一个新的物品
        }
    }

    public void useProp(string prop_name)//点下按钮是第几个，给按钮添加脚本后应输入的参数
    {
        GameObject p = RigidBodyFPSController;
        foreach (string item in bag.Keys)
        {
            if (item.StartsWith(prop_name) && bag[item] > 0)
            {
                GameObject prefab = null;
                switch (item)
                {
                    case "Cube1(Clone)":
                        prefab = GameManager.Instance.getPropManager().obj[0];
                        break;
                    case "Cube2(Clone)":
                        prefab = GameManager.Instance.getPropManager().obj[1];
                        break;
                    case "Cube3(Clone)":
                        prefab = GameManager.Instance.getPropManager().obj[2];
                        break;
                }
                GameManager.Instance.getPropManager().addProp(prefab, new Vector3(p.transform.position.x, p.transform.position.y + 3, p.transform.position.z));
                bag[item]--;
                if (bag[item] <= 0)
                {
                    bag.Remove(item);
                }
            }
        }

        ////1. 由于不能直接删除修改字典，所以创建一个存储字典的列表
        //List<string> needChangeList = new List<string>();
        //string[] strArray;//用于截取字符串，创建原对象
        ////2. 场景中创建物品并将字典内容赋值给列表
        //if (bag != null && bag.Count > 0)
        //{
        //    foreach (var item in bag)
        //    {
        //        if (GameManager.Instance.getCanvasManager().getCanvas().transform.Find("Image1/C_Button" + btn_id + "/Text").GetComponent<Text>().text.Contains(item.Key.name))//如果找到拥有此键的
        //        {
        //            strArray = item.Key.name.Split('(');//分割
        //            for (int i = 0; i < item.Value; i++)//创建item.Key对象，数量为item.Value个
        //            {
                        
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
