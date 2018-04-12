using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : MonoBehaviour {

    //public GameObject mouth;
    //public GameObject attack_fire;
    private GameObject fire_effect;
    private Vector3 local_pos;

	// Use this for initialization
	void Start () {
        // 加载火焰特效
        fire_effect = Resources.Load("DragonEffect_001") as GameObject;
        
        // 火焰特效与龙的相对坐标
        local_pos = new Vector3(-3.267612f, -1.05427f, 14.97258f);
        //local_pos = transform.InverseTransformPoint(attack_fire.transform.position);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(Attack());
        }
    }

    public void Att()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        GetComponent<Animation>().Play("breath fire");     
        yield return new WaitForSeconds(0.5f);

        //pos.x -= 3.28f;
        //pos.y -= 5.63f;
        //pos.z += 3.28f;

        // 转化为 相对于龙位置的绝对坐标
        GameObject f = Instantiate(fire_effect, transform.TransformPoint(local_pos), transform.rotation);
        //GameObject f = Instantiate(attack_fire);

        //yield return new WaitForSeconds(2.01f);
        //Destroy(ff);
        //ff = null;
    }
}
