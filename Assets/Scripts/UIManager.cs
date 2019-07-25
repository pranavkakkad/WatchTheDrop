using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public static UIManager Instance;

	public HomeView homeView;
	public GameView gameView;
	public PauseView pauseView;
	public GameOverView gameOverView;

	void Awake(){
		Instance = this;
	}

	void Start(){
		homeView.ShowView ();
	}
}
