﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Rigidbody))]
public class HingeConstrain : MonoBehaviour {

    Rigidbody _rigidbody;
    [SerializeField]
    Rigidbody _target;

    float _distance;


	// Use this for initialization
	void Start () {
	    _rigidbody = GetComponent<Rigidbody>();
        _distance = Vector3.Distance(_rigidbody.transform.position, _target.transform.position);
	}
	
	// Update is called once per frame
	void Update () {

       
        //Vector3
	}

    void FixedUpdate()
    {
        
    }

    void LateUpdate()
    {
        Vector3 tmpVector = _rigidbody.transform.position - _target.transform.position;
        Vector3.ClampMagnitude(tmpVector, _distance);
        _rigidbody.transform.position = _target.transform.position + tmpVector;
    }
}
