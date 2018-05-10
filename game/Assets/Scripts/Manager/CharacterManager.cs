using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour {

    private GameObject RigidBodyFPSController;
    public GameObject prefab;
    public int blood = 100;
    Dictionary<string, int> bag1 = new Dictionary<string, int>();//键值对数组 <名字，数量>
    Dictionary<string, int> bag2 = new Dictionary<string, int>();//键值对数组 <名字，数量>
    Dictionary<string, int> bag3 = new Dictionary<string, int>();//键值对数组 <名字，数量>

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

    public Dictionary<string, int> getBag(int bag_id)
    {
        Dictionary<string, int> bag = new Dictionary<string, int>(); 
        if (bag_id == 1)
            bag= bag1;
        else if (bag_id == 2)
            bag= bag2;
        else if (bag_id == 3)
            bag= bag3;
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

    public bool addProp(string prop, int prop_num,int prop_type)
    {
        Dictionary<string, int> bag = new Dictionary<string, int>();
        bag = getBag(prop_type);
        switch (prop_type)
        {
            case 1://如果是道具
                if (bag.ContainsKey(prop))//判断背包里有没有这个东西，如果有
                {
                    bag[prop] += prop_num;//物品数加一
                }
                else//如果没有
                {
                    bag.Add(prop, prop_num);//在字典中添加一个新的物品
                }
                 break;
            case 2://如果是武器
                if (bag.ContainsKey(prop))//判断背包2是不是有这把枪，如果背包2已有这把枪
                {
                    return false;//不能再捡起了
                                 //GameManager.Instance.getCharacterManager().useProp(prop, 2);
                                 //bag.Add(prop, prop_num);//在字典中添加一个新的物品
                }
                else//如果没
                {
                    bag.Add(prop, prop_num);//在字典中添加一个新的物品
                }
                break;
            case 3://如果是armor
                if (bag.ContainsKey(prop))//判断背包里有没有armor，如果有
                {
                    return false;
                }
                else//如果没有
                {
                    bag.Add(prop, prop_num);//在字典中添加一个新的物品
                    defend = 10;
                }
                break;
        }

        return true;
    }

    public void useProp(string prop_name,int bag_id)//点下按钮是第几个，给按钮添加脚本后应输入的参数
    {
        GameObject p = RigidBodyFPSController;
        Dictionary<string, int> bag = new Dictionary<string, int>();
        bag = getBag(bag_id);
        foreach (string item in bag.Keys)
        {
            if (prop_name.StartsWith(item) && bag[item] > 0)
            {
                GameObject prefab = null;
                switch (item)
                {
                    case "M_Armor_C_01(Clone)":
                        defend = 5;
                        prefab = GameManager.Instance.getPropManager().obj[0];
                        GameManager.Instance.getPropManager().addProp(prefab, new Vector3(p.transform.position.x, p.transform.position.y + 3, p.transform.position.z));
                        break;
                    case "m4a1(Clone)":
                        prefab = GameManager.Instance.getPropManager().obj[1];
                        GameManager.Instance.getPropManager().addProp(prefab, new Vector3(p.transform.position.x, p.transform.position.y + 3, p.transform.position.z));
                        break;
                    case "M249saw(Clone)":
                        prefab = GameManager.Instance.getPropManager().obj[2];
                        GameManager.Instance.getPropManager().addProp(prefab, new Vector3(p.transform.position.x, p.transform.position.y + 3, p.transform.position.z));
                        break;
                    case "Drink(Clone)":
                        if (blood <= 99)
                            blood = blood + 1;
                        else if (blood > 99)
                            blood = 100;
                        break;
                    case "emergencyBangadeBig(Clone)":
                        if (blood <= 90)
                            blood = blood + 10;
                        else if (blood > 90)
                            blood = 100;
                        break;
                    case "FirstAidPackMilitary(Clone)":
                        if(blood<=75)
                            blood = 75;
                        break;                }
                bag[item]--;
                if (bag[item] <= 0)
                {
                    bag.Remove(item);
                }
            }
        }

    }
}
//        GameManager.Instance.getCanvasManager().getCanvas().transform.Find("ButtonDebug/Text").GetComponent<Text>().text = "bag" + prop_type;

    //debug神句