using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 0.4f;
    public bool isEnd = false;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, 0);
        if(transform.position.x < -1){
            Destroy(gameObject);
        }
        if(isEnd == true && transform.position.x < -0.7){
            Debug.Log("Game Won");
            gameManager.gameWon();
        }

    }
}
