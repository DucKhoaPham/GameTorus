using UnityEngine;
using System.Collections;

public class ObjectControll : MonoBehaviour {
	public GameObject models;		//Prefabs of the waves of enemies
	private int index;
	GameObject obj;
	void ActiveObject(){
		obj.SetActive (true);
	}
	public void CallObject(){
		obj = ObjectPool.current.GetObject (models);
		Invoke ("ActiveObject", 4.5f);
	}
	public void Callfirst(){
		obj = ObjectPool.current.GetObject (models);
		Invoke ("ActiveObject", 0.4f);
	}

}