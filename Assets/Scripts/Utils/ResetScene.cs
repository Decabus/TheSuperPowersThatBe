using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ResetScene : MonoBehaviour{

	public void ReturnPress(){
		SceneManager.LoadScene ("Main");
	}
}