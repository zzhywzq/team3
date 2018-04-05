using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Click : MonoBehaviour {
    GameObject soldier;//士兵
    public string soldier_name;//士兵名字，参数
    Dictionary<string, int> bag;
    public string btn_name;//点下按钮的名字，参数
    GameObject btn;//按钮
    Text text;//按钮的文本
    public GameObject obj;//unity拖进来的物品，参数
    // Use this for initialization
    void Start () {
        soldier = GameObject.Find(soldier_name);
        bag = soldier.GetComponent<Soldier>().get_bag();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Item_OnClick() {
        btn = GameObject.Find(btn_name);
        text = btn.transform.GetComponentInChildren<Text>();
        text.text = "";
        Dictionary<string, int> bag = soldier.GetComponent<Soldier>().get_bag();
        Instantiate(obj, new Vector3(soldier.transform.localPosition.x, soldier.transform.localPosition.y, soldier.transform.localPosition.z), Quaternion.identity);//xyz次序
        //扔下会捡起来，扔下去的是个白的cube，设为参数
    }
}
