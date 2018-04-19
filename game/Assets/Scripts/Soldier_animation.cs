﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_animation : MonoBehaviour
{
    Animation m_anim;//控制人物动作
    GameObject obj;
    Camera m_camera;
    //private Transform m_Transform;//用于调转人物方向
    // 初始化
    void Start()
    {
        m_anim = GetComponent<Animation>();
        obj= GameManager.Instance.getCharacterManager().getRigidBodyFPSController();
        m_camera= obj.GetComponentInChildren<Camera>();
        //m_Transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() { }
    //键盘监听控制人物
    //当任务按住上或下执行前进或后退动作，同时按住左键或右键使调转人物朝向（按F 键时人物下蹲，可用于捡东西）
    void OnGUI()
    {
        //按F键下蹲
        if (Input.GetKeyDown(KeyCode.F))
        {
            m_anim.CrossFade("crouch_idle", 0.2f);
            m_camera.transform.position.Set(0,0,0);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            m_anim.CrossFade("combat_idle_aim", 0.2f);
            m_camera.transform.position.Set(0, 0.6f, 0);
        }
        //W键或者上方向键按下的时候让人物前进
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_anim.CrossFade("combat_run_aim", 0.2f);
        }
        //S键或者下方向键按下的时候让人物后退
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_anim.CrossFade("run_aim_back", 0.2f);
        }

        //A键或者左方向键按下的时候将人物向左移动
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            m_anim.CrossFade("run_aim_strafe_left", 0.2f);
        }

        //D键或者右方向键按下的时候将人物向右移动
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            m_anim.CrossFade("run_aim_strafe_right", 0.2f);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            m_anim.CrossFade("run_aim_forward_left", 0.2f);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            m_anim.CrossFade("run_aim_forward_right", 0.2f);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            m_anim.CrossFade("run_aim_back_left", 0.2f);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            m_anim.CrossFade("run_aim_back_right", 0.2f);
        }

        //W键、S键或者上方向、下方向键抬起的时候执行idle动画
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            m_anim.CrossFade("combat_idle_aim", 0.2f);
        }
    }
}




