using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerResourceManager : MonoBehaviour {

	GameManager gameManager;
	MetricsHolder holder;

	[SerializeField]
	Text playerResourcesText;

	[SerializeField]
	Text mapResourcesText;

	//[SerializeField]
	//Slider awarenessSlider;

	[SerializeField]
	Text awarenessSliderValue;


	//public int playerResourceAmount=0;
	public static int cost=0;

	public int globalBusinessAffiliation=0;
	public int globalCivilAffiliation=0;
	public int globalAwareness=0;

	public int globalAffilation;

	public int playerAffiliation=0;

	public static GameObject businessLight;
	public static GameObject civilLight;
	public static GameObject resourcesLight;
	public static GameObject militaryLight;
	public static GameObject mediaLight;

	public GameObject spotlightDesk;
	public GameObject spotlightPlayerDesk;
	public GameObject tv;
	public GameObject commenceButton;
	public GameObject commenceText;


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
		holder = GameObject.Find ("_ResourceHolder").GetComponent<MetricsHolder> ();

		businessLight = GameObject.Find("/_ART/Assets/BusinessLight");
		businessLight.SetActive (true);

		civilLight = GameObject.Find("/_ART/Assets/CivilLight");
		civilLight.SetActive (true);

		resourcesLight = GameObject.Find("/_ART/Assets/ResourcesLight");
		resourcesLight.SetActive (true);

		militaryLight = GameObject.Find("/_ART/Assets/MilitaryLight");
		militaryLight.SetActive (true);

		mediaLight = GameObject.Find("/_ART/Assets/MediaLight");
		mediaLight.SetActive (true);

		spotlightDesk = GameObject.Find("/_ART/_Lights/Spotlight_Desk");
		spotlightDesk.SetActive (true);

		spotlightPlayerDesk = GameObject.Find("/_ART/_Lights/Spotlight_PlayerDesk");
		spotlightPlayerDesk.SetActive (false);

		commenceButton = GameObject.Find("/_ART/Assets/Button");
		commenceButton.SetActive (false);


	}
	
	// Update is called once per frame
	void Update () {
		businessSelected();

		civilSelected();

		resourcesSelected();

		militarySelected();

		mediaSelected();

		districtPolitician1Selected();

		endRoundOne();

		awarenessSliderValue.text = "" + holder.globalAwareness + "%";

		mapResourcesText.text = "Credits: " + holder.playerResourceAmount.ToString ();

		//playerResourcesText.text = playerResourceAmount.ToString ();

		cost = DistrictPoliticians.politician1Cost;
		//Debug.Log("Luke was wrong");

		//onClick();
		districtPoliticianSelected();

		//playerResourcesText.text="Amount of Resources : " + playerResourceAmount;

		cost = DistrictPoliticians.politician1Cost;

		if (holder.globalAwareness >= 100) {
			SceneManager.LoadScene ("EndScreen");
		}
	}

	void businessSelected () {
		if (DisplayBusinessOffer.offerSelected == true) {
			playerResourcesText.text="Credits: "+ holder.playerResourceAmount;
			Debug.Log("PRICE");
			holder.playerResourceAmount = holder.playerResourceAmount + DisplayBusinessOffer.bussOfferAmount;
			Debug.Log("SET PRICE");
			holder.globalBusinessAffiliation += DisplayBusinessOffer.bizAmout;
			Debug.Log("SET BIZ");
			holder.globalCivilAffiliation += DisplayBusinessOffer.civAmout;
			Debug.Log("SET CIV");
			holder.globalAwareness += DisplayBusinessOffer.awarenessAmount;
			Debug.Log("SET AWARENESS");
			DisplayBusinessOffer.offerSelected = false;
			Debug.Log("player" + holder.playerResourceAmount);
			Debug.Log("buss" + globalBusinessAffiliation);
			Debug.Log("civ" + globalCivilAffiliation);
			Debug.Log("awar" + globalAwareness);
			//Debug.Log(awarenessSlider.value);
			businessLight.SetActive (false);
		}
	}

	void civilSelected () {
		if (DisplayCivilOffer.offerSelected == true) {
			playerResourcesText.text="Credits: "+holder.playerResourceAmount;
			holder.playerResourceAmount = holder.playerResourceAmount + DisplayCivilOffer.civOfferAmount;
			holder.globalBusinessAffiliation += DisplayCivilOffer.bizAmout;
			holder.globalCivilAffiliation += DisplayCivilOffer.civAmout;
			holder.globalAwareness +=  DisplayCivilOffer.awarenessAmount;
			DisplayCivilOffer.offerSelected = false;
			civilLight.SetActive (false);
		}
	}

	void resourcesSelected () {
		if (DisplayResourcesOffer.offerSelected == true) {
			playerResourcesText.text="Credits: "+holder.playerResourceAmount;
			holder.playerResourceAmount = holder.playerResourceAmount + DisplayResourcesOffer.recOfferAmount;
			holder.globalBusinessAffiliation += DisplayResourcesOffer.bizAmout;
			holder.globalCivilAffiliation += DisplayResourcesOffer.civAmout;
			holder.globalAwareness +=  DisplayResourcesOffer.awarenessAmount;
			DisplayResourcesOffer.offerSelected = false;
			resourcesLight.SetActive (false);
		}
	}

	void militarySelected () {
		if (DisplayMilitaryOffer.offerSelected == true) {
			playerResourcesText.text="Credits: "+holder.playerResourceAmount;
			holder.playerResourceAmount = holder.playerResourceAmount + DisplayMilitaryOffer.milOfferAmount;
			holder.globalBusinessAffiliation += DisplayMilitaryOffer.bizAmout;
			holder.globalCivilAffiliation += DisplayMilitaryOffer.civAmout;
			holder.globalAwareness +=  DisplayMilitaryOffer.awarenessAmount;
			DisplayMilitaryOffer.offerSelected = false;
			militaryLight.SetActive (false);

		}
	}

	void mediaSelected () {
		  if (DisplayMediaOffer.offerSelected == true) {
			playerResourcesText.text="Credits: "+holder.playerResourceAmount;
			holder.playerResourceAmount = holder.playerResourceAmount + DisplayMediaOffer.medOfferAmount;
			holder.globalBusinessAffiliation += DisplayMediaOffer.bizAmout;
			holder.globalCivilAffiliation += DisplayMediaOffer.civAmout;
			holder.globalAwareness +=  DisplayMediaOffer.awarenessAmount;
			DisplayMediaOffer.offerSelected = false;
			mediaLight.SetActive (false);
		}
	}

	void districtPoliticianSelected () {
		if (DistrictPoliticians.offerSelected == true && holder.playerResourceAmount >= cost) {
			playerResourcesText.text="Amount of Resources : " + holder.playerResourceAmount;
			holder.playerResourceAmount = holder.playerResourceAmount - DistrictPoliticians.politician1Cost;
			DistrictPoliticians.offerSelected = false;
		}
	}


	void districtPolitician1Selected () {
		if (DistrictPoliticians.offerSelected == true && holder.playerResourceAmount >= cost) {
			playerResourcesText.text="Amount of Resources : " + holder.playerResourceAmount;
			holder.playerResourceAmount = holder.playerResourceAmount - DistrictPoliticians.politician1Cost;
			DistrictPoliticians.offerSelected = false;
		}
	}

	void endRoundOne () {
		if (PlayrLookAt.optionsSelected == 5) {
			spotlightDesk.SetActive (false);
			//yield return new WaitForSeconds(1);
			commenceButton.SetActive (true);
			commenceText.SetActive (true);
			spotlightPlayerDesk.SetActive (true);
			//yield return new WaitForSeconds(1);
		}
	}

	public void onClickBribePolitician1 () {
		Debug.Log("CLICKING!");
		DistrictPoliticians.offerSelected = true;
		if (DistrictPoliticians.offerSelected == true && holder.playerResourceAmount >= cost) {
			playerResourcesText.text="Credits: "+holder.playerResourceAmount;
			holder.playerResourceAmount = holder.playerResourceAmount - DistrictPoliticians.politician1Cost;
			DistrictPoliticians.offerSelected = false;
		}
	}

	public void onClickBribePolitician2 () {
		Debug.Log("CLICKING!");
		DistrictPoliticians.offerSelected = true;
		if (DistrictPoliticians.offerSelected == true && holder.playerResourceAmount >= cost) {
			playerResourcesText.text="Credits: "+holder.playerResourceAmount;
			holder.playerResourceAmount = holder.playerResourceAmount - DistrictPoliticians.politician2Cost;
			DistrictPoliticians.offerSelected = false;

		}
	}

	public void onClickBribePolitician3 () {
		Debug.Log("CLICKING!");
		DistrictPoliticians.offerSelected = true;
		if (DistrictPoliticians.offerSelected == true && holder.playerResourceAmount >= cost) {
			playerResourcesText.text="Credits: "+holder.playerResourceAmount;
			holder.playerResourceAmount = holder.playerResourceAmount - DistrictPoliticians.politician3Cost;
			DistrictPoliticians.offerSelected = false;
		}
	}
}