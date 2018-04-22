using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour {

    private GameObject RigidBodyFPSController;
    public GameObject prefab;
    public GameObject cam;
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
            if (prop_name.StartsWith(item) && bag[item] > 0)
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

    }
}
