using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {
	float auxTime = 0.0f;
	float timeDestruction = 1.0f;

	void Update ()
	{
		auxTime += Time.deltaTime;
		if (auxTime > timeDestruction) {
			Destroy(gameObject);
		}
	
	}
}
