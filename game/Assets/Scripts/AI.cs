using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    #region variable  
    [SerializeField] //保护封装性  
    private float speed = 20f;
    [SerializeField]
    private WayPoint targetPoint, startPoint;
    [SerializeField]
    private GameObject player;

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

        TowardToTargetAndRun(targetPoint.transform.position);

        StartCoroutine(AINavMesh());
    }

    IEnumerator AINavMesh()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, targetPoint.transform.position) < 1.5f)
            {
                //AIAttack aa = GetComponent<AIAttack>();
                //aa.Att();
                //yield return new WaitForSeconds(3.2f);

                targetPoint = targetPoint.nextWayPoint;
                yield return new WaitForSeconds(0.1f);

                TowardToTargetAndRun(targetPoint.transform.position);
            }

            if (player != null && Vector3.Distance(transform.position, player.gameObject.transform.position) <= 22f) //最大26.5
            {
                //Debug.Log("侦测到敌人，开始追击！！！");
                yield return StartCoroutine(AIFollowHero());

                TowardToTargetAndRun(targetPoint.transform.position);
            }

            Vector3 dir = targetPoint.transform.position - transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
            //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPoint.transform.position, Time.deltaTime * speed);

            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator AIFollowHero()
    {
        while (true)
        {
            if (player != null && Vector3.Distance(transform.position, player.gameObject.transform.position) > 22f)
            {
                //Debug.Log("敌人已走远，放弃攻击！！！");
                yield break;
            }

            if (player != null && Vector3.Distance(transform.position, player.gameObject.transform.position) <= 10f) //最远距离16
            {
                AIAttack aa = GetComponent<AIAttack>();
                aa.Att();
                yield return new WaitForSeconds(3.2f);
            }

            TowardToTargetAndRun(player.transform.position);

            Vector3 dir = player.transform.position - transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * speed * 0.8f, Space.World);
            yield return new WaitForEndOfFrame();
        }
    }

    private void TowardToTargetAndRun(Vector3 position)
    {
        transform.LookAt(position);
        GetComponent<Animation>().Play("run");
    }

}
