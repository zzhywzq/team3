using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_ctrl_script : MonoBehaviour {
    public Animator anim;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            this.anim.SetInteger("anim_state", 1);//人物状态
            GameObject obj = GameManager.Instance.getCharacterManager().getRigidBodyFPSController().transform.Find("MainCamera").gameObject;//相机是可以找到的
            obj.transform.localPosition = new Vector3(0, 0.4f, 0);//修改放在start函数里可以修改
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            this.anim.SetInteger("anim_state", 0);
            GameObject obj = GameManager.Instance.getCharacterManager().getRigidBodyFPSController().transform.Find("MainCamera").gameObject;//相机是可以找到的
            obj.transform.localPosition = new Vector3(0, 0.6f, 0);//修改放在start函数里可以修改
        }


        if (!Input.GetKey(KeyCode.W)&& !Input.GetKey(KeyCode.S)&& !Input.GetKey(KeyCode.A)&& !Input.GetKey(KeyCode.D))
        {
            this.anim.SetInteger("move_state", 0);
                
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.anim.SetInteger("move_state", 1);//移动状态
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.anim.SetInteger("move_state", 2);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.anim.SetInteger("move_state", 3);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.anim.SetInteger("move_state", 4);
        }

    }
}
