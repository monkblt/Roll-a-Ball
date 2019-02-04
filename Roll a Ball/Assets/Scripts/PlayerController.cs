using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;

    private Rigidbody rb;
    private int count;
    private int score;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetScoreText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            //count = count + 1;
            score = score + 1;
            SetScoreText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            //count = count + 1;
            score = score - 1; // this removes 1 from the score
            SetScoreText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            //score = score - 1; // this removes 1 from the score
            SetCountText();
        }
    }
    
   

     void SetCountText ()
     {
         countText.text = "Count: " + count.ToString();
         if (count >= 12)
         {
             winText.text = "You Win!";
         }
     }
     
    void SetScoreText ()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 12)
        {
            winText.text = "You Win!";
        }
    }
}
