using UnityEngine;
using System.Collections;

//This script controls the waves of enemies
public class Emitter : MonoBehaviour
{

	public GameObject ObjectGo;
	public GameObject RandomSpeed;
	public GameObject[] models;		//Prefabs of the waves of enemies
	private int index;
	GameObject obj;
	int valid=0;
	void Awake(){
		for (int i = 0; i < models.Length; i++) {
			for (int k = 0; k < 5; k++) {
				GameObject obj = ObjectPool.current.GetObject (models [i]);
				ObjectPool.current.PoolObject (obj);
			}

		}
	}
	void ActiveObject(){
		obj.SetActive (true);
		Spawn ();
	}
	public void Initiate(){
		index = Random.Range (0, models.Length  );
		if (index == 4) {
			RandomSpeed.GetComponent<Speed> ().goRandom ();
			valid = Random.Range (0, 2);
			if (valid == 1)
				ObjectGo.GetComponent<ObjectControll> ().Callfirst ();
		}
		obj = ObjectPool.current.GetObject (models [index]);
	
		obj.SetActive (true);
			index = Random.Range (0, models.Length );
		if (index == 4) {
			RandomSpeed.GetComponent<Speed> ().goRandom ();
			valid = Random.Range (0, 2);
			if (valid == 1)
				ObjectGo.GetComponent<ObjectControll> ().CallObject ();
		}
		obj = ObjectPool.current.GetObject (models [index]);
	
		Invoke ("ActiveObject", 4.5f);
	}
	//This is set up as a coroutine 
	void Spawn()
	{
			index = Random.Range (0, models.Length );
		if (index == 4) {
			RandomSpeed.GetComponent<Speed> ().goRandom ();
			valid = Random.Range (0, 2);
			if (valid == 1)
				ObjectGo.GetComponent<ObjectControll> ().CallObject ();
		}
		obj = ObjectPool.current.GetObject (models [index]);
		Invoke ("ActiveObject", 4.5f);
	}
}