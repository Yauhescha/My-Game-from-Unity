using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public virtual void ReceiveDamage()
    {
        Die();
    }

    public virtual void ReceiveDamage(int damage)
    {
        ReceiveDamage();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
