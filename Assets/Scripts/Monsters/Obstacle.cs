using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            unit.ReceiveDamage(5);
            Rigidbody2D rigidbody = collider.GetComponent<Rigidbody2D>();
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(transform.up * 5, ForceMode2D.Impulse);
        }
    }
}
