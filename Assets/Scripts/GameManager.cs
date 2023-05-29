using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int score;
    public Text scoreText;
    public int highScore;
    public Text highScoreText;
    [Header("Game over Elements")]

    public GameObject gameOverPanel;

    [Header("Sounds")]
    public AudioClip[] sliceSounds;
    private AudioSource audioSource;
    public AudioClip bombSound;
    private void Awake()
    {
        audioSource =GetComponent<AudioSource>();
        gameOverPanel.SetActive(false);
        //PlayerPrefs.SetInt("Highscore", 0);
        GetHighScore();

    }

    private void GetHighScore()
    {
        highScore =PlayerPrefs.GetInt("Highscore");
        highScoreText.text="Best: " +highScore;
    }

    public void IncreaseScore(int num)
    {
        score+=2;
        scoreText.text=score.ToString();
        if(score > highScore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text="Best: "+score.ToString();
        }
    }

    public void OnBombHit()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        FindObjectOfType<GameManager>().PlayBombSound();
        Debug.Log("Bomb hit");
    }

    public void RestartGame()
    {
        score = 0;
        scoreText.text= "0";
        gameOverPanel.SetActive(false);
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }

        GetHighScore();
        Time.timeScale=1;

    }

    public void PlayRandomSliceSound()
    {
        AudioClip randomSound=sliceSounds[Random.Range(0, sliceSounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }

    public void PlayBombSound()
    {
        AudioClip bombSound_=bombSound;
        audioSource.PlayOneShot(bombSound_);

    }
}
