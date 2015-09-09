using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarBehaviour : MonoBehaviour {

	[SerializeField] Image background;
	[SerializeField] Image bar;

	[SerializeField] float maxValue;

	float _currentValue;
	public float currentValue {
		get {
			return _currentValue;
		}
		set {
			_currentValue = Mathf.Clamp(value, 0, maxValue);
			//bar.fillAmount = ratio;
		}
	}

	float ratio { get { return currentValue/maxValue; } }

	public void Setup(float max, float current)
	{
		maxValue = max;
		currentValue = current;
	}

	void Update () {
		if(maxValue != 0){
			float value = (bar.fillAmount - ratio) * 0.2f; 
			bar.fillAmount -= value;
		}
	}
}
