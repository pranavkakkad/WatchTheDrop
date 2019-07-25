using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	public GameObject Player;
	public GameObject Player1;
	public GameState gameState;

	public PoolManager poolManager;


	public bool turnLeft = false;
	public bool turnRight = false;

	public int score=0;
	public int health =3;

	void Awake(){
		Instance = this;
	}

	void Start(){
		gameState = GameState.None;
	}

	public void GameStart(){
		Player.SetActive (true);
		gameState = GameState.game;
//		Debug.Log ("In Game Start");
//		PoolManager.Instance.GenerateObstacles ();
//		PoolManager.Instance.fallPrefab ();

		poolManager.GenerateObstacles ();
		fallingPrefab ();
	}
	public void fallingPrefab(){
		poolManager.fallPrefab();
	}

	public void EndGame (){

//		PoolManager.Instance.DestroyPrefabs ();
//		PoolManager.Instance.DeactivePrefabs();
		poolManager.DeactivePrefabs();
		gameState = GameState.gameOver;
		Player.SetActive (false);
		Player1.SetActive (false);
		UIManager.Instance.gameOverView.score.text = score.ToString ();
		UIManager.Instance.gameOverView.highScore.text = DataManager.instance.getHighScore ().ToString ();
		health = 3;
		score = 0;
		SetScore ();
		SetHealth ();
	}

	public void PauseGame(){
//		PoolManager.Instance.DeactivePrefabs ();
		poolManager.DeactivePrefabs();
		gameState=GameState.pause;
		Player.SetActive (false);
		Player1.SetActive (false);
	}

	public void ResumeGame(){
		gameState = GameState.game;
		Player.SetActive (true);
		Player1.SetActive (true);
//		PoolManager.Instance.fallPrefab ();
		poolManager.fallPrefab();
	}

	public void SetScore(){
		UIManager.Instance.gameView.score.text = "Score: "+score.ToString ();
	}
	public void SetHealth(){
		UIManager.Instance.gameView.health.text = "Health: "+health.ToString ();
	}
}

public enum GameState
{
	home,
	game,
	pause,
	gameOver,
	None
}
