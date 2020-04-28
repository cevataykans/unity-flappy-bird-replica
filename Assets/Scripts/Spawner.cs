using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipe;

    Vector2 spawnPoint;
    float horizontalBound;
    float verticalBound;
    GameObject[] pipes;

    // Start is called before the first frame update
    void Start()
    {
        verticalBound = Camera.main.orthographicSize;
        horizontalBound = verticalBound * Screen.width / Screen.height;
        spawnPoint = new Vector2(horizontalBound + 2, 0);
        pipes = new GameObject[6];

        for ( int i = 0; i < 5; i++)
        {
            pipes[i] = Instantiate(pipe, spawnPoint, Quaternion.identity);
            pipes[i].SetActive(false);
        }

        EventHandler.OnBirdDied += StopSpawner;
        EventHandler.OnGameStart += StartSpawner;
    }

    void SpawnPipes()
    {
        spawnPoint.y = Random.Range(-verticalBound, verticalBound);
        spawnPoint.y = Mathf.Clamp(spawnPoint.y, -3, 3);
        for ( int i = 0; i < pipes.Length; i++)
        {
            if ( pipes[ i].gameObject.activeInHierarchy == false)
            {
                pipes[i].SetActive(true);
                pipes[i].transform.position = spawnPoint;
                return;
            }
        }
    }

    void StopSpawner()
    {
        CancelInvoke();
    }

    void StartSpawner()
    {
        for (int i = 0; i < 5; i++)
        {
            pipes[i].SetActive(false);
        }
        InvokeRepeating("SpawnPipes", 0, 1.2f);
    }
}
