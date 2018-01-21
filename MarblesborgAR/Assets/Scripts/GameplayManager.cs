using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour {

	public static GameplayManager instance;
	public float CountdownTimer = 3f;

	public Transform canvasWin;
	public Transform canvasLose;

	public Transform Tower;
	public Text countdown_label;
	public Text timer_label;
	public Image healthbar_image;
	public float health;
	public float maxHealth;

	public float timer = 30f;
	//Reference Object :
	private CameraSettings mCamSettings = null;
	private TrackableSettings mTrackableSettings = null;

	public bool isRunning = false;
	public bool isPlaying = false;

	private bool isFlashNyala = false;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		Time.timeScale = 1.0f;
		countdown_label.text = "";
		mCamSettings = FindObjectOfType<CameraSettings>();
		mTrackableSettings = FindObjectOfType<TrackableSettings>();

		mCamSettings.SwitchAutofocus(true);
		mTrackableSettings.SwitchExtendedTracking (true);
	}

	public void NyalainFlash(){
		isFlashNyala = !isFlashNyala;
		mCamSettings.SwitchFlashTorch (isFlashNyala);
	}

	IEnumerator IEAttemptTOStartGame;
	public void StartTimer(){
		if (isRunning == false && isPlaying == false) {
			IEAttemptTOStartGame = AttemptToStartGame ();
			StartCoroutine (IEAttemptTOStartGame);
		}
	}

	public void StopTimer(){
		if (isRunning == true) {
			if (IEAttemptTOStartGame != null) {
				countdown_label.text = "";
				StopCoroutine (IEAttemptTOStartGame);
				isRunning = false;
			}
		}
	}

	IEnumerator AttemptToStartGame(){
		isRunning = true;
		float i = CountdownTimer;
		while (i > 0) {
			countdown_label.text = ""+i;
			Debug.Log (i);
			yield return new WaitForSeconds (1f);
			i--;
		}
		isPlaying = true;
		Debug.Log ("SEDANG BERMAIN");
		countdown_label.text = "";
		UDTEventHandler.instance.BuildNewTarget ();
		//Start Game / Spawn something
		maxHealth = health;
		StartCoroutine (StartGameTimer ());
	}

	IEnumerator StartGameTimer(){
		Debug.Log ("Game Timer Start");
		float i = timer;
		while (i > 0) {
			timer_label.text = ""+i;
			Debug.Log (i);
			yield return new WaitForSeconds (1f);
			i--;
		}
		if (health > 0) {
			Debug.Log ("SURVIVED ! SELAMAT !");
			Time.timeScale = 0.0f;
			canvasWin.gameObject.SetActive (true);
		}
	}

	public void DecreaseHealth(float damage){
		health -= damage;
		healthbar_image.fillAmount = health / maxHealth;
		if (health <= 0) {
			Debug.Log ("GAME OVER !!!");
			Time.timeScale = 0.0f;
			canvasLose.gameObject.SetActive (true);
		}
	}
}
