using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Düþmanýn hareketini ve atýþlarýný kontrol eden sýnýf

public class EnemyMoumend : MonoBehaviour
{
    private Rigidbody rigid;
    private AudioSource audio;

    public GameObject enemyBullet;
    public Transform bulletspawn;

    // Atýþ aralýðýný kontrol etmek için kullanýlan zamanlayýcý
    private float timer;
    public float nextFire = 1f;// Atýþ aralýðý
    public float speed = 2f;// Düþmanýn hýzý

    // Patlama animasyonu ve ölüm ses efekti
    public GameObject explosion;
    public AudioClip deathSound;

    private void Awake()
    {

        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Zamanlayýcýyý güncelle
        timer += Time.deltaTime;

        // Düþmaný hareket ettir
        rigid.velocity = transform.forward * speed * Time.deltaTime * -100;

        // Atýþ aralýðý geçmiþse, atýþ yap
        if (timer > nextFire)
        {
            Shoot();
        }
    }

    // Atýþ yap
    void Shoot()
    {
        Instantiate(enemyBullet, bulletspawn.position, bulletspawn.rotation);
        audio.Play();
        timer = 0f;
    }

    // Düþmanýn bir objeye çarpmasý durumu
    private void OnTriggerEnter(Collider other)
    {
        // Eðer çarpýlan objenin tag'i "Player" ise
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
