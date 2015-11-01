using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour, IDeath
{

    Transform weaponBase;
    GameManager gameManager;

	bool _isDead = false;

    void Start()
    {
        //gameManager = transform.Find("Manager").GetComponent<GameManager>();
    }

    public void AttachWeapon(GameObject o)
    {
        weaponBase = o.transform;
    }

	public void OnDeath()
	{
		if (!_isDead)
		{
			Debug.Log("This");
			Transform parent = transform.parent;

			//foreach (DetonatePlayer d in GetComponentInChildren<DetonatePlayer>())
			//{
			//    d.OnDeath();
			//}

			//foreach (Collider c in parent.GetComponentsInChildren<Collider>())
			//{
			//c.enabled = true;
			//if (c.GetComponent<DealDamageOnCollision>()) c.GetComponent<DealDamageOnCollision>().enabled = false;
			//}

			foreach (RotateAroundAxis r in GetComponentsInChildren<RotateAroundAxis>())
			{
				r.enabled = false;
			}

			if (weaponBase != null)
			{
				weaponBase.transform.parent = this.transform.parent;
			}
			else
			{
				Debug.LogError("Need to set weapon base for process");
			}

			foreach (DealDamageOnCollision d in GetComponentsInChildren<DealDamageOnCollision>())
			{
				d.enabled = false;
			}

			GetComponent<Rigidbody>().useGravity = true;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			GetComponentInParent<PlayerAnimationHandler>().enabled = false;
			GetComponentInParent<Animator>().enabled = false;
			GetComponent<RigidBodyTopDownMovement>().enabled = false;
			//transform.FindChild("BodyP/HeadP").parent = transform.parent;

			foreach (Transform t in GetComponentInChildren<Transform>())
			{
				t.parent = transform.parent;
			}

			MessagingManager.Broadcast(Messages.DEATH, this.transform.parent.gameObject);
			_isDead = true;
		}
	}
}
