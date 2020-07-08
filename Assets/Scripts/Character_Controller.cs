/* Copyright (c) Yumish R. Niroula
	2017
*/


using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour {

	// Have fun typing this shit ma nigga
	
	public float MoveSpeed = 5;
	public float Sensitivity = 5;
	public Camera MainCam;
	public float JumpForce = 4;




	private float vertVelo;
	private CharacterController Player;
	private float MoveFB;
	private float MoveLR;
	private bool isGrounded;
	private float RotX;
	private float RotY;
	private bool HasJumped;

	void Start () {
		
		Player = this.GetComponent<CharacterController> ();

		Screen.lockCursor = true;

	}

	void Update () {
		Movement ();

		Gravity ();

		if (Input.GetKeyDown (KeyCode.Space)) {
			
			HasJumped = true;

		}

	}

	void FixedUpdate () {
		
		LimitView ();

	}












	private void Movement() {
		
		MoveFB = Input.GetAxis ("Vertical") * MoveSpeed;
		MoveLR = Input.GetAxis ("Horizontal") * MoveSpeed;


		Vector3 Movement = new Vector3 (MoveLR, vertVelo, MoveFB);
		Movement = this.transform.rotation * Movement;
		Player.Move (Movement * Time.deltaTime);


		RotX = Input.GetAxis ("Mouse X") * Sensitivity;
		RotY = Input.GetAxis ("Mouse Y") * -Sensitivity;
		this.transform.Rotate (0,RotX,0);

	}


	private void Gravity () {
		
		if (Player.isGrounded == true) {
			
			if (HasJumped == false) {
				
				vertVelo = Physics.gravity.y;

			} else {
				
				vertVelo = JumpForce;

			}

		} else {
			
			vertVelo += Physics.gravity.y * Time.deltaTime;
			HasJumped = false;

		}

	}


	private void LimitView () {
		
		if (MainCam.transform.localEulerAngles.y != 180) {
			
			MainCam.transform.Rotate (RotY, 0, 0);

		} else if (MainCam.transform.localEulerAngles.y == 180 && MainCam.transform.localEulerAngles.x > 270) {
			
			MainCam.transform.Rotate ( +0.5f, 0, 0);

		}


		if (MainCam.transform.localEulerAngles.y == 180 && MainCam.transform.localEulerAngles.x < 91) {
			
			MainCam.transform.Rotate (-0.5f, 0, 0);

		}

	}

	private void Crouch () {
		if (Input.GetKey (KeyCode.LeftControl)) {
			Player.height = Player.height / 2;
		}
	}
}
