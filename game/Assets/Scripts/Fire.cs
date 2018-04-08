﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject blast;

    // Use this for initialization使用这来初始化
    void Start()
    {

    }

    // Update is called once per frame逐帧召唤更新一次
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject Camera = GameObject.Find("MainCamera");
            Quaternion camera_rotation = Camera.transform.rotation;
            Vector3 camera_forward = Camera.transform.forward;
            Vector3 pos = gameObject.transform.position;

            //GameObject p = GameObject.Find("Soldier_all_parts");

            GameObject k = Instantiate(blast, pos, camera_rotation);
            k.GetComponent<Rigidbody>().AddForce(camera_forward * 100);
        }
    }
}