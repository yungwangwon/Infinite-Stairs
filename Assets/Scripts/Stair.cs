using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Stair : MonoBehaviour
{

	Vector3 startPos;
	public GameObject stairPrefab;
	Vector3 initPos;

	float stairX, stairY;
	private void Awake()
	{
		stairX = 0.5f;
		stairY = 0.25f;
		initPos = transform.position;
		//Init();

	}

	public void Init()
	{
		if(startPos != initPos)
		{
			for(int i =1;i<  transform.childCount;i++)
			{
				Destroy(transform.GetChild(i).gameObject);
			}
		}

		startPos = initPos;
		
		// .. 초기 계단생성
		for (int i = 0; i < 50; i++)
		{
			// Stair Setting
			GameObject stair = Instantiate(stairPrefab, transform);
			stair.transform.position = startPos;
			stair.transform.position += (Random.Range(0, 2) == 0) ? Vector3.left * stairX : Vector3.right * stairX;
			stair.transform.position += Vector3.up * stairY;
			startPos = stair.transform.position;

			// Item Setting
			int rand = Random.Range(0, 10);
			if (rand >= 0 && rand < 7)	// 60%
			{
				// 꽝
			}
			else if (rand >= 6 && rand < 8) // 20% Coin_S
			{
				GameObject item = GameManager.instance.poolManager.Get(0);
				item.transform.position = stair.transform.position + (Vector3.up * 0.4f);
			}
			else if(rand == 8) // 10% Coin_B
			{
				GameObject item = GameManager.instance.poolManager.Get(1);
				item.transform.position = stair.transform.position + (Vector3.up * 0.4f);
			}
			else if(rand == 9) // 10% Hp_Drink
			{
				GameObject item = GameManager.instance.poolManager.Get(2);
				item.transform.position = stair.transform.position + (Vector3.up * 0.4f);
			}


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



