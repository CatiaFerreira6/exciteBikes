using UnityEngine;
using System.Collections;

public class ChunkBehaviour : MonoBehaviour {

	public float speed = 0.01f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(-Vector2.right * speed);
	}
}
