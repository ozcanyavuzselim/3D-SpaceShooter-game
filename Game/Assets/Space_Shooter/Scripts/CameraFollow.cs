using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Oyunun kamera takibi için yapýlmýþ kod sýnýfý
public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    private Vector3 offset;
    void Start()
    {
        // Kamera objesi ile oyuncu objesi arasýndaki offset deðerini hesapla
        offset = transform.position - player.position;
    }
    void Update()
    {
        // Kamera objesinin oyuncu objesi ile belirlenen offset deðeri ile belirlenen pozisyonu
        Vector3 FÝxedPos = player.position + offset;

        // Kamera objesinin belirlenen pozisyon ile mevcut pozisyonu arasýndaki geçiþin yapýlmasý
        Vector3 nextPos = Vector3.Lerp(transform.position, FÝxedPos, speed * Time.deltaTime);
        transform.position = nextPos;
    }
}
