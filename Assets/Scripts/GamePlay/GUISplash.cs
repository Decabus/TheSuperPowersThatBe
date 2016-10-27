using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GUISplash : MonoBehaviour{

	public void YesPressed(){
		SceneManager.LoadScene ("Main");
	}

	public void NoPressed(){
		Application.Quit ();
	}
}