using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController> {
	public Text lifeSupportText;
	public Text lifeSupportTextDark;
	public Text temperatureText;
	public Text temperatureTextDark;
	public int temperatureStartingNum;
	public int tempChangeChance;
	public float minTempChangeTime;

	private int lifeSupportAmount;
	private string originalLifeSupportText;

	private int currentTemperature;
	private string originalTemperatureText;
	private float tempChangeCount;

	void Awake() {
		originalLifeSupportText = lifeSupportText.text;
		lifeSupportAmount = int.MaxValue;

		originalTemperatureText = temperatureText.text;
		currentTemperature = temperatureStartingNum;
		temperatureText.text = string.Format("{0}{1}", currentTemperature, originalTemperatureText);
		temperatureTextDark.text = string.Format("{0}{1}", currentTemperature, originalTemperatureText);
	}

	void Update() {
		UpdateTemperature();
	}

	public void UpdateLifeSupportText(float amount) {
		int roundAmount = (int)amount / 10;

		if (roundAmount < 0)
			return;

		if(roundAmount < lifeSupportAmount) {
			lifeSupportAmount = roundAmount;
			lifeSupportText.text = string.Format("{0} {1}%", originalLifeSupportText, lifeSupportAmount);
			lifeSupportTextDark.text = string.Format("{0} {1}%", originalLifeSupportText, lifeSupportAmount);
		}
	}

	private void UpdateTemperature() {
		tempChangeCount += Time.deltaTime;

		if (tempChangeCount < minTempChangeTime)
			return;

		tempChangeCount = 0f; 

		int chance = Random.Range(0, 100);

		if (chance > tempChangeChance)
			return;

		chance = Random.Range(0, 2);

		currentTemperature = chance == 0 ? currentTemperature - 1 : currentTemperature + 1;
		temperatureText.text = string.Format("{0}{1}", currentTemperature, originalTemperatureText);
		temperatureTextDark.text = string.Format("{0}{1}", currentTemperature, originalTemperatureText);
	}
}
