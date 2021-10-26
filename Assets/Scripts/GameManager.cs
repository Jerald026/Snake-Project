using UnityEngine.SceneManagement;
using UnityEngine;
using System.Reflection;

public class GameManager : MonoBehaviour
{
    // bool gameHasEnded = false;
    // bool gameHasStarted = false;
    public GameObject completeLevelUI;

//    public void EndGame(){
//        if(gameHasEnded == false){

//         gameHasEnded = true;
//        Debug.Log("Game Over!");
//        Invoke("Restart" , 1.5f);
//         //  Restart();
//        }
//    }

//    public void StartGame(){
//        if(gameHasStarted == false){

//         gameHasStarted = true;
        
//        Debug.Log("Go!!!");
//        }
      
//    }
   public void CompleteLevel(){ 
        Debug.Log("Level Finished!");
        completeLevelUI.SetActive(true);
        
        
   }


//    void Restart(){
//     //    SceneManager.LoadScene("level01");
//      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//        ClearLog();
//    }

   public void ClearLog() 
{
    var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
    var type = assembly.GetType("UnityEditor.LogEntries");
    var method = type.GetMethod("Clear");
    method.Invoke(new object(), null);
}
}
