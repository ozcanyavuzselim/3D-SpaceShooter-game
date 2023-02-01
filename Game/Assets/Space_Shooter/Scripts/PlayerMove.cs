using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Bu s�n�f, oyuncunun hareketlerini ve silah at���n� y�netir
public class PlayerMove : MonoBehaviour
{
    
    public GameObject explosen;//Patlama animasyonunu tutan referans
    public AudioClip deathSound;//�l�m sesini tutan referans 
    private CameraFollow cam;//Kamera s�n�f�n� tutan referans

    public float speed = 3f;//Oyuncunun hareket h�z�
    public float minX, maxX, minZ, maxZ;//Oyuncunun hareket edebilece�i en y�ksek ve en d���k X ve Z pozisyonlar�
    public float rot;//Oyuncunun rotasyon h�z�

    public GameObject bullet;//Mermi nesnesini tutan referans
    public Transform bulletspawn;//Mermi at�laca�� pozisyonu tutan referans
    public float nextFire = 1f;//Bir sonraki ate�lemenin ne kadar s�rede ger�ekle�ece�

    private float timer;//Ate�leme aral���n� tutan zamanlay�c�

    private Vector3 movement;//Hareket vekt�r�
    private Rigidbody rigid;//Rigidbody componenti

    private AudioSource audio;//AudioSource componenti

    public GameObject GameOverIng, gameovertext, restart, mainmenu;//Oyunun biti� ekran�ndaki GameObject'leri tutan referanslar

    void Start()
    {
        //Rigidbody componentini �a��r
        rigid = GetComponent<Rigidbody>();
        //AudioSource componentini �a��r
        audio = GetComponent<AudioSource>();
        //"MainCamera" etiketli kamera nesnesinin CameraFollow s�n�f�n� �a��r
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }
    private void FixedUpdate()
    {
        //Horizontal y�n i�in axis de�erini al
        float h = Input.GetAxisRaw("Horizontal");
        //Vertical y�n i�in axis de�erini al
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);//Hareket fonksiyonunu �a��r

        timer += Time.deltaTime; //Zamanlay�c�

        // E�er Fire1 butonu veya Space tu�u bas�ld� ve timer nextFire'dan b�y�kse, at�� yap�l�r
        if ((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && timer > nextFire)
        {
            shoot();// At��� yap
        }
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0, v);

        // Hareketi h�z�na g�re zamanla �arpmak
        movement = movement * speed * Time.deltaTime;

        // Hareketi yapmak i�in rigidbody'nin pozisyonunu g�ncelle
        rigid.MovePosition(transform.position + movement);

        // X ve Z pozisyonunu minX, maxX, minZ, maxZ de�erleri aras�nda s�n�rlamak
        rigid.position = new Vector3(Mathf.Clamp(rigid.position.x, minX, maxX), 2, Mathf.Clamp(rigid.position.z, minZ, maxZ));

        // Rotasyonu X pozisyonuna g�re ayarlamak
        rigid.rotation = Quaternion.Euler(0, 0, -transform.position.x * rot);
    }

    void shoot()
    {
        // Mermi olu�turmak
        Instantiate(bullet, bulletspawn.position, bulletspawn.rotation);
        audio.Play();
        timer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            // Patlama animasyonunu olu�turmak
            Instantiate(explosen, transform.position, transform.rotation);
            // Game Over objelerini aktifle�tirmek
            GameOverIng.SetActive(true);
            gameovertext.SetActive(true);
            restart.SetActive(true);
            mainmenu.SetActive(true);
            // �l�m sesini �al��t�rmak
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            // Kamera takibini devre d��� b�rakmak
            cam.enabled = false;
            // D��man ve oyuncu objelerini yok etmek
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
