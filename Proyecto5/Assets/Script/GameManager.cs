using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    public List<Vector3> targetPosition;
    public bool isGameOver;

    private float minX = -3.75f;
    private float minY = -3.75f;
    private float distancesBtweenSquare = 2.5f;
    private float spawnRate = 2f;
    private Vector3 randomPos;
   
    
    void Start()
    {
        StartCoroutine(SpawnRandomTarget());   
    }

    
    void Update()
    {
        
    }

    private Vector3 RandomSpawnPosition()
    {
        int saltoX = Random.Range(0, 4);
        int saltoY = Random.Range(0, 4);

        float SpawnPosX = minX + saltoX * distancesBtweenSquare;
        float SpawnPosY = minY + saltoY * distancesBtweenSquare;
        return new Vector3(SpawnPosX, SpawnPosY, 0);

    }

    private IEnumerator SpawnRandomTarget()
    {
        while(!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, targetPrefabs.Length);
            randomPos = RandomSpawnPosition();
            while (targetPosition.Contains(randomPos))
            {
                randomPos = RandomSpawnPosition();
            }

            Instantiate(targetPrefabs[randomIndex], RandomSpawnPosition(), targetPrefabs[randomIndex].transform.rotation);
            targetPosition.Add(randomPos);
        }

    }
}
