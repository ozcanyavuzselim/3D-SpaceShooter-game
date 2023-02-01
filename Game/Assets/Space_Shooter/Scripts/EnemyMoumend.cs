using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// D��man�n hareketini ve at��lar�n� kontrol eden s�n�f

public class EnemyMoumend : MonoBehaviour
{
    private Rigidbody rigid;
    private AudioSource audio;

    public GameObject enemyBullet;
    public Transform bulletspawn;

    // At�� aral���n� kontrol etmek i�in kullan�lan zamanlay�c�
    private float timer;
    public float nextFire = 1f;// At�� aral���
    public float speed = 2f;// D��man�n h�z�

    // Patlama animasyonu ve �l�m ses efekti
    public GameObject explosion;
    public AudioClip deathSound;

    private void Awake()
    {

        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Zamanlay�c�y� g�ncelle
        timer += Time.deltaTime;

        // D��man� hareket ettir
        rigid.velocity = transform.forward * speed * Time.deltaTime * -100;

        // At�� aral��� ge�mi�se, at�� yap
        if (timer > nextFire)
        {
            Shoot();
        }
    }

    // At�� yap
    void Shoot()
    {
        Instantiate(enemyBullet, bulletspawn.position, bulletspawn.rotation);
        audio.Play();
        timer = 0f;
    }

    // D��man�n bir objeye �arpmas� durumu
    private void OnTriggerEnter(Collider other)
    {
        // E�er �arp�lan objenin tag'i "Player" ise
        if (other.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            ScoreManager.score += 10;
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }    
    }
}
