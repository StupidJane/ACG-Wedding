using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawning : MonoBehaviour
{
    public GameObject[] balloonPrefabs;
    public int numBalloons;
    public float spawnRadius;
    public int maxTotalBalloons;
    private int numDestroyedBalloons = 0;

    // Specify the area in which balloons will spawn
    public Vector3 spawnAreaCenter;
    public Vector3 spawnAreaSize;

    private List<GameObject> destroyedBalloons = new List<GameObject>();

    private void Start()
    {
        // Spawn balloons
        for (int i = 0; i < numBalloons; i++)
        {
            SpawnBalloon();
        }
    }

    private void SpawnBalloon()
    {
        // Choose a random balloon prefab from the array
        int randIndex = Random.Range(0, balloonPrefabs.Length);
        GameObject balloonPrefab = balloonPrefabs[randIndex];

        // Calculate random position within the specified area
        Vector3 randomPos = spawnAreaCenter + new Vector3(
            Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
            Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f),
            Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f));
        //randomPos.y = Random.Range(0f, 7f);
        // Instantiate the chosen balloon prefab at the random position
        GameObject balloon = Instantiate(balloonPrefab, randomPos, Quaternion.identity);

        balloon.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        balloon.GetComponent<BalloonBehaviour>().balloonSpawning = this;
    }

    public void BalloonDestroyed(GameObject balloon)
    {
        numDestroyedBalloons++;

        if (numDestroyedBalloons < maxTotalBalloons)
        {
            destroyedBalloons.Add(balloon);
            SpawnBalloon();
        }
    }
}
