using Assets.Scripts;
using Assets.Scripts.Player.Models;
using Assets.Scriptss.Models.Particles.ParticlesEnums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Key : MonoBehaviour
{
    public GameObject DoorX;
    private ParticlesController particlesController;

    private void Awake()
    {
        particlesController = Utils.GetParticlesController();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TagEnum.Player)
        {
            particlesController.PlayParticle(ParticlesEnum.KeyDestroy.ToStringFast());
            particlesController.RemoveParticle(ParticlesEnum.KeyDestroy.ToStringFast());
            Destroy(this.gameObject);
            DoorX.SetActive(true);
        }
    }

}
