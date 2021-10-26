using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public SnakeMovement movement;
    public SpawnObject SO;
    

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Food") {
            movement.AddBodyPart();
            Destroy(col.gameObject);
            SO.SpawnFood();
        }
       else if(col.gameObject.tag == "Area_1" ) {

            movement.isAlive = true;
        }
         else { if(col.transform != movement.BodyParts[1]  && movement.isAlive) {
                if(Time.time - movement.TimeFromLastRetry > 5) {
                    movement.Die();
                }
            }
           
        }
    }
}
