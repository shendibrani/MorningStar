using UnityEngine;
using System.Collections;

public class ChickenAI : MonoBehaviour {

	NavMeshAgent _chicken;
	GameObject _destination;

	Vector3 _samplePos;
	NavMeshHit _hit;

	bool _moving = true;

	float _timer = 0;
	float _deltaTime = 0;
	float _distance = 1;

	float _x = 0;
	float _y = 0;

	float _stayTimer = 0;
	float _deltaStay = 0;

	Animator _anim;
	public GameObject _particleSys;
	public GameObject _egg;
	GameObject _Instance;
	GameObject _eggObj;

	// Use this for initialization
	void Start () {

		_destination = new GameObject();

		_anim = this.GetComponentInChildren<Animator> ();

		_chicken = this.gameObject.GetComponent<NavMeshAgent> ();
		randomPoint();
		_chicken.SetDestination (_destination.transform.position);
		
		_deltaTime = Random.Range (30,60);
		_timer = Time.time ;

		_Instance = GameObject.Instantiate (_particleSys);
		_Instance.transform.position = this.gameObject.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Path?: " + _chicken.hasPath);
		if (Time.time > _timer + _deltaTime)
		{
			_Instance = GameObject.Instantiate (_particleSys);
			_Instance.transform.position = this.gameObject.transform.position;

			Object.Destroy(this.gameObject);
		}

		if (Vector3.Distance (this.transform.position, _destination.transform.position) < 0.9 && _moving == true) {
			randomPoint();
			_stayTimer = Time.time;
			_moving = false;
			_deltaStay = Random.Range(2,5);

			_anim.SetFloat("Speed",2);
		}

		if (Time.time > _stayTimer + _deltaStay && _moving == false){
			_chicken.SetDestination (_destination.transform.position);
			_moving = true;

			_anim.SetFloat("Speed",0);
		}

		if (Random.Range (0, 100) == 1) {
		
			_eggObj = GameObject.Instantiate(_egg);
			_eggObj.transform.position = this.transform.position ;
            Destroy(_eggObj, 5f);
         
        }


	}

	void randomPoint(){

		_x = Random.Range (-50, 50) * 0.1f;
		_y = Random.Range (-50, 50) * 0.1f;
		_destination.transform.position = new Vector3 (_x, 0,_y);

		while (NavMesh.SamplePosition (_destination.GetComponent<Transform> ().position, out _hit, 0.4f, NavMesh.AllAreas) == false) {
			_x = Random.Range (-45, 45);
			_y = Random.Range (-45, 45);
			_destination.transform.position = new Vector3 (_x, 0,_y);
		}
	}

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "FireWall") {
            Destroy(_chicken);
            
        }
    }
}
