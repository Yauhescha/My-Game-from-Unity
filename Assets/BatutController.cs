using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatutController : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Rigidbody2D rigidbody=collision.GetComponent<Rigidbody2D>();
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }    
    }
}
