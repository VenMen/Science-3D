using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Скорость")]
    public float speed = 7f;

    [Header("Прыжок")]
    public float jump = 200f;

    [Header("Мы на земле?")]
    public bool ground;

    [SerializeField] private bool isAlreadyGrounded;

    public Rigidbody rb;

    void Start()
    {
        isAlreadyGrounded = false;
    }

    void FixedUpdate()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += -transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += -transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (ground == true)
            {
                rb.AddForce(transform.up * jump, ForceMode.Impulse);
                ground = false;
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ground)
        {
            isAlreadyGrounded = true;
        }

        if (collision.gameObject.tag == "Ground")
        {
            ground = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (!isAlreadyGrounded)
            {
                isAlreadyGrounded = false;
                ground = false;
            }

            isAlreadyGrounded = false;
        }
    }


}
