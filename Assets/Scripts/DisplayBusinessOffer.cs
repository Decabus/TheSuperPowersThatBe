using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayBusinessOffer : MonoBehaviour {

	Text offerText;
	public static int bussOfferAmount=100;
	public static bool offerSelected = false;

	// Use this for initialization
	void Start () {
		offerText = gameObject.GetComponent<Text>();
		offerText.text="Offer Amount : " + bussOfferAmount;
	}
	
	// Update is called once per frame
	void Update () {
		offerText.text="Offer Amount : " + bussOfferAmount;
	}

	void offerHasBeenSelected () {
		offerSelected = true;
	}
}
