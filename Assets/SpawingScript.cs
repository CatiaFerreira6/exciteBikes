using UnityEngine;
using System.Collections;

public class SpawingScript : MonoBehaviour {


	public GameObject chunkToBeDestroyed;
	public GameObject runningChunk;
	public GameObject NewlySpawnedChunk;
	public Object[] chunks;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(NewlySpawnedChunk.transform.position.x <= 0)
		{
			if(chunkToBeDestroyed != null)
				Destroy(chunkToBeDestroyed, 0f);

			chunkToBeDestroyed = runningChunk;
			runningChunk = NewlySpawnedChunk;
			NewlySpawnedChunk = (GameObject)Instantiate(chunks[Random.Range(0, chunks.Length)], this.transform.position, Quaternion.identity);


		}
	}
}
