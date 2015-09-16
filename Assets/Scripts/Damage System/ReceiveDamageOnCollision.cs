using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class ReceiveDamageOnCollision : MonoBehaviour, IDeath
{
    [SerializeField]
	float health;
    HealthBar healthBar;
    float maxHealth;

    void Start()
    {
        maxHealth = health;
        if (healthBar != null) healthBar.SetMaxHealth(health);
    }

    public float Health
    {
        get
        {
            return health;
        }
    }

    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }

    public HealthBar HealthBar
    {
        set
        {
            healthBar = value;
        }
    }

	void OnCollisionEnter(Collision c)
	{
		if(c.collider.GetComponent<DealDamageOnCollision>() != null){
            RecieveDamage(c.collider.GetComponent<DealDamageOnCollision>().damage);
            //CheckDeath();
		}
	}

    public void RecieveDamage(float damage)
    {
        health -= damage;
        if (healthBar != null) healthBar.SetHealth(health);
        CheckDeath();
    }

    public void CheckDeath()
    {
        if ((health <= 0) && (GetComponentInParent<PlayerInfo>().State == PlayerInfo.PlayerState.ALIVE))
        {
            IDeath[] deathList = GetComponents<IDeath>();
            foreach (IDeath death in deathList)
            {
                death.OnDeath();
            }
        }
    }

	public void OnDeath()
	{
		// TODO
	}
}
