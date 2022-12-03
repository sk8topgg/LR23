using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 jumpDiretion;
    public int jumpForce;
    Rigidbody2D rgbd;
    Vector2 currentSpeed;
    public Vector2 maxSpeed;
    public bool takePlayerInput;
    Animator animator;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        rgbd.gravityScale = 0;
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {   if (takePlayerInput) return;
        if (Input.GetMouseButtonDown(0))
        {
            if (rgbd.gravityScale != 1) { rgbd.gravityScale = 1; }
            rgbd.AddForce(jumpDiretion * jumpForce * Time.deltaTime);
            ControlSpeed();
        }

        void ControlSpeed()
        {
            currentSpeed = rgbd.velocity;
            if (currentSpeed.x != maxSpeed.x) { currentSpeed.x = maxSpeed.x; }
            if (currentSpeed.y != maxSpeed.y) { currentSpeed.y = maxSpeed.y; }
            rgbd.velocity = currentSpeed;
        }
    }

    public void PlayerDead()
    {
        Invoke("RestartScene", 1);
        animator.SetTrigger("Dead");
    }

    public void RestartScene()
    {
        gameManager.RestartScene();
    }
}
