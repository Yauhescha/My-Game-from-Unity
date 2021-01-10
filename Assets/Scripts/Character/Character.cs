using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit
{
	public int maxHealth = 100;
	public int currentHealth;

	private HealthBar healthBar;

	private void Awake()
	{
		healthBar = FindObjectOfType<HealthBar>();
	}

	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}
    public override void ReceiveDamage(int damage)
    {
		currentHealth -= damage;
		if (currentHealth < 0)
			currentHealth = 0;

			healthBar.SetHealth(currentHealth);
	}
	private void OnCollisionEnter2D(Collision2D collider)
	{

		Bullet bullet = collider.gameObject.GetComponent<Bullet>();
		if (bullet && bullet.Parent != gameObject)
		{
			ReceiveDamage(15);
		}

	}
}
