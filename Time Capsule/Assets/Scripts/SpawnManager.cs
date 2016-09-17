using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public int initialPlatforms = 10;
	public GameObject platform;
	public float GroundSpawnDifference = 3f;


	private Vector2 originPosition;
	private float positionLastVisited = 0f;

	void Start () {

		originPosition = new Vector2(0f, 0f);
		Spawn ();

	}

	void Spawn()
	{
		
		for (int i = 1; i < initialPlatforms; i++)
		{
			Vector2 randomPosition = originPosition + new Vector2 (GroundSpawnDifference, 0f);
			originPosition = randomPosition;
		    Instantiate (platform, randomPosition, Quaternion.identity);
		}
	}

	void FixedUpdate() 
	{
		
		if (positionLastVisited + 0.8f < transform.position.x)
		{
			Vector2 toAdd = new Vector2 (30f, 0f);
			Vector2 platformPosition = new Vector2(transform.position.x, 0f) + toAdd;
			Instantiate (platform, platformPosition, Quaternion.identity);
			positionLastVisited = transform.position.x;
		}

	}

}