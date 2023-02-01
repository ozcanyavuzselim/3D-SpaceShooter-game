using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//merminin h�z�n� belirleyen kod dosyas�
public class EnemyBulletMove : MonoBehaviour
{
    public float speed = 2f;

    private Rigidbody rigit;

    private void Awake()
    {
        rigit = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // mermi i�in h�z ayarlamas�
        rigit.velocity = transform.forward * speed * Time.deltaTime * -1000;
    }
}
