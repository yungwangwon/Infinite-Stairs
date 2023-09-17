using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
	Vector3 initPos;
	Vector3 initDir;

	private void Awake()
	{
		initPos = transform.position;
	}

	public void Init()
	{
		transform.position = initPos;
		initDir = initPos - GameManager.instance.player.transform.position;

	}

	public void Up()
	{
		Vector3 playerPos = GameManager.instance.player.transform.position;
		transform.position = playerPos + (Vector3.down * GameManager.instance.score * 0.1f) + initDir;
	}
	
}
