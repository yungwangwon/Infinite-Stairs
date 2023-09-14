using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
	public GameObject[] poolPrefabs;

	List<GameObject>[] pools;

	private void Awake()
	{
		pools = new List<GameObject>[poolPrefabs.Length];

		for(int i =0;i<pools.Length;i++) 
		{
			pools[i] = new List<GameObject>();

		}
		// ..Test Code
		Debug.Log(pools.Length);
	}

	public GameObject Get(int index)
	{
		GameObject select = null;

		foreach(GameObject pool in pools[index])
		{
			if (!pool.activeSelf)
			{
				// 해당 오브젝트 반환
				select = pool;
				select.SetActive(true);
				
			}
		}

		// pool이 존재하지않을경우 새로 복사후 반환
		if(!select)
		{
			select = Instantiate(poolPrefabs[index], transform);
			pools[index].Add(select);
			select.SetActive(true);
		}

		return select;
	}
}
