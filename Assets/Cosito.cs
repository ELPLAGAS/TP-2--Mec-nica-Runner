using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cosito : MonoBehaviour
{
    public float jumpForce;

    private Rigidbody rigidbody;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.ShowGameOverScreen();
            Time.timeScale = 0f;
        }


        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}


