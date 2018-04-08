using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour {

    Dictionary<string, int> bag =  new Dictionary<string, int>();
    //键值对数组 <名字，数量>

    public int defend = 5;
    public int jump_high = 5;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Dictionary<string, int> get_bag()
    {
        return bag;
    }

    public void add_prop(string prop_name, int prop_num)
    {
        if (bag.ContainsKey(prop_name))
        {
            bag[prop_name] += prop_num;//物品数加一
        }
        else
        {
            bag.Add(prop_name, prop_num);
        }
    }

    //public bool use_prop(string prop_name, int prop_num)
    //{
    //    if (bag.ContainsKey(prop_name))
    //    {
    //        if (bag[prop_name] >= prop_num)
    //        {
    //            bag[prop_name] -= prop_num;
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

}
