using UnityEngine;
using System.Collections;

public class DeActive : MonoBehaviour {
	GameObject scoretxt;
	void OnEnable(){
		Invoke ("Die", 10f);
	}
	void Start(){
		scoretxt = GameObject.FindGameObjectWithTag ("Score"); 
	// Update is called once per frame
	}
	void ScoreUI(){
			scoretxt.GetComponent<ScoreControll> ().Score += 1;
	}
	void Die () {
			ObjectPool.current.PoolObject (gameObject);
		ScoreUI ();
	}
}
