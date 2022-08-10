using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] Camera gameCamera;
    [SerializeField] float Speed=5f;
    float padding = 0.5f;
    float minX;
    float maxX;
    float minY;
    float maxY;
    [Header("Player Config")]
    [SerializeField] GameObject ammo;
    [SerializeField] float laserSpeed=10f;
    [SerializeField] float hitRate= 0.1f;
    [SerializeField] int health = 100;
    Coroutine firing;
    [SerializeField] GameObject exlosiveEffect;
    [SerializeField] AudioClip deadSound;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float deadVolume = 0.75f;
    [SerializeField] [Range(0, 1)] float shootVolume = 0.5f;

    void Start()
    {
        SetUpMoveBoundaries();
        SetStats();
    }
    private void SetStats()
    {
        var level = PlayerPrefsController.GetStatLevel("HP");
        health = DefsFacade.I.StatsDef.Get("HP").LevelDatas[level].Value;
    }

    void Update()
    {
        Move();
        Fire();
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
        FindObjectOfType<Level>().LoadGameOverScene();
        Destroy(gameObject);
        var Veffect = Instantiate(exlosiveEffect, transform.position, transform.rotation);
        Destroy(Veffect, 1f);
        AudioSource.PlayClipAtPoint(deadSound, FindObjectOfType<Camera>().transform.position, deadVolume);
    }

    IEnumerator  FireCoroutine()
    {
        while (true)
        {
            GameObject laser = Instantiate(ammo, transform.position, Quaternion.identity) as GameObject;
            AudioSource.PlayClipAtPoint(shootSound, FindObjectOfType<Camera>().transform.position, shootVolume);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            yield return new WaitForSeconds(hitRate);
        }
    }

    private void Fire()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            firing=StartCoroutine(FireCoroutine());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firing);
        }

    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        var newPosX = Mathf.Clamp(transform.position.x + deltaX,minX,maxX);
        var newPosY = Mathf.Clamp(transform.position.y + deltaY,minY,maxY);
        transform.position = new Vector2(newPosX,newPosY);
    }
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = FindObjectOfType<Camera>();
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x+padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-padding;
        minY= gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y+padding;
        maxY= gameCamera.ViewportToWorldPoint(new Vector3(0, 0.5f,0)).y;
    }
    public int GetHP()
    {
        return health;
    }
}
