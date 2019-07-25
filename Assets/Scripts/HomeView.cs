using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeView : BaseView {

	public void OnPlay(){
		UIManager.Instance.homeView.HideView ();
		UIManager.Instance.gameView.ShowView ();

		GameManager.Instance.GameStart ();
	}
}
