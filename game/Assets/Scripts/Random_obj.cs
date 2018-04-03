using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_obj : MonoBehaviour
{
    public GameObject[] obj;//存放unity拖拽进来的模型，用于随机生成
    public int item_num;//生成物品数 
    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < item_num; i++)
        {
            Instantiate(obj[Random.Range(0,obj.Length)], new Vector3(Random.Range(1105f,1185f), 20, Random.Range(1069f, 1180f)), Quaternion.identity);//xyz次序
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
