using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DistrictPoliticians : MonoBehaviour {

	Text politician1Text;
	public static int politician1Cost=20;
	public static int politician2Cost=50;
	public static int politician3Cost=100;
	public static bool offerSelected = false;
	public int randomNumber;

	// Use this for initialization
	void Start () {
		//randomNumber = Random.Range (1, 3);
		//Debug.Log (randomNumber);

		politician1Text = gameObject.GetComponent<Text>();
		politician1Text.text="Shady Man \n \n Bribe Cost: " + politician1Cost;
	}

	// Update is called once per frame
	void Update () {
		//offerText.text="Offer Amount : " + bussOfferAmount;
		//offerVersion1();
		//offerVersion2();
		//offerVersion3();
	}

	void offerHasBeenSelected () {
		offerSelected = true;
	}

	//void offerVersion1 () {
	//	if (randomNumber == 1) {
	//		bussOfferAmount = 100;
	//		//offerText = gameObject.GetComponent<Text>();
	//		offerText.text="Offer Amount : " + bussOfferAmount;
	//	}
	//}

	//void offerVersion2 () {
	//	if (randomNumber == 2) {
	//		bussOfferAmount = 150;
	//		//offerText = gameObject.GetComponent<Text>();
	//		offerText.text="We will offer you : " + bussOfferAmount;
	//	}
	//}

	//void offerVersion3 () {
	//	if (randomNumber == 3) {
	//		bussOfferAmount = 70;
	//		//offerText = gameObject.GetComponent<Text>();
	//		offerText.text="How does : " + bussOfferAmount +" sound to you?";
	//	}
	//}
}