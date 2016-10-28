using UnityEngine;
using System.Collections;

public class SplashWait : MonoBehaviour {
	
	    public GameObject mainMenu;

	    IEnumerator Start()
	    {
		        yield return new WaitForSeconds(4);

		        GameObject.Find("SEImage").SetActive(false);

		        yield return new WaitForSeconds(2);

		        mainMenu.SetActive(true);
		   }
	} 