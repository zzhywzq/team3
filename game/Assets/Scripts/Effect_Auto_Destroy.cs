using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Auto_Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Des());

    }

    IEnumerator Des()
    {
        yield return new WaitForSeconds(2.65f);
        Destroy(this.gameObject);
    }
}
