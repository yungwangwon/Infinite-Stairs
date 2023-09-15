using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TreeEditor;
using UnityEngine;
using UnityEngineInternal;

public class Player : MonoBehaviour
{
    public bool dirLeft;

    RaycastHit2D hit;
    Animator ani;
    SpriteRenderer sprite;
    private void Awake()
    {
        dirLeft = true;
        sprite = GetComponent<SpriteRenderer>();
		ani = GetComponent<Animator>();

	}

    public void Update()
    {
        if (!GameManager.instance.isLive)
            return;

        int layerMask = 1 << LayerMask.NameToLayer("Stair");

		hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.5f, 0), Vector2.down, 0.2f, layerMask);
		Debug.DrawRay(transform.position + new Vector3(0,-0.5f,0), Vector2.down * 0.2f , Color.red);

        if (!hit)
        {
			StartCoroutine( Dead() );
		}
    }

    // 오르기
    public void Up()
    {
        if (!GameManager.instance.isLive)
            return;

        ani.SetTrigger("Move");
		transform.position += Vector3.up * 0.25f;
        transform.position += (dirLeft == true ? Vector3.left * 0.5f : Vector3.right * 0.5f);
        
        // 점수 증가
        GameManager.instance.score++;

        if(GameManager.instance.hp < GameManager.instance.maxHp - 5)
			GameManager.instance.hp += 5;
	}

	// 방향 전환
	public void Turn()
    {
        if (!GameManager.instance.isLive)
            return;

        dirLeft = !dirLeft;
        sprite.flipX = !dirLeft;
        Up();
    }

    // 죽음
    public IEnumerator Dead()
    {
        GameManager.instance.isLive = false;
		yield return 1;
		ani.SetTrigger("Die");
	}

    //public void Dead()
    //{
    //    GameManager.instance.isLive = false;
    //    ani.SetTrigger("Die");
    //}

}
