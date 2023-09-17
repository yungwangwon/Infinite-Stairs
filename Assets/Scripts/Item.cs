using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // 체력회복 , 코인 작은거, 코인큰거, 
    public enum ItemType
    {
        Hp,
        Coin_S,
        Coin_B,
    }

    public ItemType type;

    // 충돌
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
        {
            switch (type) 
            {
                case ItemType.Hp:
                    GameManager.instance.hp = GameManager.instance.maxHp;
                    break;
				case ItemType.Coin_S:
                    Coin(1);
					break;
				case ItemType.Coin_B:
                    Coin(10);
					break;
			}

			this.gameObject.SetActive(false);
		}


	}

    // 코인 습득
    public void Coin(int amount)
    {
        GameManager.instance.money += amount;
    }
}
