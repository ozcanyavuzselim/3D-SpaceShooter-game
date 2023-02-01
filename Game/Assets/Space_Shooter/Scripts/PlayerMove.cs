using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Bu sýnýf, oyuncunun hareketlerini ve silah atýþýný yönetir
public class PlayerMove : MonoBehaviour
{
    
    public GameObject explosen;//Patlama animasyonunu tutan referans
    public AudioClip deathSound;//Ölüm sesini tutan referans 
    private CameraFollow cam;//Kamera sýnýfýný tutan referans

    public float speed = 3f;//Oyuncunun hareket hýzý
    public float minX, maxX, minZ, maxZ;//Oyuncunun hareket edebileceði en yüksek ve en düþük X ve Z pozisyonlarý
    public float rot;//Oyuncunun rotasyon hýzý

    public GameObject bullet;//Mermi nesnesini tutan referans
    public Transform bulletspawn;//Mermi atýlacaðý pozisyonu tutan referans
    public float nextFire = 1f;//Bir sonraki ateþlemenin ne kadar sürede gerçekleþeceð

    private float timer;//Ateþleme aralýðýný tutan zamanlayýcý

    private Vector3 movement;//Hareket vektörü
    private Rigidbody rigid;//Rigidbody componenti

    private AudioSource audio;//AudioSource componenti

    public GameObject GameOverIng, gameovertext, restart, mainmenu;//Oyunun bitiþ ekranýndaki GameObject'leri tutan referanslar

    void Start()
    {
        //Rigidbody componentini çaðýr
        rigid = GetComponent<Rigidbody>();
        //AudioSource componentini çaðýr
        audio = GetComponent<AudioSource>();
        //"MainCamera" etiketli kamera nesnesinin CameraFollow sýnýfýný çaðýr
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }
    private void FixedUpdate()
    {
        //Horizontal yön için axis deðerini al
        float h = Input.GetAxisRaw("Horizontal");
        //Vertical yön için axis deðerini al
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);//Hareket fonksiyonunu çaðýr

        timer += Time.deltaTime; //Zamanlayýcý

        // Eðer Fire1 butonu veya Space tuþu basýldý ve timer nextFire'dan büyükse, atýþ yapýlýr
        if ((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && timer > nextFire)
        {
            shoot();// Atýþý yap
        }
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0, v);

        // Hareketi hýzýna göre zamanla çarpmak
        movement = movement * speed * Time.deltaTime;

        // Hareketi yapmak için rigidbody'nin pozisyonunu güncelle
        rigid.MovePosition(transform.position + movement);

        // X ve Z pozisyonunu minX, maxX, minZ, maxZ deðerleri arasýnda sýnýrlamak
        rigid.position = new Vector3(Mathf.Clamp(rigid.position.x, minX, maxX), 2, Mathf.Clamp(rigid.position.z, minZ, maxZ));

        // Rotasyonu X pozisyonuna göre ayarlamak
        rigid.rotation = Quaternion.Euler(0, 0, -transform.position.x * rot);
    }

    void shoot()
    {
        // Mermi oluþturmak
        Instantiate(bullet, bulletspawn.position, bulletspawn.rotation);
        audio.Play();
        timer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            // Patlama animasyonunu oluþturmak
            Instantiate(explosen, transform.position, transform.rotation);
            // Game Over objelerini aktifleþtirmek
            GameOverIng.SetActive(true);
            gameovertext.SetActive(true);
            restart.SetActive(true);
            mainmenu.SetActive(true);
            // Ölüm sesini çalýþtýrmak
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            // Kamera takibini devre dýþý býrakmak
            cam.enabled = false;
            // Düþman ve oyuncu objelerini yok etmek
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
