using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    public void StartGame()
    {
        Application.LoadLevel(name: "GamePlayer");
    }

    public void OptionMenu()
    {
        Application.LoadLevel(name: "OptionMenu");
    }

    public void BackMain()
    {
        Application.LoadLevel(name: "MainMenu");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
