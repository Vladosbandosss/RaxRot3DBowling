using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    private bool thrown = false;
    public float horizontalSpeed;

    private float maxX = 0.7f;
    private float minX = -0.7f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        BallMovement();
        ChekPos();
    }

    private void ChekPos()
    {
        Vector3 temp = transform.position;

        temp.x = Mathf.Clamp(transform.position.x, minX, maxX);

        transform.position = temp;

    }

    private void FixedUpdate()
    {
        if (thrown && transform.position.y<0f)//rb.IsSleeping()
        {
            SceneManager.LoadScene("GamePlay");
        }
       
    }

    void BallMovement()
    {
        if (!thrown)
        {
            float xAxis = Input.GetAxis("Horizontal");

            Vector3 position = transform.position;
            position.x += xAxis * horizontalSpeed;
            transform.position = position;
        }

        if(!thrown && Input.GetKeyDown(KeyCode.Space))
        {
            thrown = true;
            rb.isKinematic = false;
            rb.velocity = new Vector3(0f, 0f, speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pin")
        {
            Debug.Log("педорахзнули");
        }
    }


}
