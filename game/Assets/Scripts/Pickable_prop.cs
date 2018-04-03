using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable_prop : MonoBehaviour {

    public string prop_id = "";
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        string name = col.gameObject.name;
        Debug.Log(name);
        if (name.Contains("RigidBodyFPSController"))
        {
            GameObject.Find("Soldier_all_parts").GetComponent<Soldier>().add_prop(prop_id,1);
            Destroy(gameObject);
        }
    }
}
