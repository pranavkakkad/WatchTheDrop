using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {
//	public static PoolManager Instance;

	public GameObject leftPosition;
	public GameObject rightPosition;

	public GameObject CubePrefab;
	public GameObject SpherePrefab;
	public int count = 10;
	float time1;

	Rigidbody2D rb;
	public List<GameObject> prefabs = new List<GameObject>();
	void Awake(){
//		Instance = this;
	}
	void Start(){
//		GenerateObstacles ();
//		time1 = Time.time;

	}

	void Update(){
//		Debug.Log (Time.time - time1);
//		if (GameManager.Instance.gameState ==GameState.game) {
//			if (Time.time - time1 > 3f) {
//				fallPrefab ();
//				time1 = Time.time;
//
//			}
//		}
//

	}


	public void GenerateObstacles(){
		for (int i = 0; i < count; i++) {
			if (Random.Range(0,10) >5) {
				GameObject temp = Instantiate (CubePrefab);
				temp.SetActive (false);
				prefabs.Add(temp);

			} else {
				GameObject temp = Instantiate (SpherePrefab);
				temp.SetActive (false);
				prefabs.Add (temp);
			}
		}
//		fallPrefab ();
	}

	public void DestroyPrefabs(){
		for (int i = 0; i < prefabs.Count; i++) {
			Destroy (prefabs[i]);
			prefabs.Clear ();
		}
	}

	public void fallPrefab(){
		int index= Random.Range(0,prefabs.Count-1);
		float range = rightPosition.transform.position.x - leftPosition.transform.position.x;
//		Debug.Log(leftPosition.transform.position.x + " : "+rightPosition.transform.position.x);
		float xRange = Random.Range (leftPosition.transform.position.x,rightPosition.transform.position.x);
		float part = range / 5;
		int partSelect =Random.Range(-2,3);
//		Debug.Log ("XRange "+xRange);
		prefabs [index].transform.position = new Vector3 (xRange, 966, 0);//Camera.main.ScreenToWorldPoint(new Vector3(xRange,Screen.height,0));
//		prefabs [index].transform.position = new Vector3(prefabs [index].transform.position.x,prefabs [index].transform.position.y,0);

//		if (xRange > Screen.width / 2) {
////			Debug.Log ("1");
//
//			rb.velocity = new Vector3 (10,0,0);
//		}
//		if (xRange < Screen.width / 2) {
////			Debug.Log ("2");
//			rb.velocity = new Vector3 (10,0,0);
//		}
		prefabs [index].SetActive (true);
	}

	public void DeactivePrefabs(){
		for (int i = 0; i < prefabs.Count; i++) {
			prefabs [i].SetActive (false);
		}
	}
}