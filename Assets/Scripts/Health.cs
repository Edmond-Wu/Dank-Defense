using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	TextMesh health;
	public TextMesh monetary_reward;
	public GameObject explosion;
	public GameObject g;
	private Spawn spawn;
	int health_value;
	public int points_value;
	public int cash_value;

	// Use this for initialization
	void Start () {
		GameObject spawn_obj = GameObject.FindWithTag ("Spawn");
		if (spawn_obj != null) {
			spawn = spawn_obj.GetComponent<Spawn> ();
		} 
		else {
			Debug.Log ("Cannot find 'Spawn' script");
		}
		health = GetComponent<TextMesh> ();
		health_value = health.text.Length;
	}
	
	// Update is called once per frame
	void Update () {
		transform.forward = Camera.main.transform.forward;
	}

	public int Current() {
		return health_value;
	}

	public void Decrease() {
		if (Current () > 1) {
			health.text = health.text.Substring(0, health.text.Length - 1);
			health_value--;
		} 
		else {
			Instantiate (explosion, g.transform.position, g.transform.rotation);
			Instantiate (monetary_reward, g.transform.position + Vector3.up + Vector3.up, Quaternion.identity);
			Destroy (transform.parent.gameObject);
			if (g.tag == "Monster") {
				spawn.AddPoints (points_value);
				spawn.MakeKash (cash_value);
			}
			else if (g.tag == "Prize") {
				spawn.GameOver();
			}
		}
	}
}
