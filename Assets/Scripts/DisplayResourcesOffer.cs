using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayResourcesOffer : MonoBehaviour {

	Text offerText;
	public static int recOfferAmount=150;
	public static bool offerSelected = false;

	// Use this for initialization
	void Start () {
		offerText = gameObject.GetComponent<Text>();
		offerText.text="Offer Amount : " + recOfferAmount;
	}
	
	// Update is called once per frame
	void Update () {
		offerText.text="Offer Amount : " + recOfferAmount;
	}

	void offerHasBeenSelected () {
		offerSelected = true;
	}
}
