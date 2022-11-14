using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera_Takip : MonoBehaviour
{
    public GameObject hedef; // playerimiz
    Vector3 uzaklik; //kmaeran�n belli bir uzakl��� olsun
    void Start()
    {
        uzaklik = transform.position - hedef.transform.position; // Kamera ile oyuncu aras�ndaki sabit uzakl�k
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate() //kamerayla alakal� i�ler late update ile yaz�l�r
    {
        //E�er player d��t�yse kamera takip etmeyecek 
        if (Player.dustuMu == true)
        {
            return;
        }
        transform.position = hedef.transform.position + uzaklik; // Kameran�n yeni pozisyonu playerin pozisyonu + uzakl�k
    }
}
