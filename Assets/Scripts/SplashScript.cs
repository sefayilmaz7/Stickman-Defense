using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            StartCoroutine(WaitAndDestroy(0.50f));
        }
    }

    private IEnumerator WaitAndDestroy(float waitTime)
    {
        yield return new WaitForSeconds(0.50f);
        Destroy(this.gameObject);
    }
}
