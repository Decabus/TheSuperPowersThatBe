using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapDistricts : MonoBehaviour{

	[SerializeField]
	GameObject panel;

	[SerializeField]
	GameObject districtMesh;

	void OnMouseOver(){
		panel.SetActive (true);
		//panel.GetComponent<Image> ().enabled = true;
		districtMesh.GetComponent<Renderer> ().material.color = new Color (1.0f, 0.1f, 0.1f);
	}

	void OnMouseExit(){
		panel.SetActive (false);
		districtMesh.GetComponent<Renderer> ().material.color = new Color (1.0f, 1.0f, 1.0f);
	}
}