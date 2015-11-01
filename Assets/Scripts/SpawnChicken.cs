using UnityEngine;
using System.Collections;

public class SpawnChicken : MonoBehaviour {

	float _x = 0;
	float _y = 0;

	NavMeshHit _hit;

	GameObject _Point;
	public GameObject _chicken;
	GameObject _Instance;

	bool _alive = false;

	// Use this for initialization
	void Start () {
		_Point = new GameObject();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (_alive == false) {
			if (Random.Range (1,1000) == 1) {
				randomPoint();
				_Instance = GameObject.Instantiate(_chicken);
				_Instance.transform.position = _Point.transform.position;
				_alive = true;
			}
		}

		if (_Instance == null && _alive == true) {
		
			_alive = false;

		}

	}

	void randomPoint()
    {
		_x = Random.Range (-50, 50) * 0.1f;
		_y = Random.Range (-50, 50) * 0.1f;
		_Point.transform.position = new Vector3 (_x, 0,_y);
		
		while (NavMesh.SamplePosition (_Point.GetComponent<Transform> ().position, out _hit, 0.4f, NavMesh.AllAreas) == false) {
			_x = Random.Range (-45, 45);
			_y = Random.Range (-45, 45);
			_Point.transform.position = new Vector3 (_x, 0,_y);
		}
	}
}
