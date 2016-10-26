using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayCivilOffer : MonoBehaviour {

	Text offerText;
	public static int civOfferAmount=50;
	public static bool offerSelected = false;

	// Use this for initialization
	void Start () {
		offerText = gameObject.GetComponent<Text>();
		offerText.text="Offer Amount : " + civOfferAmount;
	}
	
	// Update is called once per frame
	void Update () {
		offerText.text="Offer Amount : " + civOfferAmount;
	}
}
