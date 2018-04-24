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
		if(Input.GetKeyDown(KeyCode.F))
            this.anim.SetInteger("anim_state", 1);//人物状态
        if (Input.GetKeyDown(KeyCode.G))
            this.anim.SetInteger("anim_state", 0);

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            this.anim.SetInteger("move_state", 0);
        }
        if (this.anim.GetInteger("move_state") != 0) return;
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.anim.SetInteger("move_state", 1);//移动状态
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.anim.SetInteger("move_state", 2);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.anim.SetInteger("move_state", 3);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            this.anim.SetInteger("move_state", 4);
        }
        
    }
}
