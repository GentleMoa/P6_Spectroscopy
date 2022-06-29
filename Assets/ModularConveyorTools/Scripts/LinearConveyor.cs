using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LinearConveyor : MonoBehaviour {

	public float distance = 1f;
	public bool instancedMaterial;

	private Rigidbody rb;
	private Collider col;

	private MeshRenderer mr;

	public float speed = 0.5f;

	// Use this for initialization
	void Start () {
		RefreshReferences ();

		ChangeSpeed (speed);
	}

	public void RefreshReferences(){
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.isKinematic = true;
		rb.useGravity = false;
		col = gameObject.GetComponent<Collider> ();
		if (col == null) {
			col = gameObject.AddComponent<MeshCollider> ();
		}

		mr = gameObject.GetComponent<MeshRenderer> ();
		if (mr == null)
			mr = gameObject.GetComponentInChildren<MeshRenderer> ();
		if (mr == null)
			Debug.LogError ("Linear Conveyor needs to be attached to the belt Object");
	}

	// Update is called once per frame
	void FixedUpdate () {
		// 'Teleport' rigidbody back and Move forward with physics the same amount each frame
		Vector3 mov = transform.forward * Time.deltaTime * speed / distance;
		rb.position =  (rb.position - mov);
		rb.MovePosition (rb.position + mov);

	}

	public void ChangeSpeed (float _speed) {
		// change the speed of the physics and update the shader
		speed = _speed;
		// Create a new material instance
		if (instancedMaterial) {
			Material tempMat = new Material (mr.sharedMaterial);
			tempMat.SetFloat ("_Speed", speed);
			mr.material = tempMat;
		} else {
			mr.sharedMaterial.SetFloat ("_Speed", speed);
		}

	}
}
