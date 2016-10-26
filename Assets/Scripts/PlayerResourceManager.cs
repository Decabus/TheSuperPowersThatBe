using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerResourceManager : MonoBehaviour {

	Text playerResourcesText;
	public static int playerResourceAmount=0;
	public static bool bussSelected;
	public static bool civSelected;
	public static bool recSelected;
	public static bool milSelected;
	public static bool medSelected;

	// Use this for initialization
	void Start () {
		playerResourcesText = gameObject.GetComponent<Text>();
		playerResourcesText.text="Amount of Resources : " + playerResourceAmount;
	}
	
	// Update is called once per frame
	void Update () {
		businessSelected();

		civilSelected();

		resourcesSelected();

		militarySelected();

		mediaSelected();

		playerResourcesText.text="Amount of Resources : " + playerResourceAmount;
	}

	void businessSelected () {
		bussSelected = DisplayBusinessOffer.offerSelected;
		if (bussSelected == true) {
			playerResourcesText.text="Amount of Resources : " + playerResourceAmount;
			playerResourceAmount = playerResourceAmount + DisplayBusinessOffer.bussOfferAmount;
			//bussSelected = false;
		}
	}

	void civilSelected () {
		civSelected = DisplayCivilOffer.offerSelected;
		if (civSelected == true) {
			playerResourcesText.text="Amount of Resources : " + playerResourceAmount;
			playerResourceAmount = playerResourceAmount + DisplayCivilOffer.civOfferAmount;
		}
	}

	void resourcesSelected () {
		recSelected = DisplayResourcesOffer.offerSelected;
		if (recSelected == true) {
			playerResourcesText.text="Amount of Resources : " + playerResourceAmount;
			playerResourceAmount = playerResourceAmount + DisplayResourcesOffer.recOfferAmount;
		}
	}

	void militarySelected () {
		milSelected = DisplayMilitaryOffer.offerSelected;
		if (milSelected == true) {
			playerResourcesText.text="Amount of Resources : " + playerResourceAmount;
			playerResourceAmount = playerResourceAmount + DisplayMilitaryOffer.milOfferAmount;
		}
	}

	void mediaSelected () {
		medSelected = DisplayMediaOffer.offerSelected;
		if (medSelected == true) {
			playerResourcesText.text="Amount of Resources : " + playerResourceAmount;
			playerResourceAmount = playerResourceAmount + DisplayMediaOffer.medOfferAmount;
		}
	}
}

