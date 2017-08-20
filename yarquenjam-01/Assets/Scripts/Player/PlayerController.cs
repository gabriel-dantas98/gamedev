using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	float speed = 7;

	void Update () {

		//guarda input "smooth" dos direcionais
		var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

		//cria um vetor resultante a partir dos direcionais e normaliza 
		Vector3 input = new Vector3(x, 0.0f, z);
		Vector3 direction = input.normalized;
 		
		//direção do movimento --> frente do personagem
		transform.rotation = Quaternion.LookRotation(direction);
		transform.Translate (direction * speed * Time.deltaTime, Space.World);

	}
}
