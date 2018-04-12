using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {
    GunComponent[] gunControllers;
    int index = 0;
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
            if(gunControllers[0].gameObject.activeSelf==true)
                changeGun(gunControllers[1].gameObject);
            else if (gunControllers[1].gameObject.activeSelf == true)
                changeGun(gunControllers[0].gameObject);
        }

    }
    public GameObject changeGun(GameObject g)
    {
        int before = index;
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
    
    public void changeGunById(int i)
    {
        int before = index;
        index = i;
        gunControllers[before].gameObject.SetActive(false);
        gunControllers[index].gameObject.SetActive(true);
    }

    public int getCurrentGun()
    {
        return index;
    }


}
