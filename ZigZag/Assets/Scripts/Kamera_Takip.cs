using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera_Takip : MonoBehaviour
{
    public GameObject hedef; // playerimiz
    Vector3 uzaklik; //kmaeranýn belli bir uzaklýðý olsun
    void Start()
    {
        uzaklik = transform.position - hedef.transform.position; // Kamera ile oyuncu arasýndaki sabit uzaklýk
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate() //kamerayla alakalý iþler late update ile yazýlýr
    {
        //Eðer player düþtüyse kamera takip etmeyecek 
        if (Player.dustuMu == true)
        {
            return;
        }
        transform.position = hedef.transform.position + uzaklik; // Kameranýn yeni pozisyonu playerin pozisyonu + uzaklýk
    }
}
