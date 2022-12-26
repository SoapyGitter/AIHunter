using Assets.Scripts.Models.Challenges;
using Assets.Scripts.Player.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MinigameHandler : MonoBehaviour
{
    private TimeController timeController;
    private void Awake()
    {
        timeController = GameObject.FindGameObjectWithTag(TagEnum.GameController).GetComponent<TimeController>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            CloseGame();


    }

    public void CloseGame()
    {
        timeController.FasterTime();
        Destroy(this.gameObject);
    }
}
