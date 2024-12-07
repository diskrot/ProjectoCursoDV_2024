using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDash : MonoBehaviour
{
    public float dashSpeedMultiplier = 10.0f;
    public int damageMultiplier = 5;
    public float dashTime = 0.5f;
    public float dashCooldown = 2.0f;
    public float dashRange = 5.0f;
    float initialSpeed;
    int initialDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = this.gameObject.GetComponent<EnemyController>().speed;
        initialDamage = this.gameObject.GetComponent<EnemyController>().damage;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        GameObject player = null;
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player");
        }
        if (player != null && Vector3.Distance(player.transform.position, this.transform.position) < dashRange)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        this.gameObject.GetComponent<EnemyController>().speed = initialSpeed * dashSpeedMultiplier;
        this.gameObject.GetComponent<EnemyController>().damage = initialDamage * damageMultiplier;
        yield return new WaitForSeconds(dashTime);
        this.gameObject.GetComponent<EnemyController>().speed = initialSpeed;
        this.gameObject.GetComponent<EnemyController>().damage = initialDamage;
        yield return new WaitForSeconds(dashCooldown);
    }
}
