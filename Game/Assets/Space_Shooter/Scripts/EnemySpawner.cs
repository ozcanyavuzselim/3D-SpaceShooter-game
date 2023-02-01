using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnEnemy; // düþmanýn spawn edileceði pozisyonlarý tutan dizi
    public GameObject enemy; // spawn edilecek düþmanýn prefab'i
    public float drotain = 1f; // düþmanýn spawn etme aralýðý
    public GameObject player; // oyuncularýn pozisyonunu takip etmek için kullanýlacak nesne
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 3, drotain);
    }

    void SpawnEnemy()// Düþmaný spawn etme fonksiyonu
    {
        if (player == null)// oyuncu yoksa fonksiyonu sonlandýr
            return;

        int index = Random.Range(0, spawnEnemy.Length); // spawnEnemy dizisinden rastgele bir pozisyon seç
        Instantiate(enemy, spawnEnemy[index].position, spawnEnemy[index].rotation); // seçilen pozisyonda düþmaný spawn et

    }
}
