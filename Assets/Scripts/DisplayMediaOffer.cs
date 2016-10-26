using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayMediaOffer : MonoBehaviour {

	Text offerText;
	public static int medOfferAmount=200;
	public static bool offerSelected = false;

	// Use this for initialization
	void Start () {
		offerText = gameObject.GetComponent<Text>();
		offerText.text="Offer Amount : " + medOfferAmount;
	}
	
	// Update is called once per frame
	void Update () {
		offerText.text="Offer Amount : " + medOfferAmount;
	}
}
