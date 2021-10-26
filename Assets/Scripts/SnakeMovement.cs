using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SnakeMovement : MonoBehaviour
{
    public List<Transform> BodyParts = new List<Transform>();
    public float minDistance = 0.25f;
    public int beginSize;
    public float speed = 1;
    public float rotationSpeed = 50;
    public float TimeFromLastRetry;
    public GameObject bodyPreFab;
    public GameObject DeadScreen;
    public Text currentScore;
    public Text scoreText;
    // public Text LiveText;
    private float dis;
    private Transform curBodyPart;
    private Transform prevBodyPart;
    public bool isAlive;
    public GameManager gameManager;
    
    
    


    // Start is called before the first frame update
    void Start() {
        StartLevel();
        
        
    }

    public void StartLevel() {
       
        TimeFromLastRetry = Time.time;
        
        DeadScreen.SetActive(false);

        for(int i = BodyParts.Count - 1; i > 1; i--) {
            Destroy(BodyParts[i].gameObject);
            BodyParts.Remove(BodyParts[i]);
        }
        
        BodyParts[0].position = new Vector3(0, 0.5f, 0);
        BodyParts[0].rotation = Quaternion.identity;
        
        currentScore.gameObject.SetActive(true);
        currentScore.text = "Score: 0";
        // LiveText.text = currentScore.text;
        isAlive = true;

        for (int i = 0; i < beginSize - 1; i++) {
            AddBodyPart();
        }
        

        BodyParts[0].position = new Vector3(2, 0.5f, 0);
        // LiveText.gameObject.SetActive(true);

       
    }

    // Update is called once per frame
    void Update() {
        
        if(isAlive) {
            Move();
            // LiveText.text ="Score: " + (BodyParts.Count - beginSize).ToString();
        }
        

        if (Input.GetKey(KeyCode.Q)) {
            AddBodyPart();
        }
    }

    public void Move() {
        float curSpeed = speed;
        
        if (Input.GetKey(KeyCode.W)) {
            curSpeed *= 3;
        }

        BodyParts[0].Translate(BodyParts[0].forward * curSpeed * Time.smoothDeltaTime, Space.World);

        if (Input.GetAxis("Horizontal") != 0) {
            BodyParts[0].Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        }

        for (int i = 1; i < BodyParts.Count; i++) {
            curBodyPart = BodyParts[i];
            prevBodyPart = BodyParts[i - 1];

            dis = Vector3.Distance(prevBodyPart.position, curBodyPart.position);
            Vector3 newPos = prevBodyPart.position;
            newPos.y = BodyParts[0].position.y;
            float T = Time.deltaTime * dis / minDistance * curSpeed;

            if (T > 0.5f) {
                T = 0.5f;
            }

            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newPos, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodyPart.rotation, T);
        }
        
    }

    public void AddBodyPart() {
        Transform newpart = (Instantiate(bodyPreFab, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation) as GameObject).transform;
        newpart.SetParent(transform);
        BodyParts.Add(newpart);
        currentScore.text = "Score: " + (BodyParts.Count - beginSize).ToString();
        
         // End Trigger
        if((BodyParts.Count - beginSize).ToString() == "3") {
                currentScore.gameObject.SetActive(false);
                 gameManager.CompleteLevel();
                // Debug.Log("Reached 5 ");
            }
    }

     

   

    public void Die() {
        isAlive = false;
        scoreText.text = "Your score was: " + (BodyParts.Count - beginSize).ToString();
        currentScore.gameObject.SetActive(false);
        // LiveText.gameObject.SetActive(false);
        DeadScreen.SetActive(true);
    }
    
}
