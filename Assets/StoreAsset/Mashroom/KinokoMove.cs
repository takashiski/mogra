using UnityEngine;
using System.Collections;

public class KinokoMove : MonoBehaviour {
	public Vector3 moveDir = new Vector3(10,0,0);

	void Start(){
		this.rigidbody.velocity = moveDir;
	}
	// Update is called once per frame
	void Update () {

		Vector3 v = rigidbody.velocity;
		// Raycast down from the center of the character.. 
		Ray ray;
		if( v.x >= 0 ) {
			ray = new Ray(transform.position+Vector3.up/2, Vector3.right);
		} else {
			ray = new Ray(transform.position+Vector3.up/2, -transform.right);
		}
		RaycastHit hitInfo = new RaycastHit();
		if (Physics.Raycast(ray, out hitInfo))
		{
			//Debug.Log( "dist = " + hitInfo.distance );
			if( hitInfo.distance < 1f ) {
				v.x *= -2.0f;
				this.rigidbody.velocity = v;

			}
		}

	}
	void OnCollisionEnter(Collision c){

	}
}
