using UnityEngine;

public class Character : Unit
{
	[SerializeField]
	private int maxHealth = 100;
	[SerializeField]
	private int currentHealth;
	[SerializeField]
	private int bulletCount = 0;



	private HealthBar healthBar;

    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int CurrentHealth { get => currentHealth; }
	public void AddHealth(int countToAdd) {
		currentHealth += countToAdd;
		if (currentHealth > maxHealth) currentHealth = maxHealth;

		healthBar.SetHealth(CurrentHealth);
	}

	public int BulletCount { get => bulletCount; set => bulletCount = value; }
	public void MadeFire() { bulletCount--; if (bulletCount < 0) bulletCount = 0; }
	public void FoundBuller(int count) { bulletCount += count; }
    private void Awake()
	{
		healthBar = FindObjectOfType<HealthBar>();
		
	}

	void Start()
	{
		currentHealth = MaxHealth;
		healthBar.SetMaxHealth(MaxHealth);
		
	}
    public override void ReceiveDamage(int damage)
    {
		currentHealth -= damage;
		if (currentHealth < 0)
			currentHealth = 0;

			healthBar.SetHealth(CurrentHealth);
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
