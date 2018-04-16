using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

    public int blood = 100;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void init()
    {

    }

    //处理碰撞体碰撞事件
    public bool dealCollision(Collision col)
    {
        Debug.Log(blood);
        string name = col.gameObject.name;

        switch (name)//根据碰撞体名字判断掉血量，或其它事件处理
        {
            case "Sphere001":
            case "Sphere002":
            case "Sphere003":
                blood -= 30;
                break;

            default:
                break;

        }
        Debug.Log(name);
        //判断人物血量是否
        if (blood <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
