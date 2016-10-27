using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayMilitaryOffer : MonoBehaviour {

	Text offerText;
	public static int milOfferAmount=100;
	public static bool offerSelected = false;

	// Use this for initialization
	void Start () {
		offerText = gameObject.GetComponent<Text>();
		offerText.text="Offer Amount : " + milOfferAmount;
	}
	
	// Update is called once per frame
	void Update () {
		offerText.text="Offer Amount : " + milOfferAmount;
	}

	void offerHasBeenSelected () {
		offerSelected = true;
	}
}
