using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // ü��ȸ�� , ���� ������, ����ū��, 
    public enum ItemType
    {
        Hp,
        Coin_S,
        Coin_B,
    }

    public ItemType type;

    // �浹
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

    // ���� ����
    public void Coin(int amount)
    {
        GameManager.instance.money += amount;
    }
}
