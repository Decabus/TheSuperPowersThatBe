using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayBusinessOffer : MonoBehaviour {

	Text offerText;
	public static int bussOfferAmount=0;
	public static bool offerSelected = false;
	//public int [] values;
	public int randomNumber;

	//values = new float[3];
	//values[1] = 1;
	//values[2] = 2;

	// Use this for initialization
	void Start () {
		randomNumber = Random.Range (1, 3);
		Debug.Log (randomNumber);

		offerText = gameObject.GetComponent<Text>();
		//offerText.text="Offer Amount : " + bussOfferAmount;
	}
	
	// Update is called once per frame
	void Update () {
		//offerText.text="Offer Amount : " + bussOfferAmount;
		offerVersion1();
		offerVersion2();
		offerVersion3();
	}

	void offerHasBeenSelected () {
		offerSelected = true;
	}

	void offerVersion1 () {
		if (randomNumber == 1) {
			bussOfferAmount = 100;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="Offer Amount : " + bussOfferAmount;
		}
	}

	void offerVersion2 () {
		if (randomNumber == 2) {
			bussOfferAmount = 150;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="We will offer you : " + bussOfferAmount;
		}
	}

	void offerVersion3 () {
		if (randomNumber == 3) {
			bussOfferAmount = 70;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="How does : " + bussOfferAmount +" sound to you?";
		}
	}
}
