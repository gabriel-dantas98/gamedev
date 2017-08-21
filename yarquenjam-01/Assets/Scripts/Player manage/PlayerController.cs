using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	 
	float speed = 7.5f;
	Rigidbody myRigidbody;
	Vector3 direction;

	void Start(){
		myRigidbody = GetComponent<Rigidbody>();
	}

	void Update () {

		//guarda input "smooth" dos direcionais
		float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

		//cria um vetor resultante a partir dos direcionais e normaliza 
		Vector3 input = new Vector3(x, 0, z);
		direction = input.normalized;
 		
		//direção do movimento --> frente do personagem
		if(direction != Vector3.zero){
			Quaternion smooth = Quaternion.LookRotation(direction);
			transform.rotation = Quaternion.Slerp(transform.rotation,smooth, 15 * Time.deltaTime);
		}
	}

	void FixedUpdate(){
		transform.Translate (direction * speed * Time.deltaTime, Space.World);
	}
}

