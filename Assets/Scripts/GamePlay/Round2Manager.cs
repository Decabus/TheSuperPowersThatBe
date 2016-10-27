using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Round2Manager : MonoBehaviour {

	//public GameObject activePanel;

	[SerializeField]
	private List<GameObject> panels;

	public void activatePanel(GameObject panelToActiv){
		foreach(GameObject i in panels){
			if (panelToActiv.name == i.name) {
				i.SetActive (true);
			} else {
				i.SetActive (false);
			}
		}
	}
}
