using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

	private int currentMoney;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		currentMoney = 0;
	}

	public void AddMoney(int newMoney) {
		currentMoney += newMoney;
		updateScoreCounter ();
	}

	public void RemoveMoney(int removedMoney) {
		currentMoney -= removedMoney;
		updateScoreCounter ();
	}

	public bool HasEnoughMoney (int checkedMoney) {
		return currentMoney >= checkedMoney;
	}

	//updates the display that shows how much money you have
	private void updateScoreCounter () {
		scoreText.text = "Current Money : $" + currentMoney;
	}
	/*
	public int getCurrentMoney () {
		return currentMoney;
	}
	*/
}
