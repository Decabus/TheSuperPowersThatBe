using UnityEngine;
using System.Collections;

public class MapDistricts : MonoBehaviour{

	void OnMouseOver(){
		GetComponent<Renderer> ().material.color = new Color (0.1f, 0, 0) * Time.deltaTime;
		Debug.Log("ON THE THING");
	}
}