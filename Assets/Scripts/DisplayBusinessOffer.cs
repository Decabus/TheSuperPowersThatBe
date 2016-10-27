using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayBusinessOffer : MonoBehaviour {

	Text offerText;
	public static int bussOfferAmount=0;
	public static int civAmout;
	public static int bizAmout;
	public static int awarenessAmount;
	public static bool offerSelected = false;
	//public int [] values;
	public int randomNumber=5;

	//values = new float[3];
	//values[1] = 1;
	//values[2] = 2;

	// Use this for initialization
	void Start () {
		randomNumber = Random.Range (1, 4);
		Debug.Log ("buss" + randomNumber);

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
			civAmout = -1;
			bizAmout = 1;
			awarenessAmount = 0;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="Offer \n \n \n " + bizAmout + " Commerce" + "\n " + civAmout + "Civil" + "\n " + awarenessAmount + "% Awareness";
		}
	}

	void offerVersion2 () {
		if (randomNumber == 2) {
			bussOfferAmount = 150;
			civAmout = -2;
			bizAmout = 2;
			awarenessAmount = 5;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="Offer \n \n \n " + bizAmout + " Commerce" + "\n " + civAmout + "Civil" + "\n " + awarenessAmount + "% Awareness";
		}
	}

	void offerVersion3 () {
		if (randomNumber == 3) {
			bussOfferAmount = 70;
			civAmout = -1;
			bizAmout = 3;
			awarenessAmount = 3;
			//offerText = gameObject.GetComponent<Text>();
			offerText.text="Offer \n \n \n " + bizAmout + " Commerce" + "\n " + civAmout + "Civil" + "\n " + awarenessAmount + "% Awareness";
		}
	}
}
