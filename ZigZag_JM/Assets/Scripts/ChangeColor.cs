using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
	public float timer;
	public Material groundMaterial;

	private void Update(){
	
		timer -= Time.deltaTime;

		if(timer < 1){
			colorGenerator();
			timer = 6; 
		}
	
	}

	private void colorGenerator(){

		int index = Random.Range(0, 4);

		switch(index){
			case 0:
				groundMaterial.color = new Color(0f, 1f, 1f); break;
			case 1:
				groundMaterial.color = new Color(1f, 0.9847543f, 0f); break;
			case 2:
				groundMaterial.color = new Color(0.4852338f, 0f, 1f); break;
			case 3:
				groundMaterial.color = new Color(0.2595912f, 0.990566f, 0.2289516f); break;
			case 4:
				groundMaterial.color = new Color(0f, 0f, 0f); break;
		}

	}
}
