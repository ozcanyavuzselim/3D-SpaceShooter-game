using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement2 : MonoBehaviour
{

    [Header("düþmanýýn özrllikleri")]
    private Rigidbody rigid;
    private Vector3 nextPos;

    public GameObject enemyBullet;
    public Transform bulletspawn;

    private float timer;
    public float nextFire = 1f;
    public float speed = 2f;
    public Transform startpos, pos1, pos2;

    private AudioSource audio;

    public GameObject explosion;
    public AudioClip deadsound;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();

    }

    private void Start()
    {
        nextPos = startpos.position;
    }
    void Update()
    {
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }


        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer > nextFire)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(enemyBullet, bulletspawn.position, bulletspawn.rotation);
        audio.Play();
        timer = 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            ScoreManager.score += 15;
            AudioSource.PlayClipAtPoint(deadsound, transform.position);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}