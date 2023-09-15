using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PoolManager poolManager;
    public Player player;
    public Stair stair;

    public bool isLive;

    [Header("# InGameVal")]
    public float hp;
    public float maxHp;
    public int score;
    public int maxScore;
    public int money;

    private void Awake()
    {
        instance = this;
        isLive = true;
    }

    private void Start()
    {
        Init();
    }

    public void Update()
    {
        if(!GameManager.instance.isLive)
            return;

        // score�� ���� hp����
        hp -= score * 0.1f * Time.deltaTime;
        if (hp <= 0)
            player.Dead();


	}

	// �ʱ�ȭ
	private void Init()
    {
        maxHp = 100;
        hp = maxHp;
        score = 0;
    }
}
