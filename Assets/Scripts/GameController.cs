using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;

    public int score = 0;

    public Text scoreText;
    public Text tipsText;

    public GameObject enemy;

    private Vector3 randomPosition;

    private float randomX;
    private float timeRemaining = 3;

    public AudioClip splashSound;

    private void Start()
    {
        GetComponent<AudioSource>().clip = splashSound;
        StartCoroutine(DestroyText(2));
    }
    void Update()
    {
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("TotalScore", score);

        randomX = Random.Range(-5.2f, 5.2f);
        // creating enemy after 3 seconds
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                SpawnEnemy();
                timeRemaining = 3;
            }
        }

        // Handling if game is over
        if(BaseController.instance.baseHealth == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void SpawnEnemy()
    {
        randomPosition = new Vector3(randomX, -1.097f, 72.1f);
        Instantiate(enemy, randomPosition, GameObject.FindGameObjectWithTag("StickmanPos").transform.rotation);
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void HitSoundPlay()
    {
        GetComponent<AudioSource>().Play();
    }

    private IEnumerator DestroyText(float waitTime)
    {
        yield return new WaitForSeconds(2);
        Destroy(tipsText.gameObject);
    }

}
