using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

    private GameObject canvas;
    public GameObject prefab;
    public int btn_size = 3;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            show_hide();
        }

        GameObject obj = canvas.transform.Find("Image1").gameObject;
        if (obj.activeSelf)
        {
            Dictionary<GameObject, int> bag = GameManager.Instance.getCharacterManager().getBag();
            int i;
            Text txt;
            for (i = 1; i <= btn_size; i++)//清文本
            {
                txt = obj.transform.Find("Image1/C_Button" + i + "/Text").GetComponent<Text>();
                txt.text = "";
            }
            i = 1;
            foreach (KeyValuePair<GameObject, int> item in bag)//背包展现在UI上
            {
                txt = obj.transform.Find("Image1/C_Button" + i + "/Text").GetComponent<Text>();
                txt.text = item.Key.name + ": " + item.Value;
                i++;
            }
        }

    }

    public void show_hide()//显示或隐藏
    {
        GameObject obj = canvas.transform.Find("Image1").gameObject;
        if (obj.activeSelf == true)
            obj.SetActive(false);
        else if (obj.activeSelf == false)
            obj.SetActive(true);
    }

    public void init()
    {
        if (canvas == null)
        {
            canvas = Instantiate(prefab);
            GameObject obj = canvas.transform.Find("Image1").gameObject;
            obj.SetActive(false);
        }
    }

    public GameObject getCanvas()
    {
        return canvas;
    }
}
