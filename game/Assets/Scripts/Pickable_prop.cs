using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickable_prop : MonoBehaviour {
    // Use this for initialization
    void Start () {

    }
    // Update is called once per frame
    void Update () {

	}
    void OnCollisionEnter(Collision col)//将这个脚本添加给物体X，参数col是与物体X产生碰撞的对象
    {
        string name = col.gameObject.name;
        if (name.Contains("RigidBodyFPSController") && Input.GetKey(KeyCode.F) )//如果检测到物体X是人物  并且 玩家按下F
        {
            GameObject.Find("Soldier_all_parts").GetComponent<Soldier>().add_prop(gameObject.name, 1);//给soldier的bag添加物品
            Destroy(gameObject);//消除地面上的物品
        }
        //另一种方法：将脚本添加给人物Y，检测碰撞体的tag是item_tag
    }
}
