using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreControll : MonoBehaviour {
	Text scoretxt;
	int score;
	public int Score{
		get{
			return this.score;
		}
		set{
			this.score = value;
			UpdateScoreTextUI();
		}
	}

	// Use this for initialization
	void Start () {
		scoretxt = GetComponent<Text> ();	
	}
	
	// Update is called once per frame
		void UpdateScoreTextUI () {
		scoretxt.text = "Score: " + score.ToString ();
	}
}
