using UnityEngine;
using System.Collections;

public class BikeControl : MonoBehaviour {

	public KeyCode AccelKey;
	public KeyCode BreakKey;
	public KeyCode NitroKey;

	public float TopSpeed = 150;
	public float NitroSpeedUp = 50;
	public float Acceleration = 10;
	public float BreakForce = 25;
	public float DragForce = 1;

	public float Speed = 0;
	public int NitrosLeft = 2;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Speed = this.rigidbody2D.velocity.x;
		if(Input.GetKey(AccelKey) && Speed < 100)
		{
			this.rigidbody2D.AddForce(Vector2.right * Acceleration);
		}

		if(Input.GetKey(BreakKey) && Speed > 0)
		{
			this.rigidbody2D.AddForce(Vector2.right * -BreakForce);
		}

		if(Input.GetKeyDown(NitroKey))
		{
			Vector2 vel = this.rigidbody2D.velocity;
			if(vel.x + NitroSpeedUp > TopSpeed)
				vel.x = TopSpeed;
			else
				vel.x += NitroSpeedUp;
			this.rigidbody2D.velocity = vel;
		}

		Vector2 temp = this.rigidbody2D.velocity;
		if(Speed > 0)
		{
		temp.x -= DragForce;

		}
		else
			temp.x = 0;

		this.rigidbody2D.velocity = temp;


		if(Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel(0);
		}

	}
}
