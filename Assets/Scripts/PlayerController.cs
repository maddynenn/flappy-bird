using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float thrust = 1f;
    GameManager gameManager;
    private int jumpCount = 0;
    public Animator anim;
    public GameObject poop;

    
    //bool movementStarted;
    // Start is called before the first frame update
    void Start()
    {
        //movementStarted = false;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space)){
            jumpCount++;
            rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
            //movementStarted = true;
            Instantiate(poop, transform.position, Quaternion.identity);
            if(jumpCount == 1){
                gameManager.setGameStarted(true);
            }
           
        }
        if(transform.position.y <= 0.133){ 
            Debug.Log("On ground");
            anim.SetBool("isFlying", false);
        }
        else{
            anim.SetBool("isFlying", true);
        }
        
    }
    private void FixedUpdate() {
        /*if(movementStarted){
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, 0);
        }*/
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Building"){
            die();
        }
    }
    private void die(){
        Destroy(gameObject);
        gameManager.endGame();
        
    }
}
