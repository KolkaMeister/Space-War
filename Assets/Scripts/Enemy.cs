using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] int health=1000;
     float timeBetweenShot;
    [SerializeField] float minT=0.4f;
    [SerializeField] float maxT=2.5f;
    [SerializeField] int price=100;
    [Header("Ammo")]
    [SerializeField] GameObject ammo;
    [SerializeField] float laserSpeed = 7f;
    [Header("Effects")]
    [SerializeField] GameObject exlosiveEffect;
    [SerializeField] AudioClip deadSound;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float deadVolume=0.75f;
    [SerializeField] [Range(0, 1)] float shootVolume=0.5f;

    void Start()
    {
        timeBetweenShot = Random.Range(minT, maxT);
    }
    void Update()
    {
        CountDownAndShoot();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }
    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        PlayerPrefsController.AddPoints(price);
        Destroy(gameObject);
        var Veffect=Instantiate(exlosiveEffect, transform.position, transform.rotation);
        Destroy(Veffect, 1f);
        AudioSource.PlayClipAtPoint(deadSound, FindObjectOfType<Camera>().transform.position, deadVolume);
    }
    void CountDownAndShoot()
    {
        timeBetweenShot -= Time.deltaTime;
        if (timeBetweenShot<=0)
        {
            Fire();
            timeBetweenShot = Random.Range(minT, maxT);
        }
    }
    void Fire()
    {
        var laser=Instantiate(ammo, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
        AudioSource.PlayClipAtPoint(shootSound, FindObjectOfType<Camera>().transform.position, shootVolume);
    }
}
