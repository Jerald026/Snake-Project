// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextlevel : MonoBehaviour
{
  

  public void LoadtoNextlevel(){
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      
      // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      // SceneManager.LoadScene("Menu");
  }
}
