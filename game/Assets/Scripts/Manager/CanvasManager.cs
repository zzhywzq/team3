using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

    private GameObject canvas;
    public GameObject prefab;
    public int bag_num = 3;//有几个背包
    public int bag1_size = 3;//道具背包的有几个按钮
    public int bag2_size = 2;//武器背包的有几个按钮
    public int bag3_size = 1;//防具背包的有几个按钮


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            show_hide();
        }
        update_bag(1);
        update_bag(2);
        update_bag(3);
                GameManager.Instance.getCanvasManager().getCanvas().transform.Find("ButtonDebug/Text").GetComponent<Text>().text = "blood"+ GameManager.Instance.getCharacterManager().blood;

    }

    public void update_bag(int bag_id)
    {
        GameObject obj = canvas.transform.Find("Image"+ bag_id).gameObject;
        if (obj.activeSelf)
        {
            Dictionary<string, int> bag = GameManager.Instance.getCharacterManager().getBag(bag_id);
            int btn_size=0;
            int i;
            Text txt;
            //根据背包编号选择按钮数量
            if (bag_id == 1)
                btn_size = bag1_size;
            else if (bag_id == 2)
                btn_size = bag2_size;
            else if (bag_id == 3)
                btn_size = bag3_size;
            //清文本
            for (i = 1; i <= btn_size; i++)
            {
                txt = obj.transform.Find("Button" + i + "/Text").GetComponent<Text>();
                txt.text = "";
            }
            i = 1;
            foreach (KeyValuePair<string, int> item in bag)//背包展现在UI上
            {
                txt = obj.transform.Find("Button" + i + "/Text").GetComponent<Text>();
                txt.text = item.Key + ": " + item.Value;
                i++;
            }
        }

    }

    public void show_hide()//显示或隐藏
    {
        GameObject obj = canvas.transform.Find("Image1").gameObject;
        if (obj.activeSelf == true)
        {
            canvas.transform.Find("Image1").gameObject.SetActive(false);
            canvas.transform.Find("Image2").gameObject.SetActive(false);
            canvas.transform.Find("Image3").gameObject.SetActive(false);

        }
        else if (obj.activeSelf == false)
        {
            canvas.transform.Find("Image1").gameObject.SetActive(true);
            canvas.transform.Find("Image2").gameObject.SetActive(true);
            canvas.transform.Find("Image3").gameObject.SetActive(true);
        }
    }

    public void init()
    {
        if (canvas == null)
        {
            canvas = Instantiate(prefab);
            //初始化三个背包的贴图
            GameObject Image1 = canvas.transform.Find("Image1").gameObject;
            Image1.SetActive(false);
            GameObject Image2 = canvas.transform.Find("Image2").gameObject;
            Image2.SetActive(false);
            GameObject Image3 = canvas.transform.Find("Image3").gameObject;
            Image3.SetActive(false);
            //初始化背包1的按钮，3个
            Button Image1_Button1 = Image1.transform.Find("Button1").gameObject.GetComponent<Button>();
            Image1_Button1.onClick.AddListener(delegate { GameManager.Instance.getCharacterManager().useProp(Image1_Button1.transform.Find("Text").GetComponent<Text>().text,1); });
            Button Image1_Button2 = Image1.transform.Find("Button2").gameObject.GetComponent<Button>();
            Image1_Button2.onClick.AddListener(delegate { GameManager.Instance.getCharacterManager().useProp(Image1_Button2.transform.Find("Text").GetComponent<Text>().text,1); });
            Button Image1_Button3 = Image1.transform.Find("Button3").gameObject.GetComponent<Button>();
            Image1_Button3.onClick.AddListener(delegate { GameManager.Instance.getCharacterManager().useProp(Image1_Button3.transform.Find("Text").GetComponent<Text>().text,1); });
            //初始化背包2的按钮，2个
            Button Image2_Button1 = Image2.transform.Find("Button1").gameObject.GetComponent<Button>();
            Image2_Button1.onClick.AddListener(delegate { GameManager.Instance.getCharacterManager().useProp(Image2_Button1.transform.Find("Text").GetComponent<Text>().text, 2); });
            Button Image2_Button2 = Image2.transform.Find("Button2").gameObject.GetComponent<Button>();
            Image2_Button2.onClick.AddListener(delegate { GameManager.Instance.getCharacterManager().useProp(Image2_Button2.transform.Find("Text").GetComponent<Text>().text, 2); });
            //初始化背包3的按钮，1个
            Button Image3_Button1 = Image3.transform.Find("Button1").gameObject.GetComponent<Button>();
            Image3_Button1.onClick.AddListener(delegate { GameManager.Instance.getCharacterManager().useProp(Image3_Button1.transform.Find("Text").GetComponent<Text>().text, 3); });
        }
    }

    public GameObject getCanvas()
    {
        return canvas;
    }
}
