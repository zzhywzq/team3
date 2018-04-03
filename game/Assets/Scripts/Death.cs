using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int blood = 100;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("Sphere") && !col.gameObject.name.Contains("SphereFromMain"))
        {
            blood -= 30;
            if (blood <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
