using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Stair : MonoBehaviour
{

	Transform startPos;

	float stairX, stairY;
	private void Awake()
	{
		stairX = 0.5f;
		stairY = 0.25f;
		startPos = transform;
	}

	private void Start()
	{
		// setting
		// .. 계단생성
		for(int i = 0;i<10;i++)
		{

		}
	}

	public void CreateStair()
	{

	}


}
