using UnityEngine;
using System.Collections;

public class CollisionObject : MonoBehaviour {
	GameObject GameManagerUI;
	void Awake(){
		GameManagerUI = GameObject.FindGameObjectWithTag ("GameManager");
	}
	void OnCollisionEnter (Collision col){
		GameManagerUI.GetComponent<GameManager> ().SetGameManagerState (GameManager.GameManagerState.GameOver);
	}
}
