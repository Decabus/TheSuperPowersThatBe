﻿using UnityEngine;
using System.Collections;

public class PlayrLookAt : MonoBehaviour{

	[SerializeField]
	GameObject canvasLookingAt;

	void FixedUpdate(){
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		RaycastHit hit;

		if (Physics.Raycast (transform.position, fwd, out hit, 100.0f)) {
			Debug.DrawLine (this.transform.position, hit.point);
			if (hit.collider.tag == "Benefactor") {
				canvasLookingAt = hit.transform.GetChild (0).gameObject;
				canvasLookingAt.SetActive (true);
			} else if(hit.collider.tag == "Untagged"){
				if (canvasLookingAt != null) {
					canvasLookingAt.SetActive (false);
				}
			}

			if (hit.collider.tag == "Button") {
				//TODO: Button changes colour on scroll, and on click down.
				if (Input.GetMouseButtonUp(0)) {
					Debug.Log ("PRESSED A BOTTON");
					//TODO: Either return new dialogue or destroy the canvas. 
				}
			}
		}
	}
}