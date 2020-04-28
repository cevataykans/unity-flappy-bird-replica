using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public GameObject bird;
    public Transform birdSpawnPoint;

    private void Awake()
    {
        if ( Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        bird.SetActive(false);
        EventHandler.OnBirdDied += ResetBird;

        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        EventHandler.TriggerOnGameStart();
        bird.SetActive(true);
        bird.transform.position = birdSpawnPoint.position;
    }

    private void ResetBird()
    {
        bird.SetActive(false);
    }
}
