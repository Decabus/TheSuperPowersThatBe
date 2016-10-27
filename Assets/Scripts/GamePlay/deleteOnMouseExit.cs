using UnityEngine;
using System.Collections;

public class deleteOnMouseExit : MonoBehaviour{

	void OnMouseExit(){
		//panel.SetActive (false);
		this.gameObject.SetActive(false);
	}
}