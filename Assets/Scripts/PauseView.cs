using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseView : BaseView {
	public void OnResume(){
		UIManager.Instance.pauseView.HideView ();
		UIManager.Instance.gameView.ShowView ();
		GameManager.Instance.ResumeGame ();
	}

	public void OnHome(){
		UIManager.Instance.pauseView.HideView ();
		UIManager.Instance.homeView.ShowView ();
		GameManager.Instance.EndGame ();
	}
}
