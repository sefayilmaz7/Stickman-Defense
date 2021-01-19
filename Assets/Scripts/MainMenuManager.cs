using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Text totalScore;
    // Start is called before the first frame update
    void Start()
    {
        totalScore.text = PlayerPrefs.GetInt("TotalScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
