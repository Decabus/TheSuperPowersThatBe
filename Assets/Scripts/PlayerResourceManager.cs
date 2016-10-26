using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerResourceManager : MonoBehaviour {

	Text playerResourcesText;
	private int playerResourceAmount=0;
	private bool bussSelected;
	private bool civSelected;
	private bool recSelected;
	private bool milSelected;
	private bool medSelected;

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
	}

	void businessSelected () {
		bussSelected = DisplayBusinessOffer.offerSelected;
		if (bussSelected == true) {
			playerResourcesText.text="Amount of Resources : " + playerResourceAmount;
			playerResourceAmount = playerResourceAmount + DisplayBusinessOffer.bussOfferAmount;
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

