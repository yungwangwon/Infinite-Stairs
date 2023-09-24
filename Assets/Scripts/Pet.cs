using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
	Animator ani;
	Vector3 initPos;

	private void Awake()
	{
		ani = GetComponent<Animator>();
		initPos = transform.position;
		Init();
	}

	public void Init()
	{
		ani.Rebind();
		transform.position = initPos;
	}

	public void Move()
	{
		if (!GameManager.instance.isLive)
			return;

		transform.position = GameManager.instance.player.GetSave().pos + Vector3.down * 0.45f;
		transform.GetComponent<SpriteRenderer>().flipX = GameManager.instance.player.GetSave().isLeft;
		ani.SetTrigger("Move");
	}

	public void Dead()
	{
		ani.SetTrigger("Dead");
	}

}
