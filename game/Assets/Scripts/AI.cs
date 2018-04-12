using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    #region variable  
    [SerializeField] //保护封装性  
    private float speed = 20f;
    [SerializeField]
    private WayPoint targetPoint, startPoint;
    //[SerializeField]
    //private Hero mage;

    #endregion

    // Use this for initialization  
    void Start()
    {
        if (Vector3.Distance(transform.position, startPoint.transform.position) < 1.5f)
        {
            targetPoint = startPoint.nextWayPoint;
        }
        else
        {
            targetPoint = startPoint;
        }
        transform.LookAt(targetPoint.transform.position);
        GetComponent<Animation>().Play("run");

        StartCoroutine(AINavMesh());
    }

    IEnumerator AINavMesh()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, targetPoint.transform.position) < 1.5f)
            {
                AIAttack aa = GetComponent<AIAttack>();
                aa.Att();
                yield return new WaitForSeconds(3.2f);

                targetPoint = targetPoint.nextWayPoint;
                transform.LookAt(targetPoint.transform.position);

                yield return new WaitForSeconds(0.15f);
                GetComponent<Animation>().Play("run");
            }
            //if (mage != null && Vector3.Distance(transform.position, mage.gameObject.transform.position) <= 6f)
            //{
            //    Debug.Log("侦测到敌人，开始追击！！！");
            //    yield return StartCoroutine(AIFollowHero());
            //}

            Vector3 dir = targetPoint.transform.position - transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
            //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPoint.transform.position, Time.deltaTime * speed);

            yield return new WaitForEndOfFrame();
        }
    }

    /*
    IEnumerator AIFollowHero()
    {
        while (true)
        {
            if (mage != null && Vector3.Distance(transform.position, mage.gameObject.transform.position) > 6f)
            {
                Debug.Log("敌人已走远，放弃攻击！！！");
                yield break;
            }
            Vector3 dir = mage.transform.position - transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * speed * 0.8f);
            yield return new WaitForEndOfFrame();
        }
    }
    */
}
