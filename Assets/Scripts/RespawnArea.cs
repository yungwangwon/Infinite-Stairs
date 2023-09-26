using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnArea : MonoBehaviour
{
	private void Update()
	{
		if (!GameManager.instance.isLive)
			return;

		transform.position = GameManager.instance.player.transform.position;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Stair"))
		{
			GameManager.instance.stair.RespawnStair(collision.gameObject);
		}
	}
}
