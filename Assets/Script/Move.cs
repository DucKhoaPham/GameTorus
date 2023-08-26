using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	GameObject RandomSpeed;
	float speed;
	bool dir;
	// Use this for initialization
	void Start () {
		RandomSpeed = GameObject.FindGameObjectWithTag ("Speed");
		transform.position = new Vector3(transform.position.x, transform.position.y, 0.916f);
	}
	
	// Update is called once per frame
	void Update () {
		speed = RandomSpeed.GetComponent<Speed> ().speed;
		Vector2 position = transform.position;
		if (transform.position.x >= 2.463f)
			dir = false;
		if (transform.position.x <= -2.463f)
			dir = true;
		if(dir)
			position = new Vector3 (position.x + speed * Time.deltaTime, position.y, 0.916f);
		else
			position = new Vector3 (position.x - speed * Time.deltaTime, position.y, 0.916f);
		transform.position = position;
	}
}
