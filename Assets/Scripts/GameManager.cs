using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [Header("Score Elements")]
    public int score;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;

    [Header("GameOver")]
    public GameObject gameOverPanel;
    public Text gameOverScorePanelText;
    public Text gameOverBestScorePanelText;

    [Header("Sounds")]
    public AudioClip[] sliceSounds;
    private AudioSource audioSource;
    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverPanel.SetActive(false);
        GetScore();
    }
    private void GetScore()
    {
        highScore = PlayerPrefs.GetInt("Highscore");
        highScoreText.text = "Best: " + highScore.ToString();
    }
    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text=score.ToString();
        if (score > highScore) {
            PlayerPrefs.SetInt("Highscore", score);
            highScore = score;
            highScoreText.text="Best: "+highScore.ToString();
        }
    }
    public void OnBombHit() {
        Time.timeScale = 0;  //Stop the game
        gameOverScorePanelText.text="Score: "+score.ToString();
        gameOverBestScorePanelText.text = "Best: " + highScore.ToString();
        gameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        score = 0;
        scoreText.text = score.ToString();
        gameOverPanel.SetActive(false);

        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }
        Time.timeScale = 1;
    }
    public void playSlicedSound()
    {
        AudioClip sound = sliceSounds[Random.Range(0,sliceSounds.Length)];
        audioSource.PlayOneShot(sound);
    }
}
