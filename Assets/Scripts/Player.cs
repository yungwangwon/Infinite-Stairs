using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool playerDir;

    SpriteRenderer sprite;
    private void Awake()
    {
        playerDir = false;
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Up()
    {
        transform.position += Vector3.up * 0.25f;
        transform.position += (playerDir == true ? Vector3.right * 0.5f : Vector3.left * 0.5f);
    }

    public void Turn()
    {
        playerDir = !playerDir;
        sprite.flipX = playerDir;
        Up();
    }
}
