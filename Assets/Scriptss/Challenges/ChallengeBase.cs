using Assets.Scripts.Player.Models;
using Assets.Scripts.Player.Models.Challenges;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ChallengeBase : MonoBehaviour
{
    public Challenge challenge = new();
    private TimeController timeController;
    private GameController gameController;

    private void Awake()
    {
        challenge.Collider = this.gameObject.GetComponent<CircleCollider2D>();
        challenge.Collider.isTrigger = true;
        timeController = GameObject.FindGameObjectWithTag(TagEnum.GameController).GetComponent<TimeController>();
        gameController = GameObject.FindGameObjectWithTag(TagEnum.GameController).GetComponent<GameController>();
        HandleClose();
    }

    private void OnLightChange()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == TagEnum.Player)
        {
            collision.GetComponent<ChallengesHandler>().HandleChallenge(challenge);
            //Before run animation.
            timeController.SlowTime();
        }
    }

    private void HandleClose()
    {
        switch (challenge.Type)
        {
            case ChallengeTypeEnum.Light:
                gameController.OnLightChange += OnLightChange;
                break;
            default:
                break;
        }
    }
}
