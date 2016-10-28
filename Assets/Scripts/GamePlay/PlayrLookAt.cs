using UnityEngine;
using System.Collections;

public class PlayrLookAt : MonoBehaviour{

	[SerializeField]
	GameObject canvasLookingAt;

	GameManager gameManager;

	public GameObject collBiz;
	public GameObject collCiv;
	public GameObject collRec;
	public GameObject collMil;
	public GameObject collMed;

	public static bool businessButtonSelected = false;
	public static bool businessRejectedButtonSelected = false;
	public static bool civilButtonSelected = false;
	public static bool civilRejectedButtonSelected = false;
	public static bool resourcesButtonSelected = false;
	public static bool resourcesRejectedButtonSelected = false;
	public static bool militaryButtonSelected = false;
	public static bool militaryRejectedButtonSelected = false;
	public static bool mediaButtonSelected = false;
	public static bool mediaRejectedButtonSelected = false;
	public static int optionsSelected=0;


	void Start(){
		gameManager = GameObject.Find("_GameManager").GetComponent<GameManager>();

		//collBiz = GameObject.Find("/_Benefactors/BusinessGiimbal/Business");
		//collCiv = GameObject.Find("/_Benefactors/CivilGiimbal/Civil");
		//collRec = GameObject.Find("/_Benefactors/ResourcesGiimbal/Resources");
		//collMil = GameObject.Find("/_Benefactors/MilitaryGiimbal/Military");
		//collMed = GameObject.Find("/_Benefactors/MediaGiimbal/Media");
	}

	void Update(){
		addToOptionsSelected();
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
					collBiz.tag = "Untagged";
					businessButtonSelected = true;
				}

			} else if (hit.collider.tag == "CivilButton") {
				if (Input.GetMouseButtonUp(0)) {
					Debug.Log ("PRESSED A CIVIL BOTTON");
					toggleCivilBool();
					collCiv.tag = "Untagged";
					civilButtonSelected = true;
				}
			} else if (hit.collider.tag == "ResourcesButton") {
				if (Input.GetMouseButtonUp(0)) {
					Debug.Log ("PRESSED A RESOURCES BOTTON");
					toggleResourcesBool();
					collRec.tag = "Untagged";
					resourcesButtonSelected = true;
				}
			} else if (hit.collider.tag == "MilitaryButton") {
				if (Input.GetMouseButtonUp(0)) {
					Debug.Log ("PRESSED A MILITARY BOTTON");
					toggleMilitaryBool();
					collMil.tag = "Untagged";
					militaryButtonSelected = true;
				}
			} else if (hit.collider.tag == "MediaButton") {
				if (Input.GetMouseButtonUp(0)) {
					Debug.Log ("PRESSED A MEDIA BOTTON");
					toggleMediaBool();
					collMed.tag = "Untagged";
					mediaButtonSelected = true;
				}
			} else if (hit.collider.tag == "DistrictPolitician") {
				if (Input.GetMouseButtonUp(0)) {
					Debug.Log ("PRESSED A POLITICIAN BOTTON");
					toggleDistrictPoliticiansBool();
				}
			} else if (hit.collider.tag == "MediaRejectButton") {
				if (Input.GetMouseButtonUp(0)) {
					collMed.tag = "Untagged";
					mediaRejectedButtonSelected = true;
					PlayerResourceManager.mediaLight.SetActive (false);
				}
			} else if (hit.collider.tag == "MilitaryRejectButton") {
				if (Input.GetMouseButtonUp(0)) {
					collMil.tag = "Untagged";
					militaryRejectedButtonSelected = true;
					PlayerResourceManager.militaryLight.SetActive (false);
				}
			} else if (hit.collider.tag == "RecourcesRejectButton") {
				if (Input.GetMouseButtonUp(0)) {
					collRec.tag = "Untagged";
					resourcesRejectedButtonSelected = true;
					PlayerResourceManager.resourcesLight.SetActive (false);
				}
			} else if (hit.collider.tag == "CivilRejectButton") {
				if (Input.GetMouseButtonUp(0)) {
					collCiv.tag = "Untagged";
					civilRejectedButtonSelected = true;
					PlayerResourceManager.civilLight.SetActive (false);
				}
			} else if (hit.collider.tag == "BusinessRejectButton") {
				if (Input.GetMouseButtonUp(0)) {
					Debug.Log ("PRESSED A BUSINESS REJECT BOTTON");
					collBiz.tag = "Untagged";
					businessRejectedButtonSelected = true;
					PlayerResourceManager.businessLight.SetActive (false);
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

	void toggleDistrictPoliticiansBool () {
		DistrictPoliticians.offerSelected = true;
	}

	void addToOptionsSelected () {
		if (businessButtonSelected == true) {
			optionsSelected ++;
			Debug.Log("optionsSelected = " + optionsSelected);
			businessButtonSelected = false;
		} else if (businessRejectedButtonSelected == true) {
			optionsSelected ++;
			Debug.Log("optionsSelected = " + optionsSelected);
			businessRejectedButtonSelected = false;
		} else if (civilButtonSelected  == true) {
			optionsSelected ++;
			Debug.Log("optionsSelected = " + optionsSelected);
			civilButtonSelected  = false;
		} else if (civilRejectedButtonSelected  == true){
			optionsSelected ++;
			Debug.Log("optionsSelected = " + optionsSelected);
			civilRejectedButtonSelected  = false;
		} else if (resourcesButtonSelected  == true) {
			optionsSelected ++;
			Debug.Log("optionsSelected = " + optionsSelected);
			resourcesButtonSelected  = false;
		} else if (resourcesRejectedButtonSelected  == true) {
			optionsSelected ++;
			Debug.Log("optionsSelected = " + optionsSelected);
			resourcesRejectedButtonSelected  = false;
		} else if (militaryButtonSelected  == true) {
			optionsSelected ++;
			Debug.Log("optionsSelected = " + optionsSelected);
			militaryButtonSelected  = false;
		} else if (militaryRejectedButtonSelected  == true) {
			optionsSelected ++;
			Debug.Log("optionsSelected = " + optionsSelected);
			militaryRejectedButtonSelected  = false;
		} else if (mediaButtonSelected  == true) {
			optionsSelected ++;
			Debug.Log("optionsSelected = " + optionsSelected);
			mediaButtonSelected  = false;
		} else if (mediaRejectedButtonSelected  == true) {
			optionsSelected ++;
			Debug.Log("optionsSelected = " + optionsSelected);
			mediaRejectedButtonSelected  = false;
		}
	}
}