using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    //public Text gameOverText;
    public GameObject gameOverUI;
    public GameObject gameWonUI;
    public GameObject player;
    private bool gameStarted;
    public GameObject obstacles;
    public GameObject startingScreen;
    public static int score;

    private void Start() {
        
    }
    
    public void endGame(){
        if(gameHasEnded == false){
            gameHasEnded = true;
            gameOverUI.gameObject.SetActive(true);
            Debug.Log("Game Over");
            //Button to restart
            //Invoke("restart", restartDelay);            
        }    
        Destroy(obstacles);   
    }

    private void Update() {
        if(gameStarted == true){
            gameStarted = false;
            startGame();

        }

    }
    

    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void startGame(){
        startingScreen.gameObject.SetActive(false);
        obstacles.SetActive(true);
        player.GetComponent<Animator>().SetBool("isFlying", true);
    }
    public void setGameStarted(bool tOrF){
        gameStarted = tOrF;
    }

    public void quitGame(){
        Debug.Log("Quit Game");
        Application.Quit();
        
    }

    public void gameWon(){
        if(gameHasEnded == false){
            gameHasEnded = true;
            gameWonUI.gameObject.SetActive(true);
            Debug.Log("Game Won");
            Destroy(player);
            Destroy(obstacles);
        }
    }
}
