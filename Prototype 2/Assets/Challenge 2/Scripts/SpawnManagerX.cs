using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
	public GameObject[] ballPrefabs;

	private float spawnLimitXLeft = -22;
	private float spawnLimitXRight = 7;
	private float spawnPosY = 30;

	// Spawn random ball at random x position at top of play area
	public void SpawnRandomBall()
	{
		// Generate random ball index and random spawn position
		Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

		int index = Random.Range(0, ballPrefabs.Length);
		// instantiate ball at random spawn location
		Instantiate(ballPrefabs[index], spawnPos, ballPrefabs[index].transform.rotation);
	}
}
