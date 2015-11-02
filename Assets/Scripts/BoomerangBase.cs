using UnityEngine;
using System.Collections;

public class BoomerangBase : MonoBehaviour {

	public Transform _boomerangTransform;
    
    Transform target;
	Transform player;
	
	public float _range = 15f;

	public float _speed = 0.2f;

	public float _maxRotSpeed = 0.15f;
	private float _finalRotSpeed;

	private float _distance;


	private int _state = 0;

	private GameObject _rotSet;

	private Quaternion _aimVector = Quaternion.identity;



	void Start () {

		_rotSet = new GameObject ();
        _rotSet.transform.position = transform.position;
        _rotSet.transform.rotation = transform.rotation;
	}

    public void SetTargets(Transform iPlayer, Transform iTarget)
    {
        player = iPlayer;
        target = iTarget;
        Debug.Log(player + " boomerang " + target);
    }

    void Update()
    {

        if (this.gameObject != null)
        {
            if (_state == 0)
            {
                _rotSet.transform.LookAt(target);
                _aimVector = _rotSet.transform.rotation;
            }
            else if (_state == 1)
            {
                _rotSet.transform.LookAt(target);
                Quaternion _aimStore = _rotSet.transform.rotation;

                _rotSet.transform.LookAt(player);
                _rotSet.transform.Rotate(0, 180, 0);
                Quaternion _backStore = _rotSet.transform.rotation;

                float _fraction = _distance / _range;

                _aimVector = Quaternion.Lerp(_backStore, _aimStore, _fraction);
                _aimVector = Quaternion.Lerp(_aimVector, _aimStore, _fraction);
            }
            else if (_state == 2)
            {
                _rotSet.transform.LookAt(player);
                _rotSet.transform.Rotate(0, 180, 0);
                _aimVector = _rotSet.transform.rotation;
            }

            _finalRotSpeed = _maxRotSpeed - (_maxRotSpeed * _distance / _range);
            transform.rotation = Quaternion.Slerp(transform.rotation, _aimVector, _finalRotSpeed);


            //Projectile


            if (_distance < _range && _state == 0)
            {
                _distance += _speed;
            }
            else if (_distance >= _range && _state == 0)
            {
                _state = 1;
            }
            else if (_distance > 0 && _state == 1)
            {
                _distance -= _speed;
            }
            else if (_distance <= 0 && _state == 1)
            {
                _state = 2;
            }
            else if (_state == 2)
            {
                Debug.Log(transform.position);
                Debug.Log(player.position);
                Debug.Log(_range);
                _range = Vector3.Distance(transform.position, player.position);

                if (_distance > -_range + 0.2)
                {
                    _distance -= _speed;
                }
                else if (_distance < -_range - 0.2)
                {
                    _distance += _speed;
                }
                else if (_distance > -_range - 0.2 && _distance < -_range + 0.2)
                {

                    if (Vector3.Distance(player.position, _boomerangTransform.position) < 0.2)
                    {
                        Object.Destroy(_rotSet.gameObject);
                        Object.Destroy(this.gameObject);
                    }
                }
            }
            _boomerangTransform.localPosition = new Vector3(0, 0, _distance);

        }
    }


}
