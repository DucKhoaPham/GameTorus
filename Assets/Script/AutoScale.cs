using UnityEngine;
using System.Collections;

public class AutoScale : MonoBehaviour {
	private float scaleValue;
	private Vector3 MaxScale;
	private Vector3 MinScale;
	private float scaleStep;
	public float scalingDuration;
	bool scale = true;
	// Use this for initialization
	void Awake () {
		MaxScale = new Vector3 (19.07f, 19.07f, 19.07f);
		MinScale = new Vector3 (15.55f, 15.55f, 15.55f);
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
			if (gameObject.transform.localScale.x > MaxScale.x) {
				scale = false;
			}
			if (gameObject.transform.localScale.x < MinScale.x) {
				scale = true;
			}
		if(scale)
			AlterPlayerScale (0.6f, 20f, scalingDuration);
		else
			ReturnPlayerScale (0.2f, 15f, scalingDuration);
	}
}
