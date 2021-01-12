using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemController : MonoBehaviour
{
    [SerializeField]
    private int HealtToAddCount = 30;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();

        if (character)
        {
            character.AddHealth(HealtToAddCount);
            Destroy(gameObject);
        }
    }
}
