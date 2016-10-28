using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIDistricts : MonoBehaviour{

	[SerializeField]
	GameObject infoTab;

	[SerializeField]
	GameObject actionsTab;

	[SerializeField]
	GameObject candidatesTab;

	public void infoPressed(){
		infoTab.SetActive (true);
		actionsTab.SetActive (false);
		candidatesTab.SetActive (false);
	}

	public void actionsPressed(){
		infoTab.SetActive (false);
		actionsTab.SetActive (true);
		candidatesTab.SetActive (false);
	}

	public void candidatesPressed(){
		infoTab.SetActive (false);
		actionsTab.SetActive (false);
		candidatesTab.SetActive (true);
	}
}