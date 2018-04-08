using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_attack_destroy : MonoBehaviour {

    private float timetodestroy;

    // Use this for initialization使用它来初始化
    void Start()
    {
        //GameObject.rigidbody.constantForce游戏对象、刚体、恒力
        timetodestroy = 2.5f;
    }

    // Update is called once per frame逐帧召唤更新一次
    void Update()
    {
        timetodestroy = timetodestroy - Time.deltaTime;
        //gameObject.transform.position += transform.forward * Time.deltaTime * 30;
        if (timetodestroy < 0)
        {
            Destroy(gameObject);
        }
    }

}
