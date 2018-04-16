using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager _instance;
    public static BossManager bossManager;
    public static PropManager propManager;
    public static CharacterManager characterManager;

    private static void init()
    {
        if (null == _instance)
        {
            _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
        }
        if (null == bossManager)
        {
            bossManager = FindObjectOfType(typeof(BossManager)) as BossManager;
        }
        if (null == propManager)
        {
            propManager = FindObjectOfType(typeof(PropManager)) as PropManager;
        }
        if (null == characterManager)
        {
            characterManager = FindObjectOfType(typeof(CharacterManager)) as CharacterManager;
        }
    }

    void Start()
    {
        init();
        bossManager.init();
        propManager.init();
        characterManager.init();
    }

    public static GameManager Instance
    {
        get
        {
            init();
            return _instance;
        }
    }

    private void Awake()
    {

    }
    
    public BossManager getBossManager()
    {
        return bossManager;
    }
    
    public PropManager getPropManager()
    {
        return propManager;
    }
    
    public CharacterManager getCharacterManager()
    {
        return characterManager;
    }

}
