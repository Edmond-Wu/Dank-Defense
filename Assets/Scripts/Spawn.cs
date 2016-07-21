using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject monster;
	public GameObject monster_upgrade;
	public GameObject boss;
	public float time_between_spawns = 3;
	public int num_monsters = 10;
	public float begin_wait;
	public float between_waves = 5;
	private int wave_count = 1;
	private int score = 0;
	private int cash = 100;
	
	public GUIText score_display;
	public GUIText cash_display;
	//public GUIText restart_display;
	public GUIText gameover_display;
	public GUIText start_display;
	//public GUIText menu;
	//public GUIText instructions;
	
	private bool game_over;
	private bool restart;
	private bool start_game;

	// Use this for initialization
	void Start () {
		UpdateScore ();
		UpdateKash ();
		game_over = false;
		restart = false;
		start_game = false;
		gameover_display.text = "";
		start_display.text = "Press Enter";
		//InvokeRepeating("SpawnNext", time_between_spawns, time_between_spawns);
	}

	void SpawnNext() {
		if (wave_count % 5 == 0) {
			Instantiate (boss, transform.position, Quaternion.identity);
		} else {
			if (wave_count < 3) {
				Instantiate (monster, transform.position, Quaternion.identity);
			} else if (wave_count < 5) {
				Instantiate (monster, transform.position, Quaternion.identity);
				Instantiate (monster_upgrade, transform.position - Vector3.back, Quaternion.identity);
			} else {
				time_between_spawns = 1;
				Instantiate (monster_upgrade, transform.position, Quaternion.identity);
			}
		}
	}

	void Update() {
		if ((Input.GetKeyDown("return") || Input.GetKeyDown("enter")) && !restart) {
			start_game = true;
			start_display.text = "";
			if (start_game) {
				StartCoroutine (SpawnMonsters ());
				GetComponent<AudioSource>().Play();
			}
		}
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnMonsters() {
		yield return new WaitForSeconds(begin_wait);
		while(true) {
			if (wave_count % 5 == 0) {
				num_monsters = 1;
			}
			else {
				num_monsters = 10;
			}
			for (int i = 0; i < num_monsters; i++) {
				SpawnNext ();
				yield return new WaitForSeconds(time_between_spawns);
			}
			wave_count++;
			yield return new WaitForSeconds(between_waves);
			if (game_over) {
				//restart_display.text = "Press R to Restart";
				restart = true;
				start_game = false;
				break;
			}
		}
	}

	public void GameOver() {
		gameover_display.text = "GAME OVER";
		game_over = true;
		restart = true;
		GetComponent<AudioSource>().Stop();
	}

	public void AddPoints(int points) {
		score += points;
		UpdateScore ();
	}

	void UpdateScore() {
		score_display.text = "Score: " + score;
	}

	public void MakeKash(int points) {
		cash += points;
		UpdateKash ();
	}
	
	void UpdateKash() {
		cash_display.text = "Cash: " + cash;
	}

	public int GetKash() {
		return cash;
	}
}
