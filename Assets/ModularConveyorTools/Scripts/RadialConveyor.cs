using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RadialConveyor : MonoBehaviour {

	public bool instancedMaterial;

	//axis that the object spins on
	public Vector3 angleAxis = Vector3.up;
	//radius from the 'center' of the loop to the belt edge
	public float radius = 2f;
	// distance along curve
	private float distance = 1f;
	// all belts in demo are 90 deg angles, this can be adapted but was set to 90 for convenience 
	private float angle = 90f;

	private Rigidbody rb;
	private Collider col;

	private MeshRenderer mr;

	public float speed = 0.5f;

	// Use this for initialization
	void Start () {
		RefreshReferences ();

		ChangeSpeed (speed);
	}

	public void RefreshReferences() {
		//calculate distance from C=2rPi, then divide by angle%of circle
		distance = 1f*radius * Mathf.PI * (angle / 360f);

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
		if (mr==null)
			Debug.LogError ("Radial Conveyor needs to be attached to the belt Object");
	}

	// Update is called once per frame
	void FixedUpdate () {
		// 'Teleport' Rigidbody rotation then Rotate with physics the same degree each frame
		rb.rotation *= Quaternion.AngleAxis (angle * speed * Time.deltaTime/distance, angleAxis);
		Quaternion newRot = rb.rotation * Quaternion.AngleAxis (-angle * speed * Time.deltaTime/distance, angleAxis);
		rb.MoveRotation (newRot);

	}

	public void ChangeSpeed (float _speed) {
		// Set speed for physics and shader
		speed = _speed;
		if (instancedMaterial) {
			Material tempMat = new Material (mr.sharedMaterial);
			tempMat.SetFloat ("_Speed", speed);
			mr.material = tempMat;
		} else {
			mr.sharedMaterial.SetFloat ("_Speed", speed);
		}
	}
}
