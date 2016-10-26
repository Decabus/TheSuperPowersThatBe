using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour{

	//State as in what 'round' the game is in. Between 0 and 2
	public int gameState;

	Transform player;

	[SerializeField]
	Transform stage1Ref;

	[SerializeField]
	Transform stage2Ref;

	float lerpTime = 1f;
	float currentLerpTime;

	void Start(){
		player = GameObject.Find ("Main Camera").transform;
	}

	void FixedUpdate(){

		currentLerpTime += Time.deltaTime;
		if (currentLerpTime > lerpTime) {
			currentLerpTime = lerpTime;
		}
		float perc = currentLerpTime / lerpTime;

		if (gameState == 1) {
			player.transform.position = Vector3.Lerp (this.transform.position, stage2Ref.transform.position, perc);
			player.transform.rotation = stage2Ref.transform.rotation;
		}

		if (gameState == 0) {
			//player.transform.position = Vector3.Lerp (stage2Ref.transform.position, stage1Ref.transform.position, perc);
		}
	}
}