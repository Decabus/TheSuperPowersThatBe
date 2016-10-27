using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapDistricts : MonoBehaviour{

	public int districtAffiliation;

	private int distBizAff;
	private int distCivAff;

	[SerializeField]
	GameObject panel;

	[SerializeField]
	GameObject districtMesh;

	Round2Manager r2M;

	void Start(){
		r2M = GameObject.Find ("Stage2Canvas").GetComponent<Round2Manager> ();

		districtAffiliation = Random.Range (30, 60);

		distBizAff = districtAffiliation;
		distCivAff = 100 - districtAffiliation;
		//Debug.Log (this.name + ": " + distBizAff + "% Biz, " + distCivAff + "% Civ.");
	}

	void OnMouseOver(){
		//panel.SetActive (true);
		//panel.GetComponent<Image> ().enabled = true;
		districtMesh.GetComponent<Renderer> ().material.color = new Color (1.0f, 0.1f, 0.1f);
		if (Input.GetMouseButtonUp (0)) {
			r2M.activatePanel (panel);
		}
	}

	void OnMouseExit(){
		//panel.SetActive (false);
		districtMesh.GetComponent<Renderer> ().material.color = new Color (1.0f, 1.0f, 1.0f);
	}
}