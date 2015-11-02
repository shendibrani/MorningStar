using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShockwaveAbility : Ability
{
	[SerializeField] float range, force;

	public override void Execute ()
	{
		List<Rigidbody> targets = new List<Rigidbody>(FindObjectsOfType<Rigidbody>());
		targets = targets.FindAll(x => 
		                          x != GetComponent<RigidBodyTopDownMovement>() && 
		                          Vector3.Distance(transform.position, x.transform.position) <= range);

		foreach(Rigidbody target in targets){
			if(target.GetComponent<RigidBodyTopDownMovement>() != null){
				target.GetComponent<RigidBodyTopDownMovement>().Push(target.transform.position - transform.position, force);
			} else {
				target.AddForce((target.transform.position - transform.position).normalized * force, ForceMode.Impulse);
			}
		}
	}	
}

