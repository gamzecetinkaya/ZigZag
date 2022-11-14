using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public static bool isRestart = false;
   
   public void restartGame()
    {
        isRestart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void quitGame()
    {
                       #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
                        #endif
         Application.Quit();//Oyundan çýkmak

    }
}
