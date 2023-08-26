using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelReset :MonoBehaviour , IPointerClickHandler
{
    public void OnPointerClick(PointerEventData data)
    {
		Time.timeScale = 1;
        // reload the scene
        SceneManager.LoadScene(0);

    }

}
