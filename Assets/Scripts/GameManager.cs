using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UIManager uiManager;
    public PoolManager poolManager;
    public Player player;
    public Stair stair;
    public BackGround backGround;

    public bool isLive;


	[Header("# InGameVal")]
    public float hp;
    public float maxHp;
    public int score;
    public int maxScore;
    public int money;

    public int bestScore;

    private void Awake()
    {
        instance = this;
        isLive = true;
        bestScore = 0;
		money = 0;
	}

	private void Start()
    {
		Init();
	}

    public void Update()
    {
        if(!GameManager.instance.isLive)
            return;

        // score에 따른 hp감소
        hp -= score * 0.1f * Time.deltaTime;
        if (hp <= 0)
            player.Dead();
	}

	// 초기화
	public void Init()
    {
        maxHp = 100;
        hp = maxHp;
        score = 0;
        player.Init();
        backGround.Init();
        uiManager.SetMainText();
		//stair.Init();

	}
}
