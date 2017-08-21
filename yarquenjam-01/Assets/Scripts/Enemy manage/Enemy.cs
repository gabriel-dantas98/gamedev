using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Transform targetTransform;
	float speed = 2.5f;
	Vector3 velocity;
	Rigidbody myRigidbody;

	void Start(){
		myRigidbody = GetComponent<Rigidbody> ();
	}

	void Update () {

		//calcula distancia entre eles, gera o vetor resultante da direção e normaliza
		Vector3 displacement = targetTransform.position - transform.position;
		Vector3 direction = displacement.normalized;
		velocity = direction * speed;

		if (displacement.magnitude < 1.5) {
			Vector3 velocity = Vector3.zero;
		}

		transform.rotation = Quaternion.LookRotation(direction);
	}

	void FixedUpdate(){
		myRigidbody.position += velocity * Time.deltaTime;
	}
}
