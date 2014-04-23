using UnityEngine;
using System.Collections;

public class KinokoMaker : MonoBehaviour {

	public GameObject Mashroom;
	public Vector3 offset=new Vector3(0,2,0);

	void OnTriggerEnter(Collider c){
		if(c.name == "Player"){
			Instantiate (Mashroom, this.transform.position + offset, Quaternion.Euler(-90,0,0));
			Destroy (this.gameObject);
		}
	}
}
