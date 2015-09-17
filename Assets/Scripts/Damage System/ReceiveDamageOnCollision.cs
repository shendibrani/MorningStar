using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class ReceiveDamageOnCollision : MonoBehaviour, IDeath
{
    [SerializeField]
	float _health;
    HealthBar _healthBar;
    float _maxHealth;

    public float health
    {
        get
        {
            return _health;
        }

		set
		{
			_health = value;
			_maxHealth = _health;
			if (_healthBar != null) _healthBar.SetMaxHealth(_health);
		}
    }

    public float maxHealth
    {
        get
        {
            return _maxHealth;
        }
    }

    public HealthBar healthBar
    {
        set
        {
            _healthBar = value;
			if (_healthBar != null) _healthBar.SetMaxHealth(_health);
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
        _health -= damage;
        if (_healthBar != null) _healthBar.SetHealth(_health);
        CheckDeath();
    }

    public void CheckDeath()
    {
        if ((_health <= 0) && (GetComponentInParent<PlayerInfo>().State == PlayerInfo.PlayerState.ALIVE))
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
