using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TreeEditor;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using UnityEngineInternal;

public class Player : MonoBehaviour
{
    public bool dirLeft;

    RaycastHit2D hit;
    Animator ani;
    SpriteRenderer sprite;
    Vector3 initPos;

    private void Awake()
    {
        dirLeft = true;
        sprite = GetComponent<SpriteRenderer>();
		ani = GetComponent<Animator>();
        initPos = transform.position;

	}

    public void Update()
    {
        if (!GameManager.instance.isLive)
            return;

        int layerMask = 1 << LayerMask.NameToLayer("Stair");

        // raycast
		hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.5f, 0), Vector2.down, 0.2f, layerMask);
		Debug.DrawRay(transform.position + new Vector3(0,-0.5f,0), Vector2.down * 0.2f , Color.red);

        if (!hit)
        {
			StartCoroutine( Dead() );
		}
    }
    
    // 초기화
	public void Init()
	{
        transform.position = initPos;
        sprite.flipX = false;
        ani.Rebind();
    }

	// 오르기
	public void Up()
    {
        if (!GameManager.instance.isLive)
            return;

        ani.SetTrigger("Move");
		transform.position += Vector3.up * 0.25f;
        transform.position += (dirLeft == true ? Vector3.left * 0.5f : Vector3.right * 0.5f);
        GameManager.instance.backGround.Up();

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
		GameManager.instance.score--;
		GameManager.instance.isLive = false;

        // 최고기록 갱신
        if (GameManager.instance.score > GameManager.instance.bestScore)
            GameManager.instance.bestScore = GameManager.instance.score;

		GameManager.instance.uiManager.SetScoreText();

		yield return 1;
		ani.SetTrigger("Die");
        yield return new WaitForSeconds(2.0f);
        GameManager.instance.uiManager.Dead();
	}

}
