using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanController : MonoBehaviour
{
    public GameObject splash;

    public Transform stickmanPos;

    bool isMoving;

    Animator anim;

    public float enemySpeed = 0.06f;

    void Start()
    {
        isMoving = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
            gameObject.transform.position -= new Vector3(0, 0, enemySpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(this.gameObject);
            GameController.instance.HitSoundPlay();
            Instantiate(splash, stickmanPos.position, stickmanPos.rotation);
            GameController.instance.score += 1;
            enemySpeed += 0.0002f;
        }
    }

}
