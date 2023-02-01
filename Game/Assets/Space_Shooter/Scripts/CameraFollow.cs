using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Oyunun kamera takibi i�in yap�lm�� kod s�n�f�
public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    private Vector3 offset;
    void Start()
    {
        // Kamera objesi ile oyuncu objesi aras�ndaki offset de�erini hesapla
        offset = transform.position - player.position;
    }
    void Update()
    {
        // Kamera objesinin oyuncu objesi ile belirlenen offset de�eri ile belirlenen pozisyonu
        Vector3 F�xedPos = player.position + offset;

        // Kamera objesinin belirlenen pozisyon ile mevcut pozisyonu aras�ndaki ge�i�in yap�lmas�
        Vector3 nextPos = Vector3.Lerp(transform.position, F�xedPos, speed * Time.deltaTime);
        transform.position = nextPos;
    }
}
