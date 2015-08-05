using UnityEngine;
using System.Collections;

public class ExplosionRemoval : MonoBehaviour {

	public float lifetime;

	void Start () {
		Destroy (gameObject, lifetime);
	}
}
