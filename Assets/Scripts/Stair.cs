using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;

public class Stair : MonoBehaviour
{

	public Vector3 startPos;
	public GameObject stairPrefab;

	float stairX, stairY;
	private void Awake()
	{
		stairX = 0.5f;
		stairY = 0.25f;
		startPos = new Vector3(0,-0.75f,0);
		Init();

	}

	private void Init()
	{
		// .. 초기 계단생성
		for (int i = 0; i < 50; i++)
		{
			GameObject stair = Instantiate(stairPrefab, transform);
			stair.transform.position = startPos;
			stair.transform.position += (Random.Range(0, 2) == 0) ? Vector3.left * stairX : Vector3.right * stairX;
			stair.transform.position += Vector3.up * stairY;
			startPos = stair.transform.position;
		}

	}

	public void RespawnStair(GameObject stair)
	{
		// .. 계단 설정
		stair.transform.position = startPos;
		stair.transform.position += (Random.Range(0, 2) == 0) ? Vector3.left * stairX : Vector3.right * stairX;
		stair.transform.position += Vector3.up * stairY;
		startPos = stair.transform.position;
		//stairs[i] = stairs[i];
	}


}



