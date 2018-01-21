using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

	public Transform canvas;

	private bool isPauseNyala = false;

	public void NyalainPause() {
		isPauseNyala = !isPauseNyala;
		Time.timeScale = 0.0f;
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive (true);
		} else {
			canvas.gameObject.SetActive (false);
		}
	}

	public void Resume(){
		Time.timeScale = 1.0f;
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive (true);
		} else {
			canvas.gameObject.SetActive (false);
		}
	}

	public void Restart () {
		//Application.loadedLevel (Level.loadedLevel);
		SceneManager.LoadScene ("Coba");
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 0);
	}

	public void BackToMenu () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
	}
}
