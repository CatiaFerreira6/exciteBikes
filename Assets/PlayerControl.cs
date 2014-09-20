using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float JumpForce = 10;

	public int clicks = 0;

	public bool AInput = false;
	 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(!AInput)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				clicks++;
				switch(clicks)
				{
				case 1:
					this.rigidbody2D.AddForce(Vector2.up * JumpForce * Mathf.Sign(this.rigidbody2D.gravityScale));
					break;
				case 2:
					this.rigidbody2D.gravityScale *= -1;
					break;
				default:
					break;
				}
			}
			if(Input.GetKeyDown(KeyCode.R))
				Application.LoadLevel(0);
		}
		else
		{
			if(Input.touchCount > 0)
			{
				if(Input.touches[0].phase == TouchPhase.Began)
				{
					clicks++;
					switch(clicks)
					{
					case 1:
						this.rigidbody2D.AddForce(Vector2.up * JumpForce * Mathf.Sign(this.rigidbody2D.gravityScale));
						break;
					case 2:
						this.rigidbody2D.gravityScale *= -1;
						break;
					default:
						break;
					}
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		clicks = 0;
	}
}
