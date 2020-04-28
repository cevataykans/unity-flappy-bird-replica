using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int currentScore;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text restartText;
    private bool birdDied;

    void Awake()
    {
        birdDied = true;

        Text[] texts = GetComponentsInChildren<Text>();
        scoreText = texts[0];
        restartText = texts[1];

        EventHandler.OnBirdDied += DisplayEndGameText;
        EventHandler.OnBirdScore += UpdateScore;

        scoreText.text = "Score: " + currentScore;
    }

    private void Update()
    {
        if ( birdDied && Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.StartGame();
            restartText.gameObject.SetActive(false);
            birdDied = false;
            currentScore = 0;
            scoreText.text = "Score: " + currentScore;
        }
    }

    void DisplayEndGameText()
    {
        birdDied = true;
        restartText.gameObject.SetActive(true);
    }

    void UpdateScore()
    {
        currentScore++;
        scoreText.text = "Score: " + currentScore;
    }
}
