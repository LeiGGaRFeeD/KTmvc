using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerView : MonoBehaviour
{
    public Text healthText = GameObject.FindWithTag("TXT").GetComponent<Text>();

    public void UpdateHealthText(int health)
    {
        PlayerPrefs.SetString("_health", "Health: " + health.ToString());
      //  healthText.text = "Health: " + health.ToString();
    }

    public void ShowPlayerDeath()
    {
        SceneManager.LoadScene("SampleScene");
    }
}