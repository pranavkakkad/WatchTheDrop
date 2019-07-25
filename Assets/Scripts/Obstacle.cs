using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
	int scoreCounter=0;
	int healthCounter=0;
	Rigidbody2D rb;
	void OnEnable(){
		rb = GetComponent<Rigidbody2D> ();
		float vel = Random.Range (-2, 3);
		rb.velocity = new Vector3 (vel,0,0);
	}
	void OnCollisionEnter2D(Collision2D col){
//		Debug.Log (col.gameObject.name);

		if (col.gameObject.CompareTag ("Ground")) {
			scoreCounter++;
//			Debug.Log ("Ground Collider"+ scoreCounter);
			GameManager.Instance.score += 1;
			GameManager.Instance.SetScore ();
			gameObject.SetActive (false);
			if (GameManager.Instance.health <= 0)
				return;
//			PoolManager.Instance.fallPrefab ();

			GameManager.Instance.fallingPrefab ();
		}
		if (col.gameObject.CompareTag ("Player")) {
			healthCounter++;
//			Debug.Log (healthCounter);
			GameManager.Instance.health -= 1;
//			Debug.Log ("Health "+GameManager.Instance.health);
				if (GameManager.Instance.health <= 0) {
					DataManager.instance.setHighScore (GameManager.Instance.score);
					UIManager.Instance.gameView.HideView ();
					UIManager.Instance.gameOverView.ShowView ();
					GameManager.Instance.EndGame ();
					return;
				} else {
					GameManager.Instance.SetHealth ();
				}
				gameObject.SetActive (false);
//			PoolManager.Instance.fallPrefab ();
				GameManager.Instance.fallingPrefab ();
		}
//		PoolManager.Instance.fallPrefab ();
	}
}
