using UnityEngine;
using System.Collections;

public class ReceiveDamageOnCollision : MonoBehaviour, IDeath
{
    [SerializeField]
	float health;
    [SerializeField]
    HealthBar healthBar;

    void Start()
    {
        if (healthBar != null) healthBar.SetMaxHealth(health);
    }

    public float Health
    {
        get
        {
            return health;
        }
    }

	void OnCollisionEnter(Collision c)
	{
		if(c.collider.GetComponent<DealDamageOnCollision>() != null){
			health -= c.collider.GetComponent<DealDamageOnCollision>().damage;
            if (healthBar != null) healthBar.SetHealth(health);
			if (health <= 0){
				IDeath[] deathList = GetComponents<IDeath>();
				foreach (IDeath death in deathList){
					death.OnDeath();
				}
			}
		}
	}

	public void OnDeath()
	{
		// TODO
	}
}
