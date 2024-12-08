using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public int harm = 0;
    public AudioSource hurtSound;
    private GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        health -= harm;
        if (harm > 0)
        {
            hurtSound.Play();
            if (this.gameObject.tag == "Player")
            {
                gameController.GetComponent<GameController>().score.points -= 5;
            }
        }
        if (health <= 0)
        {
            if (this.gameObject.tag == "Player")
            {
                gameController.GetComponent<GameController>().IsPlayerDead = true;
            }
            if (this.gameObject.tag == "Enemy")
            {
                gameController.GetComponent<GameController>().totalEnemies--;
                gameController.GetComponent<GameController>().score.points += 10;
            }
            Destroy(this.gameObject);
        }
        harm = 0;
    }
}
