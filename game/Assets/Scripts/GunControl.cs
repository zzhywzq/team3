using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {
    GunComponent[] gunControllers;
    int index = 0;
	int before = 0;
    // Use this for initialization
    void Start () {
        gunControllers = transform.GetComponentsInChildren<GunComponent>();
        for (int i = 1; i < gunControllers.Length; i++)
        {
            gunControllers[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        //换枪
        if (Input.GetKeyDown(KeyCode.Q))
        {
          changeGun(gunControllers[2].gameObject);
        }

    }
	GameObject getcurrentGun(){
		return gunControllers[index].gameObject;
	}
    GameObject changeGun(GameObject g)
    {
		before=index;
        int i = 0;
        while (gunControllers[i].gameObject.name!=g.name && i < gunControllers.Length)
        {
            i++;
        }
        index = i;
        gunControllers[before].gameObject.SetActive(false);
        gunControllers[index].gameObject.SetActive(true);
        return gunControllers[before].gameObject;
    }

}
