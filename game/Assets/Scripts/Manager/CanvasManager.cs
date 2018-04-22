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
            Dictionary<string, int> bag = GameManager.Instance.getCharacterManager().getBag();
            int i;
            Text txt;
            for (i = 1; i <= btn_size; i++)//清文本
            {
                txt = obj.transform.Find("C_Button" + i + "/Text").GetComponent<Text>();
                txt.text = "";
            }
            i = 1;
            foreach (KeyValuePair<string, int> item in bag)//背包展现在UI上
            {
                txt = obj.transform.Find("C_Button" + i + "/Text").GetComponent<Text>();
                txt.text = item.Key + ": " + item.Value;
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
            GameObject Image1 = canvas.transform.Find("Image1").gameObject;
            Image1.SetActive(false);
            Button CButton1 = Image1.transform.Find("C_Button1").gameObject.GetComponent<Button>();
            CButton1.onClick.AddListener(delegate { GameManager.Instance.getCharacterManager().useProp(CButton1.transform.Find("Text").GetComponent<Text>().text); });
            Button CButton2 = Image1.transform.Find("C_Button2").gameObject.GetComponent<Button>();
            CButton2.onClick.AddListener(delegate { GameManager.Instance.getCharacterManager().useProp(CButton2.transform.Find("Text").GetComponent<Text>().text); });
            Button CButton3 = Image1.transform.Find("C_Button3").gameObject.GetComponent<Button>();
            CButton3.onClick.AddListener(delegate { GameManager.Instance.getCharacterManager().useProp(CButton3.transform.Find("Text").GetComponent<Text>().text); });

        }
    }

    public GameObject getCanvas()
    {
        return canvas;
    }
}
