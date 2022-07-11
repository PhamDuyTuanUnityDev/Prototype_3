using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics2D.gravity *= gravityModifier;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            Debug.Log("GameOver");
        }
    }
}