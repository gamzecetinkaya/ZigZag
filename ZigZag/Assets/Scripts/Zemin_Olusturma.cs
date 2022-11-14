using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zemin_Olusturma : MonoBehaviour
{
    public GameObject son_zemin;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 20; i++)
        {
            zemin_Olustur();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void zemin_Olustur()
    {
        Vector3 yon;
        int randomSayi = Random.Range(0, 2); // 0 ya da 1 gelecek
        if (randomSayi == 0)
        {
            yon = Vector3.right;
        }
        else
        {
            yon = Vector3.forward;
        }
        // Son zemini deðiþtirip her seferinde bir o kadar ekler böylelikle random zeminlerimiz oluþur.
        son_zemin = Instantiate(son_zemin, son_zemin.transform.position + yon, son_zemin.transform.rotation);
    }
}
