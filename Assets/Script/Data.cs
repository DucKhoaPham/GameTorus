using UnityEngine;
using System.Collections;

public class Data : MonoBehaviour {
	public static Data Instance;
	public int count;
	// Use this for initialization
	void Awake() {
		{
			if (Instance == null)
			{
				DontDestroyOnLoad(gameObject);
				Instance = this;
			}
			else if (Instance != this)
			{
				Destroy (gameObject);
			}
	}
	}


}
