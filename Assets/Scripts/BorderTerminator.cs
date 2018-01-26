using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderTerminator : MonoBehaviour {

		void OnTriggerExit(Collider any){
			Destroy(any.gameObject);
		}
	}
