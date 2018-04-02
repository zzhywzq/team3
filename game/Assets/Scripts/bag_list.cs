using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bag_list : MonoBehaviour {

    public GameObject soldire;
	// Use this for initialization
	void Start () {
        soldire = GameObject.Find("Soldier_all_parts");//.GetComponent<Soldier>().add_prop("枪", 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void show_bag_list()
    {
        Dictionary<string, int> bag = soldire.GetComponent<Soldier>().get_bag();
        Text text = gameObject.GetComponent<Text>();
        text.text = "";
        foreach (KeyValuePair<string ,int> item in bag)
        {
            text.text += "物品：" + item.Key + "    数量：" + item.Value + "\r\n";
        }
    }
}
