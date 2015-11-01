using UnityEngine;
using System.Collections;

public class ShieldDecay : MonoBehaviour {

    float timer = 0;
	float materialDecay = 1;

	MeshRenderer sphereMeshRend;
	public Material transparentEnd;
	public Material transparentStart;
	Material current;

	// Use this for initialization
	void Start () {
		sphereMeshRend = this.GetComponent<MeshRenderer> ();
		sphereMeshRend.material.Lerp(transparentStart,transparentEnd,materialDecay);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= timer){
			if (materialDecay < 1) {
				materialDecay += 0.02f;
				sphereMeshRend.material.Lerp(transparentStart,transparentEnd,materialDecay);
			}
			else {
				GameObject.Destroy(this.gameObject);
			}
        }
		else {
			if (materialDecay > 0) {
				materialDecay -= 0.04f;
				sphereMeshRend.material.Lerp(transparentStart,transparentEnd,materialDecay);
			}
		}
	}

    public void SetTimer(float time)
    {
        timer = time;
    }
}
