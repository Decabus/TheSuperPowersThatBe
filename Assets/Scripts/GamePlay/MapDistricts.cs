using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapDistricts : MonoBehaviour{

	public int districtAffiliation;

	private int distBizAff;
	private int distCivAff;

	private int buttonIndex;

	private string newName;

	private List<Politician> candidates;
	public Politician chosenCandidate;

	private PlayerResourceManager RS;

	private bool selected;

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

	Round2Manager r2M;

	void Start(){
		r2M = GameObject.Find ("Stage2Canvas").GetComponent<Round2Manager> ();
		RS = GameObject.Find ("_PlayerResourcesManager").GetComponent<PlayerResourceManager> ();

		districtAffiliation = Random.Range (30, 60);

		candidates = new List<Politician> ();

		distBizAff = districtAffiliation;
		distCivAff = 100 - districtAffiliation;
		//Debug.Log (this.name + ": " + distBizAff + "% Biz, " + distCivAff + "% Civ.");

		for(int i = 0; i < 3; i++){
			// 4chan.org/pol/
			Politician pol;

			string[] alphabet = { "Davis ", "Luke ", "Decan ",  "Joseff ", "Aramat ", "Arstok ", "Grant ", "Welkin ", "Vargas ", "Fenn ", "Parker "};



			pol.name = alphabet [Random.Range (0, alphabet.Length)] + alphabet [Random.Range (0, alphabet.Length)];
			pol.cost = (Random.Range (2, 10) * 100);
			pol.bizModifier = Random.Range(0, 6);
			pol.civModifier = Random.Range (0, 6);
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

	void DisplayPols(){
		if (!selected) {
			candidatesText.text = "";
			foreach (Politician p in candidates) {
				candidatesText.text += "\n" + p.name + ": " + "Biz:" + p.bizModifier + ". Civ: " + p.civModifier + ". Win chance: " + (p.chanceOfWinning * 100) + "%. Cost:" + p.cost + "credits";
			}

			foreach (Button b in selectButtons) {
				//b.onClick.AddListener(SelectCandidate (buttonIndex++));
				b.GetComponent<Button> ().onClick.AddListener (delegate {
					SelectCandidate (buttonIndex++);
				});
			}
		}
	}

	public void SelectCandidate(int num){
		chosenCandidate = candidates [num];
		candidatesText.text = chosenCandidate.name + " Has been chosen for this election.";
		selected = true;
		foreach (Button b in selectButtons) {
			Destroy (b);
			b.GetComponent<Image> ().enabled = false;
			b.transform.GetChild (0).GetComponent<Text> ().enabled = false;
		}
	}

	public void election(){

	}
		
}

public struct Politician {
	public string name;
	public int cost;
	public int bizModifier;
	public int civModifier;
	public float chanceOfWinning;
}