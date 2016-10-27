using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayMilitaryOffer : MonoBehaviour {

	Text offerText;
	public static int milOfferAmount=0;
	public static bool offerSelected = false;
	public int randomNumber;

	// Use this for initialization
	void Start () {
		randomNumber = Random.Range (1, 3);
		Debug.Log (randomNumber);

		offerText = gameObject.GetComponent<Text>();
		//offerText.text="Offer Amount : " + milOfferAmount;
	}
	
	// Update is called once per frame
	void Update () {
		//offerText.text="Offer Amount : " + milOfferAmount;
		offerVersion1();
		offerVersion2();
		offerVersion3();
	}

	void offerHasBeenSelected () {
		offerSelected = true;
	}

	void offerVersion1 () {
		if (randomNumber == 1) {
			milOfferAmount = 100;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="Offer Amount : " + milOfferAmount;
		}
	}

	void offerVersion2 () {
		if (randomNumber == 2) {
			milOfferAmount = 150;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="We will offer you : " + milOfferAmount;
		}
	}

	void offerVersion3 () {
		if (randomNumber == 3) {
			milOfferAmount = 70;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="How does : " + milOfferAmount +" sound to you?";
		}
	}
}
