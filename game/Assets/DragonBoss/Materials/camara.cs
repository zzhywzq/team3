using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour {

    //private Vector3 offset;
    public Transform player;
    public Vector3 player_forward;
    public Vector3 target_position;

    // Use this for initialization
    void Start () {
        //player_forward = player.transform.forward.normalized;
        //target_position = player.position - player_forward * 15;
    }
	
	// Update is called once per frame
	void Update () {
        player_forward = player.transform.forward.normalized;
        target_position = player.position - player_forward * 15;
        //target_position = player.position + player_forward * 22;
        target_position.y = player.position.y + 8.0f;

        transform.position = Vector3.Lerp(transform.position, target_position, Time.deltaTime * 5);
        transform.LookAt(player.position);
    }
}
