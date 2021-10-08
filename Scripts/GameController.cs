using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverText;                     //    �Q�[���I�[�o�[�̏��
    public GameObject ball;                             //    ball�̏��
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
            gameClearText.SetActive(true);   //  �u���b�N��0�ɂȂ��gameClearText���\�������
            ball.GetComponent<Rigidbody>().isKinematic = true;
            retryButton.SetActive(true);
        }

        if (ball.GetComponent<Ball>().isDead == true)
        {
            gameOverText.SetActive(true);        //   ball��isDead��true���������Q�[���I�[�o�[��\������
            ball.GetComponent<Rigidbody>().isKinematic = true;
            retryButton.SetActive(true);
        }
     }
     public void Retry()
     {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }
}