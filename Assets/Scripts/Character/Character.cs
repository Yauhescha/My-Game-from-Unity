using UnityEngine;

public class Character : Unit
{
	private GameUIController uiController;

	[SerializeField]
	private int maxHealth = 100;
	[SerializeField]
	private int currentHealth;
	[SerializeField]
	private int bulletCount = 0;


    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int CurrentHealth { get => currentHealth; }
	public void AddHealth(int countToAdd) {
		currentHealth += countToAdd;
		if (currentHealth > maxHealth) currentHealth = maxHealth;

		uiController.keyboardControl_HealthBar.SetHealth(CurrentHealth);
	}

	public int BulletCount { get => bulletCount; set => bulletCount = value; }
	public void MadeFire() { 
		bulletCount--; 
		if (bulletCount < 0) 
			bulletCount = 0;
		uiController.KeyboardControl_SetBulletsCount(BulletCount);
	}
	public void FoundBuller(int count) { 
		bulletCount += count;
		uiController.KeyboardControl_SetBulletsCount(BulletCount);
	}
    private void Awake()
	{
		uiController = FindObjectOfType<GameUIController>();
	}

	void Start()
	{
		currentHealth = MaxHealth;
		uiController.keyboardControl_HealthBar.SetMaxHealth(MaxHealth);
		uiController.KeyboardControl_SetBulletsCount(BulletCount);
	}
    public override void ReceiveDamage(int damage)
    {
		currentHealth -= damage;
		if (currentHealth < 0)
			currentHealth = 0;

		uiController.keyboardControl_HealthBar.SetHealth(CurrentHealth);
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
