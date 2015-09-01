using UnityEngine;
using System.Collections;

public class ReceiveDamageOnCollision : MonoBehaviour, IDeath
{
	public float health;

	void OnCollisionEnter(Collision c)
	{
		if(c.collider.GetComponent<DealDamageOnCollision>() != null){
			health -= c.collider.GetComponent<DealDamageOnCollision>().damage;
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
