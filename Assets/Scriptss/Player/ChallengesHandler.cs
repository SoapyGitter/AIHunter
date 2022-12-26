using Assets.Scripts.Player.Models;
using Assets.Scripts.Player.Models.Challenges;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengesHandler : MonoBehaviour
{
    private Transform camera, minigamePosition;

    private void Awake()
    {
        camera = GameObject.FindGameObjectWithTag(TagEnum.Camera).GetComponent<Transform>();
        minigamePosition = GameObject.FindGameObjectWithTag(TagEnum.MinigamePosition).GetComponent<Transform>();
    }
    public void HandleChallenge(Challenge challenge)
    {
        var minigame = Instantiate(challenge.Minigame, minigamePosition);
        minigame.transform.parent = camera;
    }
}
