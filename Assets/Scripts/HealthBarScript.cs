using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Image fill;
    public Slider slider;

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    private void Update()
    {
        SetHealth(BaseController.instance.baseHealth);

        // setting fill color
        if(slider.value < 5 && slider.value > 3)
        {
            fill.color = Color.yellow;
        }
        else if(slider.value < 3)
        {
            fill.color = Color.red;
        }
    }
}
