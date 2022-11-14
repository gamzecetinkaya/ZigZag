using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Vector3 yon; // Playeri y�n�n� belirler
    
    [SerializeField]
    float hiz;
    int hightScore;
    public Zemin_Olusturma zemin_olusturr;
    public static bool dustuMu = true; //topun d��mesini kontrol eder 
    
    public float hizlanma_zorlugu; // H�z�n her saniyede ne kadar artaca��n� belirleyecek katsay�lar
    float skor = 0f, artisMiktari = 1f;
    public GameObject restartGamePanel, PlayGamePanel;

    [SerializeField]
    Text skorText;

    [SerializeField]
    Text hightScoreText;

    void Start()
    {
        yon = Vector3.right; // bir bir gitmesini sa�l�yor.
        hightScore = PlayerPrefs.GetInt("hightScore");
        hightScoreText.text = "Best Score: " + hightScore.ToString();
       
        if (RestartGame.isRestart == true)
        {
            PlayGamePanel.SetActive(false);
            dustuMu = false;
        }
        
    }

    public void startGame()
    {
        PlayGamePanel.SetActive(false);
        dustuMu = false; 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dustuMu) // true idi
        {
            return;
        }
            
           // return; // e�er �art �al���yorsa alttaki komutlar �al��mayacak 
        
        if (Input.GetMouseButtonDown(0)) //mouse a veya ekrana dokunduk�a
        {
            if (yon.z == 0)  // y�n�m z ye e�itse
            {
                yon = Vector3.forward; // �ne do�ru git
            }
            else
            {
                yon = Vector3.right; // de�ilse sa�a git
            }
        }
        if (transform.position.y <= 0f)
        {
            dustuMu = true; 
            Destroy(gameObject, 0.85f);
            restartGamePanel.SetActive(true);
            if (hightScore < skor)
            {
                hightScore = (int)skor;
                PlayerPrefs.SetInt("hightScore", hightScore);
                PlayerPrefs.Save();

            }
        }
    }

    private void FixedUpdate()
    {
        if(dustuMu == true)
        {
            return;
        }
        Vector3 hareket = yon * hiz * Time.deltaTime;  // hareketimi h�z ile �arp�yor ve o h�zda ilerliyor
        transform.position += hareket;
        hiz += hizlanma_zorlugu * Time.deltaTime; // her saniyede �arp�p, ekleyecek 
        skor += artisMiktari * hiz * Time.deltaTime;
        skorText.text = "Skor: " + ((int)skor).ToString();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
            StartCoroutine(yokEt(collision.gameObject)); // IEnumarator �a��r�l�rken b�yle �a��r�l�yor.
            zemin_olusturr.zemin_Olustur();

        }
    }

    IEnumerator yokEt(GameObject obje)
    {
        yield return new WaitForSeconds(0.3f);
        obje.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(1f);
        Destroy(obje);
        
    }
}
