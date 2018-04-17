using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject blast;//子弹
    public GameObject bag_img;//背包图片

    // Use this for initialization使用这来初始化
    void Start()
    {

    }

    // Update is called once per frame逐帧召唤更新一次
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)/* && !bag_img.activeSelf*/)//鼠标按下，并且 背包是隐藏状态
        {
            GameObject Camera = GameObject.Find("MainCamera");
            Quaternion camera_rotation = Camera.transform.rotation;
            Vector3 camera_forward = Camera.transform.forward;
            Vector3 pos = gameObject.transform.position;
            

            GameObject k = Instantiate(blast, pos, camera_rotation);
            int curGun = gameObject.GetComponentInParent<GunControl>().getCurrentGun();
            //Debug.Log(curGun);
            switch (curGun)
            {
                case 0:
                    k.GetComponent<Forward>().timetodestroy = 2;
                    k.GetComponent<Rigidbody>().AddForce(camera_forward * 100);
                    break;
                case 1:
                    k.GetComponent<Forward>().timetodestroy = 0.14f;
                    k.GetComponent<Rigidbody>().AddForce(camera_forward * 200);
                    break;
                case 2:
                    k.GetComponent<Forward>().timetodestroy = 1;
                    k.GetComponentInParent<Rigidbody>().mass = 0.5f;
                    k.GetComponent<Rigidbody>().AddForce(camera_forward * 250);
                    break;
                case 3:
                    k.GetComponent<Forward>().timetodestroy = 2;
                    k.GetComponent<Rigidbody>().AddForce(camera_forward * 100);
                    break;
            }
        }
    }
}