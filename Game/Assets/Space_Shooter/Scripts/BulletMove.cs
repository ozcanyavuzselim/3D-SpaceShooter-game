using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BulletMove s�n�f�, mermilerin hareketini y�netmek i�in yap�lm�� bir s�n�ft�r.
public class BulletMove : MonoBehaviour
{
    //Mermilerin h�z�n� belirler.
    public float speed = 2f;

    private Rigidbody rigit;

    private void Awake()
    {
        rigit = GetComponent<Rigidbody>();
    }
   
    void Update()
    {
        //Rigidbody componentine mermilerin y�n�ne g�re h�z� verir.
        rigit.velocity = transform.forward * speed * Time.deltaTime * 1000;
    }
}
