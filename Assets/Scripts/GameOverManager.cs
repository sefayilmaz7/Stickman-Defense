using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text totalScore;

    public AudioClip gameOverSound;

    void Start()
    {
        totalScore.text = PlayerPrefs.GetInt("TotalScore").ToString();
        GetComponent<AudioSource>().clip = gameOverSound;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void JumpMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
