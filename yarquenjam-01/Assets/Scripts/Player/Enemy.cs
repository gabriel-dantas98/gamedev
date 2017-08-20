using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Transform targetTransform;
	public float speed = 2;

	void Update () {

		//calcula distancia entre eles, gera o vetor resultante da direção e normaliza
		Vector3 displacement = targetTransform.position - transform.position;
		Vector3 direction = displacement.normalized;
		Vector3 velocity = direction * speed;

		float distance = displacement.magnitude;

		//enemy segue sempre a certa distância
		if(distance > 1.5f) {
			transform.Translate(velocity * Time.deltaTime);
		}
	}
}
