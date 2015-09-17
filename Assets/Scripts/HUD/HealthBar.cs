using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    float maxHealth = 100;
    float displayHealth = 0;
    float health = 0;

    [SerializeField]
	Image lifeBar;
    [SerializeField]
    Image playerIcon;


	// Use this for initialization
	void Start () {

		//lifeBar = this.gameObject.GetComponent<Image>();
	}

    public void SetIcon(Sprite icon)
    {
        playerIcon.sprite = icon;
    }

    public void SetMaxHealth(float value)
    {
        maxHealth = value;
        health = maxHealth;
        displayHealth = maxHealth;
    }

    public void SetHealth(float value)
    {
        health = value;
    }

	// Update is called once per frame
	void Update () {

	if (displayHealth / maxHealth >= 0){
        if (displayHealth > health)
        {
            displayHealth--;
        }
            if (lifeBar != null)    lifeBar.fillAmount = displayHealth / maxHealth;

		}

	}
}
