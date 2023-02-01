using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BulletMove sýnýfý, mermilerin hareketini yönetmek için yapýlmýþ bir sýnýftýr.
public class BulletMove : MonoBehaviour
{
    //Mermilerin hýzýný belirler.
    public float speed = 2f;

    private Rigidbody rigit;

    private void Awake()
    {
        rigit = GetComponent<Rigidbody>();
    }
   
    void Update()
    {
        //Rigidbody componentine mermilerin yönüne göre hýzý verir.
        rigit.velocity = transform.forward * speed * Time.deltaTime * 1000;
    }
}
