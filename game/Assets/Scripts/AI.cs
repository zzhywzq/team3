using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    private GameObject player;

    #region variable  
    [SerializeField] //保护封装性  
    private float speed = 15f;
    [SerializeField]
    private GameObject targetPoint;
    #endregion

    // Use this for initialization  
    void Start()
    {
       
        player = GameManager.characterManager.getRigidBodyFPSController();
        StartCoroutine(AINavMesh());
    }

    IEnumerator AINavMesh()
    {
        Vector3 dir;
        yield return new WaitForSeconds(1f);
        while (true)
        {
            if (Vector3.Distance(transform.position, targetPoint.transform.position) >= 1f)
            {
                TowardToTargetAndRun(targetPoint.transform.position);
                dir = targetPoint.transform.position - transform.position;
                transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
            }
            else
            {
                
                GetComponent<Animation>().Play("idle");
            }
            if (player != null && Vector3.Distance(transform.position, player.gameObject.transform.position) <= 22f) //最大26.5
            {
                //Debug.Log("侦测到敌人，开始追击！！！");
                yield return StartCoroutine(AIFollowHero());

                TowardToTargetAndRun(targetPoint.transform.position);
                dir = targetPoint.transform.position - transform.position;
                transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
            }
           
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
