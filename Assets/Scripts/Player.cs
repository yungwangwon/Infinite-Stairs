using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool playerDir;


    Animator ani;
    SpriteRenderer sprite;
    private void Awake()
    {
        playerDir = false;
        sprite = GetComponent<SpriteRenderer>();
		ani = GetComponent<Animator>();

	}

    // 오르기
    public void Up()
    {
        ani.SetTrigger("Move");
		transform.position += Vector3.up * 0.25f;
        transform.position += (playerDir == true ? Vector3.right * 0.5f : Vector3.left * 0.5f);

	}

	// 방향 전환
	public void Turn()
    {
        playerDir = !playerDir;
        sprite.flipX = playerDir;
        Up();
    }
}
