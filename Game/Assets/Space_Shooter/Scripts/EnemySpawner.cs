using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnEnemy; // d��man�n spawn edilece�i pozisyonlar� tutan dizi
    public GameObject enemy; // spawn edilecek d��man�n prefab'i
    public float drotain = 1f; // d��man�n spawn etme aral���
    public GameObject player; // oyuncular�n pozisyonunu takip etmek i�in kullan�lacak nesne
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 3, drotain);
    }

    void SpawnEnemy()// D��man� spawn etme fonksiyonu
    {
        if (player == null)// oyuncu yoksa fonksiyonu sonland�r
            return;

        int index = Random.Range(0, spawnEnemy.Length); // spawnEnemy dizisinden rastgele bir pozisyon se�
        Instantiate(enemy, spawnEnemy[index].position, spawnEnemy[index].rotation); // se�ilen pozisyonda d��man� spawn et

    }
}
