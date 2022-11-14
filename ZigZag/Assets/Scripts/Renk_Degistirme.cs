using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renk_Degistirme : MonoBehaviour
{
   public List <Color> renkler;
    Color ilkRenk, ikinciRenk; 
    int birinci_Renk;

    public Material zemin_materyal;
    void Start()
    {
        birinci_Renk = Random.Range(0, renkler.Count);
        ikinciRenk = renkler[ikinciRenkSec()];
        Camera.main.backgroundColor = renkler[birinci_Renk];
        zemin_materyal.color = renkler[birinci_Renk];
        
    }

    // Update is called once per frame
    void Update()
    {
        Color fark = zemin_materyal.color - ikinciRenk;
        if (Mathf.Abs(fark.r) + Mathf.Abs(fark.g) + Mathf.Abs(fark.b) < 0.2f)
        {
            ikinciRenk = renkler[ikinciRenkSec()];
        }
        zemin_materyal.color = Color.Lerp(zemin_materyal.color, ikinciRenk, 0.003f);
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor,ikinciRenk, 0.0007f);
    }

    int ikinciRenkSec()
    {
        int ikincilRenk;
        ikincilRenk = Random.Range(0, renkler.Count);
        while(ikincilRenk == birinci_Renk)
        {
            ikincilRenk = Random.Range(0, renkler.Count);
        }
        return ikincilRenk;
    }
}
