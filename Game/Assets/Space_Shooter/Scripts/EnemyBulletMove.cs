using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//merminin hýzýný belirleyen kod dosyasý
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
        // mermi için hýz ayarlamasý
        rigit.velocity = transform.forward * speed * Time.deltaTime * -1000;
    }
}
