using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

	[Header("# UI")]
	public GameObject deadUI;
	public GameObject mainUI;
	public GameObject ingameUI;

	[Header("# Dead Component")]
	public Text bestScore;
	public Text score;

	[Header("# Main Component")]
	public Text bestScore_Main;
	public Text coin;

	[Header("# Scroll UI")]
	public GameObject scroll;
	public GameObject scrollAchive;
	public GameObject[] btns;

	public void Dead()
	{
		deadUI.SetActive(true);
		mainUI.SetActive(false);
		ingameUI.SetActive(false);
		AudioManager.instance.BgmPlay(false);

	}

	public void Main()
	{
		deadUI.SetActive(false);
		mainUI.SetActive(true);
		ingameUI.SetActive(false);
		GameManager.instance.Init();

	}

	public void Play()
	{
		if (!mainUI.activeSelf)
			GameManager.instance.Init();

		deadUI.SetActive(false);
		mainUI.SetActive(false);
		ingameUI.SetActive(true);
		scrollAchive.SetActive(false);
		scroll.SetActive(false);

		AudioManager.instance.BgmPlay(true);
		GameManager.instance.isLive = true;


	}

	public void SetScoreText()
	{
		bestScore.text = "Best Score : " + GameManager.instance.bestScore.ToString();
		score.text = "Score : " + GameManager.instance.score.ToString();
	}

	public void SetMainText()
	{
		bestScore_Main.text = "Best : " + GameManager.instance.bestScore.ToString();
		coin.text = GameManager.instance.money.ToString();
	}

	// 버튼 활성화, 비활성화
	public void Btn(int num)
	{
		if (scrollAchive.activeSelf)
			scrollAchive.SetActive(false);

		if (scroll.activeSelf)
		{

			if (btns[num].activeSelf)
			{
				btns[num].SetActive(false);	
				scroll.SetActive(false);
				AudioManager.instance.SfxPlay(AudioManager.Sfx.Button);
				return;
			}

			for (int i = 0; i < btns.Length; i++)
			{
				if (i == num)
					btns[i].SetActive(true);
				else
					btns[i].SetActive(false);
			}
		}
		else
		{
			scroll.SetActive(true);
			for (int i = 0; i < btns.Length; i++)
			{
				if (i == num)
					btns[i].SetActive(true);
				else
					btns[i].SetActive(false);
			}
		}

		AudioManager.instance.SfxPlay(AudioManager.Sfx.Button);

	}

	// 미션 버튼
	public void BtnAchive()
	{
		if (scroll.activeSelf)
			scroll.SetActive(false);

		if (scrollAchive.activeSelf)
		{
			scrollAchive.SetActive(false);
		}
		else
			scrollAchive.SetActive(true);


		AudioManager.instance.SfxPlay(AudioManager.Sfx.Button);
	}

}
