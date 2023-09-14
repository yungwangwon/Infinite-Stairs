using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour
{
    public enum InfoType
    {
        Hp,
        Score,
        Money,
    }

    public InfoType type;

	[SerializeField]
	Text myText;
	[SerializeField]
	Slider mySlider;

    private void Awake()
    {
        myText = GetComponentInChildren<Text>();
        mySlider = GetComponentInChildren<Slider>();
    }


    private void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        switch (type)
        {
            case InfoType.Hp:
                float curHp = GameManager.instance.hp;
                float maxHp = GameManager.instance.maxHp;
                mySlider.value = curHp / maxHp;
                break;
            case InfoType.Score:
                myText.text = GameManager.instance.score.ToString();
                break;
            case InfoType.Money:
                myText.text = GameManager.instance.money.ToString();
                break;

        }
    }
}
