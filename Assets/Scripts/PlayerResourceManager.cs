using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerResourceManager : MonoBehaviour {

	Text playerResourcesText;
	public static int playerResourceAmount=0;
	public static int cost=0;
	//public static bool bussSelected;
	//public static bool civSelected;
	//public static bool recSelected;
	//public static bool milSelected;
	//public static bool medSelected;

	// Use this for initialization
	void Start () {
		playerResourcesText = gameObject.GetComponent<Text>();
		//playerResourcesText.text="Credits: "+playerResourceAmount;
	}
	
	// Update is called once per frame
	void Update () {
		businessSelected();

		civilSelected();

		resourcesSelected();

		militarySelected();

		mediaSelected();

		districtPolitician1Selected();
		try{
			playerResourcesText.text="Credits: "+playerResourceAmount;
		}
		catch{
		}

		cost = DistrictPoliticians.politician1Cost;

		//onClick();
	}

	void businessSelected () {
		if (DisplayBusinessOffer.offerSelected == true) {
			playerResourcesText.text="Credits: "+playerResourceAmount;
			playerResourceAmount = playerResourceAmount + DisplayBusinessOffer.bussOfferAmount;
			DisplayBusinessOffer.offerSelected = false;
		}
	}

	void civilSelected () {
		if (DisplayCivilOffer.offerSelected == true) {
			playerResourcesText.text="Credits: "+playerResourceAmount;
			playerResourceAmount = playerResourceAmount + DisplayCivilOffer.civOfferAmount;
			DisplayCivilOffer.offerSelected = false;
		}
	}

	void resourcesSelected () {
		if (DisplayResourcesOffer.offerSelected == true) {
			playerResourcesText.text="Credits: "+playerResourceAmount;
			playerResourceAmount = playerResourceAmount + DisplayResourcesOffer.recOfferAmount;
			DisplayResourcesOffer.offerSelected = false;
		}
	}

	void militarySelected () {
		if (DisplayMilitaryOffer.offerSelected == true) {
			playerResourcesText.text="Credits: "+playerResourceAmount;
			playerResourceAmount = playerResourceAmount + DisplayMilitaryOffer.milOfferAmount;
			DisplayMilitaryOffer.offerSelected = false;
		}
	}

	void mediaSelected () {
		  if (DisplayMediaOffer.offerSelected == true) {
			playerResourcesText.text="Credits: "+playerResourceAmount;
			playerResourceAmount = playerResourceAmount + DisplayMediaOffer.medOfferAmount;
			DisplayMediaOffer.offerSelected = false;
		}
	}

	void districtPolitician1Selected () {
		if (DistrictPoliticians.offerSelected == true && playerResourceAmount >= cost) {
			playerResourcesText.text="Amount of Resources : " + playerResourceAmount;
			playerResourceAmount = playerResourceAmount - DistrictPoliticians.politician1Cost;
			DistrictPoliticians.offerSelected = false;
		}
	}

	public void onClickBribePolitician1 () {
		Debug.Log("CLICKING!");
		DistrictPoliticians.offerSelected = true;
		if (DistrictPoliticians.offerSelected == true && playerResourceAmount >= cost) {
			playerResourcesText.text="Credits: "+playerResourceAmount;
			playerResourceAmount = playerResourceAmount - DistrictPoliticians.politician1Cost;
			DistrictPoliticians.offerSelected = false;
		}
	}

	public void onClickBribePolitician2 () {
		Debug.Log("CLICKING!");
		DistrictPoliticians.offerSelected = true;
		if (DistrictPoliticians.offerSelected == true && playerResourceAmount >= cost) {
			playerResourcesText.text="Credits: "+playerResourceAmount;
			playerResourceAmount = playerResourceAmount - DistrictPoliticians.politician2Cost;
			DistrictPoliticians.offerSelected = false;
		}
	}

	public void onClickBribePolitician3 () {
		Debug.Log("CLICKING!");
		DistrictPoliticians.offerSelected = true;
		if (DistrictPoliticians.offerSelected == true && playerResourceAmount >= cost) {
			playerResourcesText.text="Credits: "+playerResourceAmount;
			playerResourceAmount = playerResourceAmount - DistrictPoliticians.politician3Cost;
			DistrictPoliticians.offerSelected = false;
		}
	}
}