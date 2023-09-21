using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour
{
    [SerializeField] Button btnPrefab;


    // # background
    [Header("# BackGround")]
    [SerializeField] GameObject background;
    [SerializeField] Transform backgroundBox;
    public Sprite[] backgroundSprites;

    // # Player
    [Header("# Player")]
    //[SerializeField] GameObject player;
    [SerializeField] Transform playerBox;
    public Sprite[] playerSprites;

    private void Awake()
    {
        // # background setting
        for (int i =0;i<backgroundSprites.Length; i++)
        {
            Button btn = Instantiate(btnPrefab);
            btn.transform.SetParent(backgroundBox);
            btn.GetComponent<Image>().sprite = backgroundSprites[i];
        }

        // # player setting
        for (int i = 0; i < playerSprites.Length; i++)
        {
            Button btn = Instantiate(btnPrefab);
            btn.transform.SetParent(playerBox);
            btn.GetComponent<Image>().sprite = playerSprites[i];
        }
    }

    public void SetSelect()
    {

    }

    public void SetBackground(int id)
    {
        background.GetComponent<SpriteRenderer>().sprite = backgroundSprites[id];
    }



}
