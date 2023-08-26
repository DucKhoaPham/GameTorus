using UnityEngine;
using System.Collections;

public class Speed : MonoBehaviour {
	public float speed;
	// Use this for initialization
	public void goRandom(){
		speed = Random.Range (0.3f, 1f);
	}
}
