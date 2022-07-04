using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static float health=3;
    public static int score;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveText;
    public Animator anime;

    
    // Start is called before the first frame update
    void Start()
    {
        anime = gameObject.GetComponentInChildren<Animator>();
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health;
        scoreText.text = "Score: " + score;
        waveText.text = "Wave: " + SpawnManager.waveNumber;

        if (health == 0)
        {
            StartCoroutine(Die());
            
        }
    }
   IEnumerator Die()

    {
        // plays death animation, disables player movement
        //and changes isGameActive to false, which will trigger game over screen
        anime.Play("Death_01");
        gameObject.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(2.5f);
        GameManager.isGameActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Powerup"))
        {

            if (health < 3)
            {
                health++;
                Destroy(other.gameObject);
                PowerUp.powerUpCount--;
            }
            else if(health == 3)
            {
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), true);
            }
        }
        if (other.CompareTag("Gold"))
        {
            score+=5;
            Destroy(other.gameObject);
        }
    }
}
