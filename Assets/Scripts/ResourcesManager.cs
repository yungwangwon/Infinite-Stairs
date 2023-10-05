using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.DefaultControls;

public class ResourcesManager : MonoBehaviour
{
    [SerializeField] Button btnPrefab;


    // # background
    [Header("# BackGround")]
    [SerializeField] BackGround backGround;
    [SerializeField] Transform backGroundBox;
    public Sprite[] backGroundSprites;

    // # Player
    [Header("# Player")]
    [SerializeField] Player player;
    [SerializeField] Transform playerBox;
	public AnimatorOverrideController[] playerAni;
    public Sprite[] playerSprites;

	// # Player
	[Header("# Pet")]
	[SerializeField] Pet pet;
	[SerializeField] Transform petBox;
	public AnimatorOverrideController[] petAni;
	public Sprite[] petSprites;

	private void Start()
    {
		Init();

	}


	public void Init()
	{
		// # background setting
		backGround = GameManager.instance.backGround;
		for (int i = 0; i < backGroundSprites.Length; i++)
		{
			Button btn = Instantiate(btnPrefab);
			btn.transform.SetParent(backGroundBox);
			btn.GetComponent<Image>().sprite = backGroundSprites[i];
			btn.GetComponent<Resource>().type = Resource.Type.Map;
			btn.GetComponent<Resource>().id = i;
			btn.GetComponent<Button>().onClick.AddListener
				(() => SelectResource(btn.GetComponent<Resource>()));

		}

		// # pet setting
		pet = GameManager.instance.pet;
		for (int i = 0; i < petSprites.Length; i++)
		{
			Button btn = Instantiate(btnPrefab);
			btn.transform.SetParent(petBox);
			btn.GetComponent<Image>().sprite = petSprites[i];
			btn.GetComponent<Image>().color = new Color(0, 0, 0);
			btn.GetComponent<Resource>().type = Resource.Type.Pet;
			btn.GetComponent<Resource>().id = i;
			btn.GetComponent<Button>().onClick.AddListener
				(() => SelectResource(btn.GetComponent<Resource>()));
			btn.interactable = false;

		}

		// # player setting
		player = GameManager.instance.player;
		for (int i = 0; i < playerSprites.Length; i++)
		{
			Button btn = Instantiate(btnPrefab);
			btn.transform.SetParent(playerBox);
			btn.GetComponent<Image>().sprite = playerSprites[i];
			btn.GetComponent<Resource>().type = Resource.Type.Character;
			btn.GetComponent<Resource>().id = i;
			btn.GetComponent<Button>().onClick.AddListener
				(() => SelectResource(btn.GetComponent<Resource>()));

		}
	}


	public void SelectResource(Resource resource)
	{

		switch (resource.type)
		{
			case Resource.Type.Map:
				backGround.GetComponent<SpriteRenderer>().sprite = backGroundSprites[resource.id];
				break;
			case Resource.Type.Pet:
				pet.GetComponent<SpriteRenderer>().sprite = petSprites[resource.id];
				pet.GetComponent<Animator>().runtimeAnimatorController = petAni[resource.id];
				break;
			case Resource.Type.Character:
				player.GetComponent<SpriteRenderer>().sprite = playerSprites[resource.id];
				player.GetComponent<Animator>().runtimeAnimatorController = playerAni[resource.id];
				break;

		}

		AudioManager.instance.SfxPlay(AudioManager.Sfx.Button);

	}

	public void SetButton(AchiveManager.Achive achive)
	{
		petBox.GetChild((int)achive).GetComponent<Image>().color = new Color(255, 255, 255);
		petBox.GetChild((int)achive).GetComponent<Button>().interactable = true;
	}


}
