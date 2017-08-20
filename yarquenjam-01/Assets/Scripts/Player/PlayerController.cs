using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	float speed = 7.5f;

	void Update () {

		//guarda input "smooth" dos direcionais
		float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

		//cria um vetor resultante a partir dos direcionais e normaliza 
		Vector3 input = new Vector3(x, 0, z);
		Vector3 direction = input.normalized;
 		
		//direção do movimento --> frente do personagem
		transform.Translate (direction * speed * Time.deltaTime, Space.World);
		if(direction != Vector3.zero){
			Quaternion smooth = Quaternion.LookRotation(direction);
			transform.rotation = Quaternion.Slerp(transform.rotation,smooth, 15 * Time.deltaTime);
		}
		
		/*if (direction != Vector3.zero) {
    transform.rotation = Quaternion.Slerp(
        transform.rotation,
        Quaternion.LookRotation(direction),
        Time.deltaTime * speed
	);*/
	}
}

