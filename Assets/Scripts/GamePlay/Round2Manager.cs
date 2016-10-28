using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Round2Manager : MonoBehaviour {

	/************************
	 * SUMMARY
	 * 
	 * I'm basically gathering each of the districts and doing some crazy math to work out an average.
	 * Feel free to have a go trying to get it to be more sensible because lord knows I can't.
	 * ALL that needs doing really is displaying the results of the election scenes.
	 * 
	 * ********************/

	//public GameObject activePanel;

	[SerializeField]
	private List<GameObject> panels;

	private PlayerResourceManager RS;

	private int totalGlobalAffiliation;

	[SerializeField]
	private List<MapDistricts> districts;

	[SerializeField]
	private Slider affiliationSlider;

	void Start(){
		RS = GameObject.Find ("_PlayerResourcesManager").GetComponent<PlayerResourceManager> ();
		CalcTotalAff ();
	}
		
	void FixedUpdate(){
		affiliationSlider.value = (float)totalGlobalAffiliation / 100;

		//Running Elections up the wazoo
		if (Input.GetKeyUp(KeyCode.A)) {
			foreach (MapDistricts d in districts) {
				StartCoroutine (electionCycle ());
			}
		}
	}

	public void CalcTotalAff(){
		foreach (MapDistricts d in districts) {
			int biz = d.distBizAff/5;
			int civ = d.distCivAff/5;

			int toAdd = biz - (civ -3);

			Debug.Log ("ToAdd is " + toAdd);

			totalGlobalAffiliation += toAdd/3;
		}

		if (totalGlobalAffiliation <= 0) {
			totalGlobalAffiliation = 0;
		}

		if (totalGlobalAffiliation >= 100) {
			totalGlobalAffiliation = 100;
		}

		Debug.Log ("total global affiliation is: " + totalGlobalAffiliation);
	}

	public void activatePanel(GameObject panelToActiv){
		foreach(GameObject i in panels){
			if (panelToActiv.name == i.name) {
				i.SetActive (true);
			} else {
				i.SetActive (false);
			}
		}
	}

	IEnumerator electionCycle(){
		foreach (MapDistricts d in districts) {
			yield return new WaitForSeconds (0.5f);
			d.election ();
			CalcTotalAff ();
		}
	}


}
