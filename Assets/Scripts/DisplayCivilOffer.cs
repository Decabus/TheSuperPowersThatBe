using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayCivilOffer : MonoBehaviour {

	Text offerText;
	public static int civOfferAmount=0;
	public static bool offerSelected = false;
	public int randomNumber;

	// Use this for initialization
	void Start () {
		randomNumber = Random.Range (1, 3);
		Debug.Log (randomNumber);

		offerText = gameObject.GetComponent<Text>();
		//offerText.text="Offer Amount : " + civOfferAmount;
	}
	
	// Update is called once per frame
	void Update () {
		//offerText.text="Offer Amount : " + civOfferAmount;
		offerVersion1();
		offerVersion2();
		offerVersion3();
	}

	void offerHasBeenSelected () {
		offerSelected = true;
	}

	void offerVersion1 () {
		if (randomNumber == 1) {
			civOfferAmount = 100;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="Offer Amount : " + civOfferAmount;
		}
	}

	void offerVersion2 () {
		if (randomNumber == 2) {
			civOfferAmount = 150;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="We will offer you : " + civOfferAmount;
		}
	}

	void offerVersion3 () {
		if (randomNumber == 3) {
			civOfferAmount = 70;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="How does : " + civOfferAmount +" sound to you?";
		}
	}
}
