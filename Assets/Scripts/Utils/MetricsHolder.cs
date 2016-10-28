using UnityEngine;
using System.Collections;

public class MetricsHolder : MonoBehaviour{

	public int playerResourceAmount=0;
	public static int cost=0;

	public int globalBusinessAffiliation=0;
	public int globalCivilAffiliation=0;
	public int globalAwareness=0;

	public int globalAffilation;

	public int playerAffiliation=0;

	//SINGLETONS ARE YOUR FRIEND
	private static MetricsHolder instance = null;
	void Awake(){
		DontDestroyOnLoad (gameObject);
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}
}