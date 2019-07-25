using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : BaseView {

	public Text score;
	public Text health;

	public void OnPause(){
		UIManager.Instance.gameView.HideView ();
		UIManager.Instance.pauseView.ShowView ();
		GameManager.Instance.PauseGame ();
	}
}
