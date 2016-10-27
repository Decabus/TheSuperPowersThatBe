using UnityEngine;
using System.Collections;

public class PlayrLookAt : MonoBehaviour{

	[SerializeField]
	GameObject canvasLookingAt;

	GameManager gameManager;

	void Start(){
		gameManager = GameObject.Find("_GameManager").GetComponent<GameManager>();
	}

	void FixedUpdate(){
		if (gameManager.gameState < 1) {
			LookAt ();
		}
	}

	void LookAt(){
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

			if (hit.collider.tag == "BusinessButton") {
				//TODO: Button changes colour on scroll, and on click down.
				if (Input.GetMouseButtonUp(0)) {
					Debug.Log ("PRESSED A BUSINESS BOTTON");
					//TODO: Either return new dialogue or destroy the canvas.
					toggleBusinessBoolOn();
				}
			} else if (hit.collider.tag == "CivilButton") {
				//TODO: Button changes colour on scroll, and on click down.
				if (Input.GetMouseButtonUp(0)) {
					Debug.Log ("PRESSED A CIVIL BOTTON");
					//TODO: Either return new dialogue or destroy the canvas.
					toggleCivilBool();
				}
			} else if (hit.collider.tag == "ResourcesButton") {
				//TODO: Button changes colour on scroll, and on click down.
				if (Input.GetMouseButtonUp(0)) {
					Debug.Log ("PRESSED A RESOURCES BOTTON");
					//TODO: Either return new dialogue or destroy the canvas.
					toggleResourcesBool();
				}
			} else if (hit.collider.tag == "MilitaryButton") {
				//TODO: Button changes colour on scroll, and on click down.
				if (Input.GetMouseButtonUp(0)) {
					Debug.Log ("PRESSED A MILITARY BOTTON");
					//TODO: Either return new dialogue or destroy the canvas.
					toggleMilitaryBool();
				}
			} else if (hit.collider.tag == "MediaButton") {
				if (Input.GetMouseButtonUp(0)) {
					Debug.Log ("PRESSED A MEDIA BOTTON");
					toggleMediaBool();
				}
			}

			if (hit.collider.tag == "CommenceButton") {
				//TODO: Button changes colour on scroll, and on click down.
				if (Input.GetMouseButtonUp(0)) {
					//Debug.Log ("IT BEGINS");
					gameManager.gameState++; 
				}
			}
		}
	}

	void toggleBusinessBoolOn () {
		DisplayBusinessOffer.offerSelected = true;
	}

	void toggleCivilBool () {
		DisplayCivilOffer.offerSelected = true;
	}

	void toggleResourcesBool () {
		DisplayResourcesOffer.offerSelected = true;
	}

	void toggleMilitaryBool () {
		DisplayMilitaryOffer.offerSelected = true;
	}

	void toggleMediaBool () {
		DisplayMediaOffer.offerSelected = true;
	}
}