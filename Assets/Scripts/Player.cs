using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float PlayerDirection=0.0f;
	public float speed=10.0f;
	public float rate=10.0f;
	float PlayerDistance;
	bool mouseButton;
	public bool canRotate=true;
	public bool rotatePlayer =true;
	public Vector3 initialPlayerPosition;
	public Vector3 initialPlayerClonePosition;
	public GameObject PlayerClone;

	void Start(){
		mouseButton = true;
		this.gameObject.SetActive (false);
		PlayerDistance = Distance ();
		initialPlayerPosition = this.gameObject.transform.position;
		initialPlayerClonePosition = PlayerClone.transform.position;
	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Inside");
			if (mouseButton) {
				PlayerDirection = -1;
				rotatePlayer = true;
//				RotatePlayer ();
//				MovePlayer ();
				Debug.Log ("Hi");
				mouseButton=false;
			}
			else if (!mouseButton) {
				PlayerDirection = 1;
				rotatePlayer = false;
//				RotatePlayer ();
//				MovePlayer ();
				Debug.Log ("Hi there");
				mouseButton=true;
			}
		}
//		if (Input.GetKey (KeyCode.LeftArrow)) {
//			PlayerDirection = -1;
//			rotatePlayer = true;
////			RotatePlayer ();
////			MovePlayer ();
//
//		}
//		if (Input.GetKey (KeyCode.RightArrow)) {
//			PlayerDirection = 1;
//			rotatePlayer = false;
////			RotatePlayer ();
////			MovePlayer ();
//
//		}
		RotatePlayer();
		MovePlayer ();
	}

	public void MovePlayer(){
		Vector3 position = this.transform.position;
		position.x += PlayerDirection/rate;
		position.x = Mathf.Clamp (position.x,initialPlayerPosition.x-5,initialPlayerClonePosition.x+2);
		if (position.x < initialPlayerPosition.x-5 || position.x > initialPlayerClonePosition.x+2) {
			position = initialPlayerPosition;
		}
		this.transform.position = position;


	}


	float Distance(){
		return Mathf.Abs(this.transform.position.x-PlayerClone.transform.position.x);
	}

	void OnTriggerEnter2D(Collider2D col){
		canRotate = true;
//		Debug.Log ("Entered"+col.gameObject.name);
		Vector3 newPosition = this.transform.position + new Vector3(PlayerDistance,0,0);
		PlayerClone.transform.position = newPosition;
	}

	void OnTriggerStay2D(Collider2D col){
//		Debug.Log ("you can stay");
		FlipPlayer ();
	}

	void OnTriggerExit2D(){
		canRotate = false;
//		Debug.Log ("Exit trigger");
		this.transform.position = PlayerClone.transform.position;
		PlayerClone.transform.position = new Vector3 (100f, 100f, 100f);
	}

	void FlipPlayer ()
	{
		Vector3 newPosition;
		if (transform.position.x < (Screen.width / 2))
			newPosition = this.transform.position + new Vector3 (PlayerDistance, 0, 0);
		else {
			newPosition = this.transform.position - new Vector3 (PlayerDistance, 0, 0);
		}
		PlayerClone.transform.position = newPosition;
	}


//	void OnCollisionEnter(Collision col){
//		Debug.Log ("Collided");
//		if (col.gameObject.CompareTag ("Collider")) {
//			Destroy (col.gameObject);	
//			GameManager.Instance.Score -= 1;
//			Debug.Log (GameManager.Instance.Score);
//		}
//	}

	void RotatePlayer(){
		if (rotatePlayer) {
			this.transform.eulerAngles=new Vector3(0, 180f, 0); 
			if(canRotate)
			PlayerClone.transform.eulerAngles = new Vector3 (0, 180f, 0);
		} else {
			this.transform.eulerAngles = new Vector3 (0,0,0);
			if(canRotate)
			PlayerClone.transform.eulerAngles = new Vector3 (0, 0f, 0);
		}
	}
}
