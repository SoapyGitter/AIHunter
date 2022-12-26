using Assets.Scripts.Player.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Key : MonoBehaviour
{
    public GameObject DoorX;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TagEnum.Player)
        {
            Destroy(this.gameObject);
            DoorX.SetActive(true);
        }
    }

}
