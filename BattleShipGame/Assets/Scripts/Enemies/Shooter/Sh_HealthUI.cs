using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sh_HealthUI : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;

    public Vector3 offset;

    
    void Update()
    {
        slider.transform.position =
            Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

    public void setHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponentInChildren<Image>().color =
            Color.Lerp(low, high, slider.normalizedValue);
    }
}
