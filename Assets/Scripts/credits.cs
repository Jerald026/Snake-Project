// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
   public void Quit(){
       Debug.Log("Quit");
       Application.Quit();
   }

   public void Restart(){ 
       Debug.Log("Restart");
        SceneManager.LoadScene("Menu");
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}
