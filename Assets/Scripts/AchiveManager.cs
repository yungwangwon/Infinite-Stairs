using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchiveManager : MonoBehaviour
{

	public GameObject[] lockChar;
	public GameObject[] unlockChar;
	public GameObject uiNotice;

	WaitForSecondsRealtime wait;

	public enum Achive
	{
		Pet01,
		Pet02,
		Pet03,
		Pet04,
		Pet05,
		Pet06,
	}

	Achive[] achives;

	private void Awake()
	{
		achives = (Achive[])Enum.GetValues(typeof(Achive));
		wait = new WaitForSecondsRealtime(3.0f);
			Init();
	}

	// 초기 설정
	void Init()
	{
		PlayerPrefs.SetInt("MyData", 1);

		foreach (Achive achive in achives)
		{
			PlayerPrefs.SetInt(achive.ToString(), 0);
		}
	}

	private void Start()
	{
		UnLockChar();
	}

	// 캐릭터 해금
	void UnLockChar()
	{
		for (int i = 0; i < lockChar.Length; i++)
		{
			string achiveName = achives[i].ToString();
			bool isUnlock = PlayerPrefs.GetInt(achiveName) == 1;
			lockChar[i].SetActive(!isUnlock);
			unlockChar[i].SetActive(isUnlock);
		}
	}

	private void LateUpdate()
	{
		foreach (Achive achive in achives)
		{
			CheckAchive(achive);
		}
	}

	private void CheckAchive(Achive achive)
	{
		bool isAchive = false;

		// 해금 조건 판별
		switch (achive)
		{
			case Achive.Pet01:
				if(GameManager.instance.score >= 0)
					isAchive = true;
				break;
			case Achive.Pet02:
				if (GameManager.instance.score >= 50)
					isAchive = true;
				break;
			case Achive.Pet03:
				if (GameManager.instance.score >= 100)
					isAchive = true;
				break;
			case Achive.Pet04:
				if (GameManager.instance.score >= 150)
					isAchive = true;
				break;
			case Achive.Pet05:
				if (GameManager.instance.score >= 200)
					isAchive = true;
				break;
			case Achive.Pet06:
				if (GameManager.instance.score >= 250)
					isAchive = true;
				break;
		}

		// 활성화
		if (isAchive && PlayerPrefs.GetInt(achive.ToString()) == 0)
		{
			PlayerPrefs.SetInt(achive.ToString(), 1);

			uiNotice.GetComponentsInChildren<Image>()[1].sprite = GameManager.instance.resourcesManager.petSprites[(int)achive];
			GameManager.instance.resourcesManager.SetButton(achive);

			StartCoroutine("NoticeRoutine");
		}
	}

	IEnumerator NoticeRoutine()
	{
		uiNotice.SetActive(true);
		AudioManager.instance.SfxPlay(AudioManager.Sfx.UnLock);

		yield return wait;
		uiNotice.SetActive(false);

	}



}
