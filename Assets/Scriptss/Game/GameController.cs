using Assets.Scripts;
using Assets.Scripts.Models.Game;
using Assets.Scripts.Player.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameController : MonoBehaviour
{
    public GameSettings gameSettings = new();
    
    public delegate void OnLightChangeDelegate();
    public event OnLightChangeDelegate OnLightChange;

    bool flag = true;
    GameObject videoPlayer;

    private void Awake()
    {
        gameSettings.TimeController = GameObject.FindGameObjectWithTag(TagEnum.GameController).GetComponent<TimeController>();
        gameSettings.Movement = GameObject.FindGameObjectWithTag(TagEnum.Player).GetComponent<Movement>();
        videoPlayer = GameObject.FindGameObjectWithTag(TagEnum.VideoPlayer);
        if(videoPlayer != null)
        {
            gameSettings.VideoPlayer = videoPlayer.GetComponent<VideoPlayer>();
            gameSettings.VideoPlayer.loopPointReached += VideoEnd;
            if (gameSettings.VideoPlayer.isPlaying) gameSettings.TimeController.SlowTime();
        }
    }

    private void VideoEnd(VideoPlayer vp)
    {
        Destroy(GameObject.FindGameObjectWithTag(TagEnum.VideoPlayer));
        gameSettings.TimeController.FasterTime();

    }
    private void Update()
    {
        if (flag && Input.GetKeyDown(KeyCode.Space) && videoPlayer is not null)
        {
            var videoPlayer = GameObject.FindGameObjectWithTag(TagEnum.VideoPlayer);
            if (videoPlayer != null)
            {
                flag = false;
                Destroy(videoPlayer);
            }

        }
        if (gameSettings.TimeController.IsTimeSlowed() && !gameSettings.Paused)
            return;
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePauseMenu();
    }
    private void TogglePauseMenu()
    {
        if (gameSettings.Movement.player.IsDead)
            return;

        if (gameSettings.Paused)
            Resume();
        else
            Pause();
    }

    public void RestartLevel()
    {
        gameSettings.TimeController.FasterTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void FoundLight()
    {
        gameSettings.FoundLight = true;
        OnLightChange();
        gameSettings.TimeController.FasterTime();
    }


    public void Resume()
    {
        gameSettings.Paused = false;
        gameSettings.UISettings.Pause.SetActive(false);
        gameSettings.TimeController.FasterTime();
    }
    public void Pause()
    {
        gameSettings.Paused = true;
        gameSettings.UISettings.Pause.SetActive(true);
        gameSettings.TimeController.SlowTime();
    }


}
