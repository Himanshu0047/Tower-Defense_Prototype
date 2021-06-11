using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] Text scoreText;

    int score = 0;

    private void Start()
    {
        healthText.text = "Lives: " + health.ToString();
        scoreText.text = "Score: " + score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if (health > 0)
            {
                health -= healthDecrease;
                healthText.text = "Lives: " + health.ToString();
            }
        }
    }

    public void UpdateScore()
    {
        score += 25;
        scoreText.text = "Score: " + score.ToString();
    }

}
