using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;
    public int damage = 10;
    public float damageRate = 2.0f;
    public float detectionRange = 5.0f;
    public bool rotateTowardsPlayer = true;

    void Start()
    {
        GameObject gameController = GameObject.Find("GameController");
        gameController.GetComponent<GameController>().totalEnemies++;
        Debug.Log("Total enemies: " + gameController.GetComponent<GameController>().totalEnemies);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private Rigidbody2D rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        GameObject player = null;
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player");
        }
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            if (direction.magnitude < detectionRange)
            {
                // Rotate towards player
                if (rotateTowardsPlayer)
                {
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
                }
                // Move towards player
                rigidBody.velocity = direction.normalized * speed;
            }
            else
            {
                rigidBody.velocity = Vector2.zero;
            }
        }else
        {
            RandomWalk();
            // Wait for 2 seconds
            StartCoroutine(Wait());
        }
    }

    private bool insideObject = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            insideObject = true;
            StartCoroutine(Harm(other.gameObject));
            Debug.Log("Player entered");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            insideObject = false;
            StartCoroutine(Harm(other.gameObject));
        }
    }

    IEnumerator Harm(GameObject other)
    {
        while (insideObject)
        {
            other.GetComponent<HealthSystem>().harm += damage;
            yield return new WaitForSeconds(damageRate);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }

    void RandomWalk()
    {
        Vector2 randomDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        rigidBody.velocity = randomDirection.normalized * speed;
    }
}
