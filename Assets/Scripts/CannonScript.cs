using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public AudioClip shotSound;

    public float damage = 10f;

    public Camera fpsCamera;
    // Cannon firing variables

    public GameObject cannonBall;
    public GameObject explosion;
    
    Rigidbody cannonBallRB;

    public Transform shotPos;

    public float firePower = 500;

    private void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = shotSound;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GetComponent<AudioSource>().Play();
        GameObject cannonBallCopy = Instantiate(cannonBall, shotPos.position, transform.rotation) as GameObject;
        cannonBallRB = cannonBallCopy.GetComponent<Rigidbody>();
        cannonBallRB.AddForce(-transform.right * firePower);
        Instantiate(explosion, shotPos.position, shotPos.rotation);       
    }
}
