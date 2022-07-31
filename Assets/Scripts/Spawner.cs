using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float minDistanceBetweenObjects;
    private Vector2 spawnArea;
    private Vector2 spawnPosition;
    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Awake()
    {
        Camera cam = Game.cam;
        spawnArea = new Vector2(cam.orthographicSize, cam.orthographicSize * 2) * 0.8f;
    }

    public void Spawn(GameObject prefab, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            CalculateRandomPositionInsideSpawnArea();
            bool uniqePos = true;
            int attempsCount = 0;
            while (true)
            {
                attempsCount++;
                foreach (GameObject obj in spawnedObjects)
                {
                    if (Vector2.Distance(spawnPosition, obj.transform.position) < 3)
                    {
                        uniqePos = false;
                    }
                }
                if (uniqePos || attempsCount >= 100)
                {
                    break;
                }
                CalculateRandomPositionInsideSpawnArea();
                uniqePos = true;
            }
            if (attempsCount < 100)
            {
                var newObj = Instantiate(prefab, spawnPosition, prefab.transform.rotation);
                spawnedObjects.Add(newObj);
            }
        }
    }

    private void CalculateRandomPositionInsideSpawnArea()
    {
        var xPosition = Random.Range(-spawnArea.x / 2, spawnArea.x / 2);
        var yPosition = Random.Range(-spawnArea.y / 2, spawnArea.y / 2);
        spawnPosition = new Vector2(xPosition, yPosition);
    }
}
