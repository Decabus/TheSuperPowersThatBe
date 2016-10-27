using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerResourceManager : MonoBehaviour {

	GameManager gameManager;

	[SerializeField]
	Text playerResourcesText;

	[SerializeField]
	Slider awarenessSlider;

	[SerializeField]
	Text awarenessSliderValue;


	public static int playerResourceAmount=0;
	public static int cost=0;

	public int globalBusinessAffiliation;
	public int globalCivilAffiliation;
	public int globalAwareness;

	public int playerAffiliation;

	//public static bool bussSelected;
	//public static bool civSelected;
	//public static bool recSelected;
	//public static bool milSelected;
	//public static bool medSelected;

	// Use this for initialization
	void Start () {
		//playerResourcesText = gameObject.GetComponent<Text>();
		//playerResourcesText.text="Credits: "+playerResourceAmount;
		gameManager = GameObject.Find("_GameManager").GetComponent<GameManager>();
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
			awarenessSlider.value = (float)globalAwareness/100;
			awarenessSliderValue.text = (awarenessSlider.value * 100).ToString();
			//Debug.Log(awarenessSlider.value);
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
			globalBusinessAffiliation += DisplayBusinessOffer.bizAmout;
			globalCivilAffiliation += DisplayBusinessOffer.civAmout;
			globalAwareness += DisplayBusinessOffer.awarenessAmount;
			DisplayBusinessOffer.offerSelected = false;
		}
	}

	void civilSelected () {
		if (DisplayCivilOffer.offerSelected == true) {
			playerResourcesText.text="Credits: "+playerResourceAmount;
			playerResourceAmount = playerResourceAmount + DisplayCivilOffer.civOfferAmount;
			globalBusinessAffiliation += DisplayCivilOffer.bizAmout;
			globalCivilAffiliation += DisplayCivilOffer.civAmout;
			globalAwareness +=  DisplayCivilOffer.awarenessAmount;
			DisplayCivilOffer.offerSelected = false;
		}
	}

	void resourcesSelected () {
		if (DisplayResourcesOffer.offerSelected == true) {
			playerResourcesText.text="Credits: "+playerResourceAmount;
			playerResourceAmount = playerResourceAmount + DisplayResourcesOffer.recOfferAmount;
			globalBusinessAffiliation += DisplayResourcesOffer.bizAmout;
			globalCivilAffiliation += DisplayResourcesOffer.civAmout;
			globalAwareness +=  DisplayResourcesOffer.awarenessAmount;
			DisplayResourcesOffer.offerSelected = false;
		}
	}

	void militarySelected () {
		if (DisplayMilitaryOffer.offerSelected == true) {
			playerResourcesText.text="Credits: "+playerResourceAmount;
			playerResourceAmount = playerResourceAmount + DisplayMilitaryOffer.milOfferAmount;
			globalBusinessAffiliation += DisplayMilitaryOffer.bizAmout;
			globalCivilAffiliation += DisplayMilitaryOffer.civAmout;
			globalAwareness +=  DisplayMilitaryOffer.awarenessAmount;
			DisplayMilitaryOffer.offerSelected = false;
		}
	}

	void mediaSelected () {
		  if (DisplayMediaOffer.offerSelected == true) {
			playerResourcesText.text="Credits: "+playerResourceAmount;
			playerResourceAmount = playerResourceAmount + DisplayMediaOffer.medOfferAmount;
			globalBusinessAffiliation += DisplayMediaOffer.bizAmout;
			globalCivilAffiliation += DisplayMediaOffer.civAmout;
			globalAwareness +=  DisplayMediaOffer.awarenessAmount;
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