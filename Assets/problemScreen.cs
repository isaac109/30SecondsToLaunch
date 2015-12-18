using UnityEngine;
using System.Collections;

public class problemScreen : MonoBehaviour {
	public ArrayList problems = new ArrayList ();
	public ArrayList problemsExp = new ArrayList ();
	public string stringToMatch = "";
	public string stringToEdit = "";
	public bool needString = false;
	public int stringLength = 5;
	public endGame eG;
	public GUIStyle mystyle;
	public GUIStyle mystyle2;
	public GUIStyle scrollStyle;
	public Vector2 scrollPosition = Vector2.zero;
	public float x =2;
	public float y =2;
	public float x2 = 1;
	public float y2 = 1;
	private string text = "Mission Brief: \nThe mission is to begin when the Commander gives the final approval. The three Astronauts on board the Hermes XI rocket include Lt Boyd, Lt Isaacson, and Lt Kmetz. The mission is a standard resupply to the USSS currently in longitude orbit, currently above the Antarctic. After resupply has been established and maintenance has concluded by Lt Isaacson, the crew will conclude orbit and land in the north Pacific ocean. \n Mission Brief: \nThe mission is to begin when the Commander gives the final approval. The three Astronauts on board the Hermes XI rocket include Lt Boyd, Lt Isaacson, and Lt Kmetz. The mission is a standard resupply to the USSS currently in longitude orbit, currently above the Antarctic. After resupply has been established and maintenance has concluded by Lt Isaacson, the crew will conclude orbit and land in the north Pacific ocean. \n";
	private string text2 = "This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text. This is scrolling text.";
	private string[] errors = {"Oxygen pres low.","Fuel not diverting.","Bridge not decoupling.", "Ignition not primed.", "Launch pad vents not open.", "Lt. Boyd not in chair.", "Lights off.", "Map offline"};
	private string error = "";
	// Use this for initialization
	void Start () {
		eG.mystyle = mystyle;
		eG.mystyle2 = mystyle;
	}
	
	// Update is called once per frame
	void Update () {
		if(problems.Count == 6)
		{
			eG.lostGame();
		}
		if (eG.start) {
			matchString ();
			scrollPosition.y += Time.deltaTime*10;
			if (needString) {
				needString = false;
				float rand = 0;
				string temp = "";
				for (int i = 0; i < stringLength; i++) {
					if(eG.time >= 20)
					{
						rand = Random.Range (97, 122);
					}
					else if(eG.time >= 10)
					{
						do
						{
							rand = Random.Range (65, 122);
						}
						while(rand >= 91 && rand <= 96);
					}
					else if(eG.time >= 0)
					{
						do
						{
							rand = Random.Range (48, 122);
						}
						while((rand >= 58 && rand <= 64)||(rand >= 91 && rand <= 96));
					}
					temp += (char)rand;
				}
				problems.Add (temp);
				problemsExp.Add(errors [Random.Range (0, 7)]);
			}
			if (stringToMatch.Equals (stringToEdit) && stringToMatch != "") {
				stringToEdit = "";
				stringToMatch = "";
				error = "";
				problems.RemoveAt (0);
				problemsExp.RemoveAt(0);
			}
		}
	}


	void OnGUI() {
		if (eG.start) {
			GUI.Box (new Rect (Screen.width/5.01f -57.62f, Screen.height/1.5f, 50, 50), problems.Count.ToString (),mystyle);
			GUI.Box (new Rect(Screen.width / 2 - 150 + 2.38f, Screen.height / 2 - 70, 300, 40),"Error Code:",mystyle);
			GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 30, 200, 40), stringToMatch, mystyle2);
			GUI.Box (new Rect(Screen.width / 2 - 150, Screen.height / 2 + 10, 300, 40),"Entry: ",mystyle);
			GUI.SetNextControlName("TextField");
			stringToEdit = GUI.TextField (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 60, 200, 20), stringToEdit, 25, mystyle2);
			GUI.FocusControl("TextField");
			try{
				GUI.BeginScrollView(new Rect(Screen.width / 1.55f +42.16f, Screen.height / 2.53f ,Screen.width/5.5f ,Screen.height/2.6f),scrollPosition,new Rect(0,0,Screen.width/5.5f,3250),scrollStyle,scrollStyle);
			GUI.Label(new Rect(0,0,Screen.width/5.5f,4000),text,scrollStyle);
			GUI.EndScrollView();
			}catch(UnityException e)
			{
			}
			GUI.Box(new Rect(Screen.width/ 6.3f - 27.38f, Screen.height/ 3.5f,Screen.width/5.5f ,Screen.height/2.6f), error ,mystyle);
		}
	}

	void matchString()
	{
		if (problems.Count != 0) {
			stringToMatch = problems[0].ToString();
			error = problemsExp[0].ToString();
		}
	}

	public void needNewString()
	{
		needString = true;
		stringLength ++;
	}

	public void startGame()
	{
		eG.startGame ();
	}
}
