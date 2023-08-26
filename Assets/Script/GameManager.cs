using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	public GUIText highScoreGUIText;		//The high score text
	int playerscore;						//The player's score
	int highScore;							//The high score
	string highScoreKey = "highScore";
	public GameObject Playbtn;
	public GameObject Tilte;
	public GameObject Tilte2;
	public GameObject Menubtn;
	public GameObject quit;
	public GameObject GameOver;
	public GameObject ScoreTxt;
	public GameObject Replay;
	public GameObject Audio;
	public GameObject Player;
	public GameObject DisplayPlayer;
	public GameObject Gamestart;
	public GameObject Menu;
	public enum GameManagerState{
		Opening,
		Gameplay,
		GameOver,
	}
	GameManagerState GMState;
	void Awake(){
		Application.targetFrameRate = 300; 
	}
	void Start ()
	{
		
		Initialize ();
		GMState = GameManagerState.Opening;

	}
	public bool GetOver(){
		if (GMState == GameManagerState.GameOver)
			return true;
		else
			return false;
	}
	void UpdateGameManagerState ()
	{
		if (Application.isPlaying )
			Time.timeScale = 1;
		else
			Time.timeScale = 0;
		switch (GMState) {
		case GameManagerState.Opening:
			Tilte.SetActive (true);
			Tilte2.SetActive (true);
			Replay.SetActive (false);
			ScoreTxt.GetComponent<Text> ().enabled = false;
			highScoreGUIText.GetComponent<GUIText>().enabled = false;
			highScoreGUIText.text = "HighScore : " + highScore.ToString ();
			quit.SetActive (true);
			Menubtn.SetActive (false);
			Playbtn.SetActive (true);
			Player.SetActive (false);
			DisplayPlayer.SetActive (false);
			break;
		case GameManagerState.Gameplay:	
			Tilte.SetActive (false);
			Tilte2.SetActive (false);
			Gamestart.GetComponent<Emitter> ().Initiate ();
			Player.SetActive (true);
			DisplayPlayer.SetActive (true);
			ScoreTxt.GetComponent<Text> ().enabled = true;
			Replay.SetActive (false);
			Replay.SetActive (false);
			Playbtn.SetActive (false);
			quit.SetActive (false);
			Menubtn.SetActive (true);
			highScoreGUIText.GetComponent<GUIText> ().enabled = false;
			highScoreGUIText.text = "HighScore : " + highScore.ToString ();
			break;
		case GameManagerState.GameOver:
			Time.timeScale = 0;
			Menubtn.SetActive (false);
			Audio.GetComponent<AudioSource> ().Play ();
			highScoreGUIText.GetComponent<GUIText>().enabled = true;
			playerscore = ScoreTxt.GetComponent<ScoreControll> ().Score;
			if (highScore <= playerscore) {
				highScore = playerscore;
			}
			highScoreGUIText.text = "HighScore : " + highScore.ToString ();
			Save ();
			Replay.SetActive (true);
			quit.SetActive (true);
			break;
		}
	}
	public void SetGameManagerState(GameManagerState state){
		GMState = state;
		UpdateGameManagerState();

	}
	public GameManagerState Stategame(){
		return GMState;
	}
	public void StartGame(){
		Initialize ();
		GMState = GameManagerState.Gameplay;
		UpdateGameManagerState();

	}
	public void ChangeToOpeningState(){

		Time.timeScale=1;
		SceneManager.LoadScene (0);
	}
	public void Save ()
	{
		//Save the highscore to the player prefs
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.Save ();
		//Re initialize the score
		Initialize ();
	}
	public void MenuUI(){
		Menubtn.SetActive (false);
		Time.timeScale = 0;
		Menu.SetActive (true);
	}
	public void ResumeGame(){
		Time.timeScale = 1;
		Menubtn.SetActive (true);
		Menu.SetActive (false);
	}
	private void Initialize ()
	{
		//Reset the score and get the high score from the playerprefs
		playerscore = 0;
		highScore = PlayerPrefs.GetInt (highScoreKey);
	}

	public void quitGame(){
		Application.Quit();
	}
}