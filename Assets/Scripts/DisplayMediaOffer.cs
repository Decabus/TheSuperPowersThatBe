using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayMediaOffer : MonoBehaviour {

	Text offerText;
	public static int medOfferAmount=0;
	public static int civAmout;
	public static int bizAmout;
	public static int awarenessAmount;
	public static bool offerSelected = false;
	public int randomNumber;

	// Use this for initialization
	void Start () {
		randomNumber = Random.Range (1, 3);
		Debug.Log (randomNumber);

		offerText = gameObject.GetComponent<Text>();
		//offerText.text="Offer Amount : " + medOfferAmount;
	}
	
	// Update is called once per frame
	void Update () {
		//offerText.text="Offer Amount : " + medOfferAmount;
		offerVersion1();
		offerVersion2();
		offerVersion3();
	}

	void offerHasBeenSelected () {
		offerSelected = true;
	}

	void offerVersion1 () {
		if (randomNumber == 1) {
			medOfferAmount = 100;
			civAmout = -1;
			bizAmout = 1;
			awarenessAmount = 0;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="Offer \n \n \n " + bizAmout + " Commerce" + "\n " + civAmout + "Civil" + "\n " + awarenessAmount + "% Awareness";
		}
	}

	void offerVersion2 () {
		if (randomNumber == 2) {
			medOfferAmount = 150;
			civAmout = 2;
			bizAmout = -2;
			awarenessAmount = 4;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="Offer \n \n \n " + bizAmout + " Commerce" + "\n " + civAmout + "Civil" + "\n " + awarenessAmount + "% Awareness";
		}
	}

	void offerVersion3 () {
		if (randomNumber == 3) {
			medOfferAmount = 70;
			civAmout = 2;
			bizAmout = 0;
			awarenessAmount = 0;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="Offer \n \n \n " + bizAmout + " Commerce" + "\n " + civAmout + "Civil" + "\n " + awarenessAmount + "% Awareness";
		}
	}
}
