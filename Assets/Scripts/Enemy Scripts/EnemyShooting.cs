using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    
    public GameObject bulletSpawn;
    public float fireRate = 1.0f;
    public int randomness = 10;
    public List<string> ignoreTags;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Shoot
        if (Time.time % (fireRate + Random.Range(0, randomness)) < Time.deltaTime &&
            this.gameObject.GetComponent<EnemyController>().detectionRange > Vector3.Distance(this.gameObject.transform.position, GameObject.Find("Player").transform.position))
        {
            Shoot();
        }

    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        bullet.GetComponent<Bullet>().shooter = this.gameObject;
        bullet.GetComponent<Bullet>().ignoreTags = ignoreTags;
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawn.transform.up * 10;
    }
}
