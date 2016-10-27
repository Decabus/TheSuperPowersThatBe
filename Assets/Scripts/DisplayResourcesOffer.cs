using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayResourcesOffer : MonoBehaviour {

	Text offerText;
	public static int recOfferAmount=0;
	public static bool offerSelected = false;
	public int randomNumber;

	// Use this for initialization
	void Start () {
		randomNumber = Random.Range (1, 3);
		//Debug.Log (randomNumber);

		offerText = gameObject.GetComponent<Text>();
		//offerText.text="Offer Amount : " + recOfferAmount;
	}
	
	// Update is called once per frame
	void Update () {
		//offerText.text="Offer Amount : " + recOfferAmount;
		offerVersion1();
		offerVersion2();
		offerVersion3();
	}

	void offerHasBeenSelected () {
		offerSelected = true;
	}

	void offerVersion1 () {
		if (randomNumber == 1) {
			recOfferAmount = 100;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="Offer Amount : " + recOfferAmount;
		}
	}

	void offerVersion2 () {
		if (randomNumber == 2) {
			recOfferAmount = 150;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="We will offer you : " + recOfferAmount;
		}
	}

	void offerVersion3 () {
		if (randomNumber == 3) {
			recOfferAmount = 70;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="How does : " + recOfferAmount +" sound to you?";
		}
	}
}
