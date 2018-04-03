using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_attack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public GameObject blast;
    private long lastt;
    // Update is called once per frame
    void Update () {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        long t = Convert.ToInt64(ts.TotalSeconds);
        if (t % 2 == 0 && t != lastt)
        {
            lastt = t;
            Vector3 pos = gameObject.transform.position;
            pos.x -= 2.25f;
            pos.y -= 1.5f;
            pos.z += 2f;
            GameObject k = Instantiate(blast, pos, gameObject.transform.rotation);
        }
    }
}
