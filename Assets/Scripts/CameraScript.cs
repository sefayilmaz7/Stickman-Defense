using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraScript : MonoBehaviour
{
    public AudioClip gameMusic;

    private Vector3 firstpoint;
    private Vector3 secondpoint;
    private float xAngle = 0.0f; //angle for axes x for rotation
    private float yAngle = 0.0f;
    private float xAngTemp = 0.0f; //temp variable for angle
    private float yAngTemp = 0.0f;


    void Start()
    {
        GetComponent<AudioSource>().clip = gameMusic;
        GetComponent<AudioSource>().Play();


        firstpoint = new Vector3(0, 0, 0);
        secondpoint = new Vector3(0, 0, 0);


        xAngle = 0.0f;
        yAngle = 0.0f;

        transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            //Touch began, save position
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                firstpoint = Input.GetTouch(0).position;
                xAngTemp = xAngle;
                yAngTemp = yAngle;
            }
            //Move finger by screen
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                secondpoint = Input.GetTouch(0).position;
                //Mainly, about rotate camera. For example, for Screen.width rotate on 180 degree
                yAngle = yAngTemp - (secondpoint.y - firstpoint.y) * 90.0f / Screen.height;

                if (yAngle < 0)
                    yAngle += 360;
                if (yAngle > 360)
                    yAngle -= 360;

                if (yAngle > 90 && yAngle < 270)
                    xAngle = xAngTemp - (secondpoint.x - firstpoint.x) * 180.0f / Screen.width;
                else
                    xAngle = xAngTemp + (secondpoint.x - firstpoint.x) * 180.0f / Screen.width;

                if (xAngle < 0)
                    xAngle += 360;

                if (xAngle > 360)
                    xAngle -= 360;

                transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);

            }
        }
    }
}
