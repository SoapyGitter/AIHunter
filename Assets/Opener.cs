using Assets.Scripts.Player.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opener : MonoBehaviour
{
    public GameObject Door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == TagEnum.Player)
        {
            Door.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
