using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	TextMesh health;
	public GameObject castle_explosion;
	public GameObject prize;

	// Use this for initialization
	void Start () {
		health = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.forward = Camera.main.transform.forward;
	}

	public int Current() {
		return health.text.Length;
	}

	public void Decrease() {
		if (Current () > 1) {
			health.text = health.text.Remove (health.text.Length - 1);
		} 
		else {
			Instantiate (castle_explosion, prize.transform.position, prize.transform.rotation);
			Destroy (transform.parent.gameObject);
		}
	}
}
