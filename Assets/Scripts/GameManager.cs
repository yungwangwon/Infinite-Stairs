using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UIManager uiManager;
    public PoolManager poolManager;
    public Player player;
    public Stair stair;
    public BackGround backGround;
    public ResourcesManager resourcesManager;
    public AchiveManager achiveManager;
    public Pet pet;

    public bool isLive;


	[Header("# InGameVal")]
    public float hp;
    public float maxHp;
    public int score;
    public int maxScore;
    public int money;

    public int bestScore;
    public int[] achive;


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

        // score�� ���� hp����
        hp -= score * 0.1f * Time.deltaTime;
        if (hp <= 0)
            player.Dead();
	}

	// �ʱ�ȭ
	public void Init()
    {

		maxHp = 100;
        hp = maxHp;
        score = 0;
        player.Init();
        pet.Init();

		backGround.Init();
		

		uiManager.SetMainText();
		//stair.Init();

	}
}
