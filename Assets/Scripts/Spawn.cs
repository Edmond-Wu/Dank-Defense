using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject monster;
	public float time_between_spawns = 3;
	public int num_monsters = 10;
	public float begin_wait;
	public float between_waves = 5;
	private int score = 0;
	private int cash = 100;
	
	public GUIText score_display;
	public GUIText cash_display;
	//public GUIText restart_display;
	//public GUIText gameover_display;
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
		//InvokeRepeating("SpawnNext", time_between_spawns, time_between_spawns);
	}

	void SpawnNext() {
		Instantiate(monster, transform.position, Quaternion.identity);
	}

	void Update() {
		if ((Input.GetKeyDown("return") || Input.GetKeyDown("enter")) && !restart) {
			start_game = true;
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
			for (int i = 0; i < num_monsters; i++) {
				SpawnNext ();
				yield return new WaitForSeconds(time_between_spawns);
			}
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
		//gameover_display.text = "Game Over\n\nYour score was: " + score;
		game_over = true;
		GetComponent<AudioSource>().Stop();
	}
	/*
	void Start() {
		score = 0;
		UpdateScore ();
		gameover_display.text = "";
		restart_display.text = "";
		menu.text = "Welcome to Interstellar Shooter\nPress Enter to start!";
		instructions.text = "WASD or arrow keys to move\nLeft-click or space to shoot";
		game_over = false;
		restart = false;
		start_game = false;
	}
	
	void Update() {
		if ((Input.GetKeyDown("return") || Input.GetKeyDown("enter")) && !restart) {
			menu.text = "";
			instructions.text = "";
			start_game = true;
			if (start_game) {
				StartCoroutine (SpawnAsteroids ());
			}
		}
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	
	IEnumerator SpawnAsteroids() {
		yield return new WaitForSeconds(begin_wait);
		while(true) {
			for (int i = 0; i < num_asteroids; i++) {
				Vector3 spawn_position = new Vector3 (Random.Range (-spawn_value.x, spawn_value.x), spawn_value.y, spawn_value.z);
				Quaternion spawn_rotation = Quaternion.identity;
				Instantiate (asteroid, spawn_position, spawn_rotation);
				yield return new WaitForSeconds(wait_spawn);
			}
			yield return new WaitForSeconds(between_waves);
			if (game_over) {
				restart_display.text = "Press R to Restart";
				restart = true;
				start_game = false;
				break;
			}
		}
	}*/
	
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
	/*
	public void GameOver() {
		gameover_display.text = "Game Over\n\nYour score was: " + score;
		game_over = true;
		GetComponent<AudioSource>().Stop();
	}
	*/
}
