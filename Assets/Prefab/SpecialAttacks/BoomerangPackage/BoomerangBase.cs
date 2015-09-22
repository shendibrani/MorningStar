using UnityEngine;
using System.Collections;

public class BoomerangBase : MonoBehaviour {

	private Transform _baseTrans;
	public Transform _boomerangTransform;

	public Transform _aim;
	public Transform _back;
	
	public float _range = 15f;

	public float _speed = 0.2f;

	public float _maxRotSpeed = 0.15f;
	private float _finalRotSpeed;

	private float _distance;


	private int _state = 0;

	private GameObject _rotSet;

	private Quaternion _aimVector = Quaternion.identity;



	void Start () {

		_baseTrans = this.gameObject.GetComponent<Transform>();

		_rotSet = new GameObject ();
		_rotSet.transform.position = _baseTrans.position;
		_rotSet.transform.rotation = _baseTrans.rotation;
	}

	void Update () {
	
		if (_state == 0)
		{
			_rotSet.GetComponent<Transform> ().LookAt (_aim);
			_aimVector = _rotSet.GetComponent<Transform>().rotation;
		}
		else if (_state == 1)
		{
			_rotSet.GetComponent<Transform> ().LookAt (_aim);
			Quaternion _aimStore = _rotSet.transform.rotation;

			_rotSet.GetComponent<Transform>().LookAt (_back);
			_rotSet.GetComponent<Transform>().Rotate(0,180,0);
			Quaternion _backStore = _rotSet.transform.rotation;

			float _fraction = _distance/_range;

			_aimVector = Quaternion.Lerp(_backStore, _aimStore,_fraction);
			_aimVector = Quaternion.Lerp(_aimVector, _aimStore,_fraction);
		}
		else if (_state == 2)
		{
			_rotSet.GetComponent<Transform>().LookAt (_back);
			_rotSet.GetComponent<Transform>().Rotate(0,180,0);
			_aimVector = _rotSet.GetComponent<Transform>().rotation;
		}

		_finalRotSpeed = _maxRotSpeed - (_maxRotSpeed * _distance / _range);
		_baseTrans.rotation = Quaternion.Slerp (_baseTrans.rotation, _aimVector, _finalRotSpeed);


		//Projectile


		if (_distance < _range && _state == 0)
		{
			_distance += _speed;
		}
		else if (_distance >= _range && _state == 0)
		{
			_state = 1;
		}
		else if (_distance > 0 &&_state == 1)
		{
			_distance -= _speed;
		}
		else if (_distance <= 0 && _state == 1)
		{
			_state = 2;
		}
		else if (_state == 2)
		{
			_range = Vector3.Distance(_baseTrans.position,_back.position);

			if (_distance > -_range + 0.2) {
				_distance -= _speed;
			}
			else if (_distance < -_range - 0.2) {
				_distance += _speed;
			}
			else if (_distance > -_range - 0.2 && _distance < -_range + 0.2 ){

				if (Vector3.Distance(_back.position, _boomerangTransform.position) < 0.2) {
					Object.Destroy(_rotSet.gameObject);
					Object.Destroy(this.gameObject);
				}
			}
		}		
		_boomerangTransform.localPosition = new Vector3 (0,0,_distance);
		
	}


}
