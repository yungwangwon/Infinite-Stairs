using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainCamera : MonoBehaviour
{
    [SerializeField] GameObject playerPos;
    float dir;

	private void Awake()
	{
		dir = Mathf.Abs(playerPos.transform.position.y - transform.position.y);
	}

	void LateUpdate()
    {
		transform.position = playerPos.transform.position + new Vector3(0, dir, -10.0f);
    }
}
