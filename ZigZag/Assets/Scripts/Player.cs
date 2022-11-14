using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Vector3 yon; // Playeri yönünü belirler
    
    [SerializeField]
    float hiz;
    int hightScore;
    public Zemin_Olusturma zemin_olusturr;
    public static bool dustuMu = true; //topun düþmesini kontrol eder 
    
    public float hizlanma_zorlugu; // Hýzýn her saniyede ne kadar artacaðýný belirleyecek katsayýlar
    float skor = 0f, artisMiktari = 1f;
    public GameObject restartGamePanel, PlayGamePanel;

    [SerializeField]
    Text skorText;

    [SerializeField]
    Text hightScoreText;

    void Start()
    {
        yon = Vector3.right; // bir bir gitmesini saðlýyor.
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
            
           // return; // eðer þart çalýþýyorsa alttaki komutlar çalýþmayacak 
        
        if (Input.GetMouseButtonDown(0)) //mouse a veya ekrana dokundukça
        {
            if (yon.z == 0)  // yönüm z ye eþitse
            {
                yon = Vector3.forward; // öne doðru git
            }
            else
            {
                yon = Vector3.right; // deðilse saða git
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
        Vector3 hareket = yon * hiz * Time.deltaTime;  // hareketimi hýz ile çarpýyor ve o hýzda ilerliyor
        transform.position += hareket;
        hiz += hizlanma_zorlugu * Time.deltaTime; // her saniyede çarpýp, ekleyecek 
        skor += artisMiktari * hiz * Time.deltaTime;
        skorText.text = "Skor: " + ((int)skor).ToString();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
            StartCoroutine(yokEt(collision.gameObject)); // IEnumarator çaðýrýlýrken böyle çaðýrýlýyor.
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
