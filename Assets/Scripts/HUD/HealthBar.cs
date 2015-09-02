using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public float _health;
	private float _maxhealth = 0;
	private Image LifeBar;


	// Use this for initialization
	void Start () {

		_maxhealth = _health;

		LifeBar = this.gameObject.GetComponent<Image>();
 
	}
	
	// Update is called once per frame
	void Update () {

	if (_health / _maxhealth >= 0){

			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				
				_health = _health - 1;

			}

			LifeBar.fillAmount = _health / _maxhealth;

		}

	}
}
