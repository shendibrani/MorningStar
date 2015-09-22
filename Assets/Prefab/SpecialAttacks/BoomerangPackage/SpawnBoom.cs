using UnityEngine;
using System.Collections;

public class SpawnBoom : MonoBehaviour {

	public GameObject _boomerang;
	GameObject Boomerang;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && Boomerang == null) {
			Object _boomerangInst = Instantiate(_boomerang, this.transform.position,this.transform.rotation);
			_boomerangInst.name = "Boomerang";
			Boomerang = GameObject.Find("Boomerang");

			Boomerang.GetComponent<Transform>().localPosition += new Vector3(-0.1f,0,0);
			BoomerangBase _script = Boomerang.GetComponent<BoomerangBase>();
			_script._aim = GameObject.Find("P2").transform;
			_script._back = this.transform;
		}

	}
}
