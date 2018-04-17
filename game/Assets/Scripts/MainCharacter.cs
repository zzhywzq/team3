using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        CharacterManager cm = GameManager.Instance.getCharacterManager();
        bool isAlive = cm.dealCollision(col);//交由角色管理器处理
        if (!isAlive)
        {
            Destroy(this.gameObject);//人物死亡处理。目前销毁相机，后期跳转场景
        }

    }
}
