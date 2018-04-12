using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    public float timetodestroy;

    // Use this for initialization使用它来初始化
    void Start()
    {

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

    void OnCollisionEnter(Collision col)
    {
        string name = col.gameObject.name;
        if (name.Contains("Soldier") || name.Contains("Mesh") || name.Contains("Barre") || name.Contains("box"))
        {
            Destroy(this.gameObject);
        }

    }
}