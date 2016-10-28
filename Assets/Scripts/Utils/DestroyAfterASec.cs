using UnityEngine;
using System.Collections;

public class DestroyAfterASec : MonoBehaviour{

	//Use this for initialization 
	void Start(){
		StartCoroutine (WaitAsec ());
	}

	IEnumerator WaitAsec(){
		yield return new WaitForSeconds (2.0f);
		Destroy (gameObject);
	}
}