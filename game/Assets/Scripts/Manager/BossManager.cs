using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour {

    private GameObject Boss;
    public GameObject prefab;

    public void init()
    {
        if (Boss == null)
        {
            Boss = Instantiate(prefab);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject getBoss()
    {
        return Boss;
    }

}
