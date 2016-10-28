using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapDistricts : MonoBehaviour{


	/************************
	 * SUMMARY
	 * 
	 * Everything works so long as buttons are dragged into the appropriate serialized fields. It should be self-explanatory which ones they are however they MAY need tweaking
	 * All that needs doing is creating arbitrary actions that affect global metrics that can be put in each 'actions' tab.
	 * 
	 * ********************/
	public int districtAffiliation;

	public int distBizAff;
	public int distCivAff;

	private int buttonIndex;
	private int buttonDisplayIndex;

	private string newName;

	private List<Politician> candidates;
	public Politician chosenCandidate;
	public Politician winner;

	private PlayerResourceManager RS;
	private MetricsHolder MH;

	private bool selected;

	[SerializeField]
	private int addCampaignCost;

	[SerializeField]
	private int invesetmentCost;

	[SerializeField]
	private int assassinationCost;

	string[] alphabet = { "Davis ", "Luke ", "Decan ",  "Joseff ", "Aramat ", "Arstok ", "Grant ", "Welkin ", "Vargas ", "Fenn ", "Parker "};

	[SerializeField]
	GameObject panel;

	[SerializeField]
	GameObject districtMesh;

	[SerializeField]
	Text infoText;

	[SerializeField]
	Text candidatesText;

	[SerializeField]
	List<Button> selectButtons;

	[SerializeField]
	Button campaignButton;

	[SerializeField]
	Button investButton;

	[SerializeField]
	Button assButton;

	Round2Manager r2M;

	void Start(){
		r2M = GameObject.Find ("Stage2Canvas").GetComponent<Round2Manager> ();
		RS = GameObject.Find ("_PlayerResourcesManager").GetComponent<PlayerResourceManager> ();
		MH = GameObject.Find ("_ResourceHolder").GetComponent<MetricsHolder> ();

		districtAffiliation = Random.Range (30, 60);

		candidates = new List<Politician> ();

		distBizAff = districtAffiliation;
		distCivAff = 100 - districtAffiliation;
		//Debug.Log (this.name + ": " + distBizAff + "% Biz, " + distCivAff + "% Civ.");

		for(int i = 0; i < 3; i++){
			// 4chan.org/pol/
			Politician pol;

			//string[] alphabet = { "Davis ", "Luke ", "Decan ",  "Joseff ", "Aramat ", "Arstok ", "Grant ", "Welkin ", "Vargas ", "Fenn ", "Parker "};



			pol.name = alphabet [Random.Range (0, alphabet.Length)] + alphabet [Random.Range (0, alphabet.Length)];
			pol.cost = (Random.Range (2, 10) * 100);
			pol.bizModifier = Random.Range(-6, 6);
			pol.civModifier = Random.Range (-6, 6);
			pol.chanceOfWinning = Mathf.Round(Random.Range(0.1f, 0.9f) * Mathf.Pow(10.0f, (float)2)) / Mathf.Pow(10.0f, (float)2);

			candidates.Add(pol);
		}
	}

	void FixedUpdate(){
		infoText.text = (this.name + ": " + distBizAff + "% Biz, " + distCivAff + "% Civ.");

	}

	void OnMouseOver(){
		//panel.SetActive (true);
		//panel.GetComponent<Image> ().enabled = true;
		districtMesh.GetComponent<Renderer> ().material.color = new Color (1.0f, 0.1f, 0.1f);
		if (Input.GetMouseButtonUp (0)) {
			r2M.activatePanel (panel);
			DisplayPols ();
		}
	}

	void OnMouseExit(){
		//panel.SetActive (false);
		districtMesh.GetComponent<Renderer> ().material.color = new Color (1.0f, 1.0f, 1.0f);
	}

	//**ACTIONBUTTONS**
	public void addCampaign(){
		if (MH.playerResourceAmount > addCampaignCost) {
			districtAffiliation += 10;
			MH.playerResourceAmount -= addCampaignCost;
			campaignButton.interactable = false;
			assButton.interactable = false;
			investButton.interactable = false;

			distBizAff = districtAffiliation;
			distCivAff = 100 - districtAffiliation;
		}
	}
		
	public void Assassination(){
		if (MH.playerResourceAmount > assassinationCost) {
			MH.globalAwareness -= 15;
			MH.playerResourceAmount -= assassinationCost;
			campaignButton.interactable = false;
			assButton.interactable = false;
			investButton.interactable = false;
		}
	}

	public void investments(){
		if (MH.playerResourceAmount > invesetmentCost) {
			districtAffiliation -= 10;
			MH.playerResourceAmount -= invesetmentCost;
			campaignButton.interactable = false;
			assButton.interactable = false;
			investButton.interactable = false;

			distBizAff = districtAffiliation;
			distCivAff = 100 - districtAffiliation;
		}
	}

	void DisplayPols(){
		if (!selected) {
			candidatesText.text = "";
			foreach (Politician p in candidates) {
				candidatesText.text += "\n" + p.name + ": " + "Biz: " + p.bizModifier + ". Civ: " + p.civModifier + ". Win chance: " + (p.chanceOfWinning * 100) + "%. Cost: " + p.cost + " credits";
			}
				
			foreach (Button b in selectButtons) {
				//b.onClick.AddListener(SelectCandidate (buttonIndex++));
				b.GetComponent<Button> ().onClick.AddListener (delegate {
					SelectCandidate (buttonIndex++);
				});
				//b.transform.GetChild (0).GetComponent<Text> ().text = "Hire candidate";
			}
		}
	}

	public void SelectCandidate(int num){
		if (MH.playerResourceAmount > candidates [num].cost && !selected) {
			chosenCandidate = candidates [num];
			candidatesText.text = chosenCandidate.name + " Has been chosen for this election.";
			selected = true;
			MH.playerResourceAmount -= candidates [num].cost;
			foreach (Button b in selectButtons) {
				Destroy (b);
				b.GetComponent<Image> ().enabled = false;
				b.transform.GetChild (0).GetComponent<Text> ().enabled = false;
			}
		} else {
			Debug.Log ("Not enough money!");
		}
	}

	public void election(){
		//Pick a random candidate if one was not selected.
		if (!selected) {
			chosenCandidate = candidates [Random.Range (0, candidates.Count)];
		}

		Politician op;
		op.cost = 0;
		op.bizModifier = chosenCandidate.bizModifier * -1;
		op.civModifier = chosenCandidate.civModifier * -1;
		op.name = alphabet [Random.Range (0, alphabet.Length)] + alphabet [Random.Range (0, alphabet.Length)];
		op.chanceOfWinning = 1.0f - chosenCandidate.chanceOfWinning;

		int chance = Random.Range (0, 100);

		if (chance <= (chosenCandidate.chanceOfWinning * 100)) {
			winner = chosenCandidate;
			Debug.Log ("WINNER: And the Winner for " + this.name + " is: " + winner.name);
		} else {
			winner = op;
			Debug.Log ("LOSER: And the Winner for " + this.name + " is: " + winner.name);
		}
			
		districtAffiliation += winner.bizModifier;
		districtAffiliation -= winner.civModifier;

		distBizAff = districtAffiliation;
		distCivAff = 100 - districtAffiliation;

	}
		
}

public struct Politician {
	public string name;
	public int cost;
	public int bizModifier;
	public int civModifier;
	public float chanceOfWinning;
}