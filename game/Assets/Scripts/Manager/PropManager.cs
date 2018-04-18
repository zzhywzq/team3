using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager : MonoBehaviour {

    public GameObject[] obj;//存放unity拖拽进来的模型，用于随机生成
    public int item_num;//生成物品数 

    private List<GameObject> all_prop = new List<GameObject>();

    public void init()
    {
        for (int i = 0; i < item_num; i++)
        {
            Vector3 v3 = new Vector3(Random.Range(1105f, 1185f), 20, Random.Range(1069f, 1180f));
            GameObject go = Instantiate(obj[Random.Range(0, obj.Length)], v3, Quaternion.identity);//xyz次序
            all_prop.Add(go);
        }
    }

    public void addProp(GameObject go, Vector3 v3)
    {
        GameObject temp = Instantiate(go, v3, Quaternion.identity);//xyz次序
        all_prop.Add(temp);
    }

    public void removeProp(GameObject go)
    {
        all_prop.Remove(go);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
