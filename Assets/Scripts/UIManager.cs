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

	public void Dead()
	{
		deadUI.SetActive(true);
		mainUI.SetActive(false);
		ingameUI.SetActive(false);

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
		deadUI.SetActive(false);
		mainUI.SetActive(false);
		ingameUI.SetActive(true);
		GameManager.instance.Init();
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


}
