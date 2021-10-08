using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isDead = false;
    public float speed = 3.0f;      // �{�[���̏����X�s�[�h
    public float accelSpeed = 0.5f; // �{�[�����o�[�ɓ����邽�тɒǉ�����鑬�x
    public ScoreManager scoreManager;
    public GameObject explosionPrefab;
    public AudioClip touchBarSE;
    public AudioClip touchOtherSE;
    bool isStart = false;
    Rigidbody rb;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart == false && Input.GetMouseButton(0))
        {
            isStart = true;
            rb.AddForce(new Vector3(1, -1, 0) * speed, ForceMode.VelocityChange);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))  //  �@�Ԃ��������̂��u���b�N�ł���� 
        {
            scoreManager.AddScore();                   //    ScoreManager�X�N���v�g��AddScore�֐������s����
            Destroy(collision.gameObject);             //    �u���b�N����
            GameObject explosion = Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);
            explosion.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            audioSource.PlayOneShot(touchBarSE);
        }

        if (collision.gameObject.name == "wall_bottom") 
        {
            isDead = true;
        }

        if (collision.gameObject.name == "Bar")
        {
            scoreManager.ResetCombo();                 //    score�����Z�b�g���� 
            speed += accelSpeed;
            Vector3 vec = transform.position - collision.transform.position;  // �{�[�����o�[�ɓ����鎞�ꏊ�ɂ���Ē��˕Ԃ�̊p�x��ω�������
            rb.velocity = Vector3.zero;
            rb.AddForce(vec.normalized * speed, ForceMode.VelocityChange);
        }
        else
        {
            audioSource.PlayOneShot(touchOtherSE);
        }
    }
}
