using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    string health;
    public Text healthText;

    // Update is called once per frame
    void Update()
    {
        health = PlayerPrefs.GetString("_health");
        healthText.text = health;
    }
}
