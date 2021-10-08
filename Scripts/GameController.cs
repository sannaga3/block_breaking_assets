using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverText;                     //    ゲームオーバーの情報
    public GameObject ball;                             //    ballの情報
    public GameObject gameClearText;
    public GameObject retryButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        if (blocks.Length == 0)
        {
            gameClearText.SetActive(true);   //  ブロックが0個になるとgameClearTextが表示される
            ball.GetComponent<Rigidbody>().isKinematic = true;
            retryButton.SetActive(true);
        }

        if (ball.GetComponent<Ball>().isDead == true)
        {
            gameOverText.SetActive(true);        //   ballのisDeadがtrueだった時ゲームオーバーを表示する
            ball.GetComponent<Rigidbody>().isKinematic = true;
            retryButton.SetActive(true);
        }
     }
     public void Retry()
     {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }
}