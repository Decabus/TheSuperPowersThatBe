using UnityEngine;
using System.Collections;

public class SpeechBubble : MonoBehaviour{

	Transform player;

	//Use this for initialization 
	void Start(){
		player = GameObject.Find ("Main Camera").transform;
	}

	//Update is called once per frame
	void FixedUpdate(){
		//transform.LookAt (player);
	}
}