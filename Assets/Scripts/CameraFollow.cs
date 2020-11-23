using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	Vector3 inpos;
	void Start()
{
inpos = transform.position; 
}
     //public float dampTime = 0.1f;
    // private Vector3 velocity = Vector3.zero;
     //public GameObject Weapon;
 
     // Update is called once per frame
     void FixedUpdate () {
/*
     {
	var pos = GameObject.FindWithTag("Player").transform.position;
       
         {
             Vector3 point = GetComponent<Camera>().WorldToViewportPoint(pos);
             Vector3 delta = pos - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
             Vector3 destination = transform.position + delta;
             transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
         }
		*/
		var pos = GameObject.FindWithTag("Player").transform.position;
		transform.position =new Vector3(pos.x+5.0f, pos.y+2.0f, inpos.z);
     
     }
 }

