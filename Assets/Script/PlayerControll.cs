using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {
	private float scaleValue;
	private Vector3 MaxScale;
	private Vector3 MinScale;
	private float scaleStep;
	public float scalingDuration;
	// Use this for initialization
	void Awake () {
		MaxScale = new Vector3 (0.155f, 0.155f, 0.155f);
		MinScale = new Vector3 (0.02f, 0.02f, 0.02f);
	}
	public void AlterPlayerScale(float scaleValue, float initMagnitude, float scalingDuration){
		//set scaling amount for scaling player    
		Vector3 newScale = new Vector3(initMagnitude+scaleValue, 
			initMagnitude+scaleValue, 
			initMagnitude+scaleValue);

		//scaling step
		scaleStep = Time.deltaTime*scalingDuration;

		//alter player's scale
		transform.localScale = Vector3.Lerp(transform.localScale, 
			newScale, 
			scaleStep);
	}
	public void ReturnPlayerScale(float scaleValue, float initMagnitude, float scalingDuration){
		//set scaling amount for scaling player    
		Vector3 newScale = new Vector3(initMagnitude-scaleValue, 
			initMagnitude-scaleValue, 
			initMagnitude-scaleValue);

		//scaling step
		scaleStep = Time.deltaTime*scalingDuration;

		//alter player's scale
		transform.localScale = Vector3.Lerp(transform.localScale, 
			newScale, 
			scaleStep);
	}
	// Update is called once per frame
	void Update () {
		//if (Input.GetTouch (0).phase == TouchPhase.Stationary)
		if (Input.GetMouseButton (0)) {
			if (gameObject.transform.localScale.x < MaxScale.x) {
				AlterPlayerScale (0.01f, 0.155f, scalingDuration);
			}
		} else {
			if (gameObject.transform.localScale.x > MinScale.x) {
				ReturnPlayerScale (0.01f, 0.02f, scalingDuration);
			}
		}
	}
}
