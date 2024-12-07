using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public InputActionReference shootAction;

    public GameObject bulletPrefab;
    
    public GameObject bulletSpawn;
    public List<string> ignoreTags;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnEnable()
    {
        shootAction.action.started += Shoot;
    }

        private void OnDisable()
    {
        shootAction.action.started -= Shoot;
    }
    void Shoot(InputAction.CallbackContext context)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        bullet.GetComponent<Bullet>().shooter = this.gameObject;
        bullet.GetComponent<Bullet>().ignoreTags = ignoreTags;
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawn.transform.up * 10;
    }
}
