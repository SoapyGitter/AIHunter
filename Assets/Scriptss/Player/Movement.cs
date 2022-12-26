using Assets.Scripts;
using Assets.Scripts.Models.Player;
using Assets.Scripts.Player.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerSettings player = new();

    private ParticlesController particlesController;
    private TimeController timeController;
    private GameController gameController;

    public AudioClip jump, walk, gameover;
    private AudioSource audioSource;

    private Animator animator;

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        timeController = GameObject.FindGameObjectWithTag(TagEnum.GameController).GetComponent<TimeController>();
        gameController = GameObject.FindGameObjectWithTag(TagEnum.GameController).GetComponent<GameController>();
        particlesController = GameObject.FindGameObjectWithTag(TagEnum.ParticleController).GetComponent<ParticlesController>();
        player.GFX = GameObject.FindGameObjectWithTag(TagEnum.PlayerGFX);
        animator = player.GFX.GetComponent<Animator>();
        audioSource = this.gameObject.GetComponent<AudioSource>();

        InitParticles();
    }

    private void InitParticles()
    {
        player.ParticlesSettings.DustParticle = particlesController.GetParticle("Dust");

    }
    private void FixedUpdate()
    {
        HandleInputs();
    }

    void Update()
    {
        player.GroundChecker.IsGrounded = Physics2D.OverlapCircle(player.GroundChecker.Point.position, player.GroundChecker.Radius, player.GroundChecker.LayerMask);
        HandleJump();
        if (!player.GroundChecker.IsGrounded)
            HandleAir();
        else
            HandleGround();
    }

    void HandleAir()
    {
        rb.drag = player.RigidBodySettings.AirDrag;
        rb.gravityScale = player.RigidBodySettings.AirGravityScale;
    }

    void HandleGround()
    {
        animator.ResetTrigger("Jump");
        rb.drag = player.RigidBodySettings.GroundDrag;
        rb.gravityScale = player.RigidBodySettings.AirGravityScale;

    }
    void HandleMovementAnimations()
    {

        if (player.GroundChecker.IsGrounded)
            particlesController.PlayParticle("Dust", 60 * -player.MovingDirection);
        else
            particlesController.StopParticle("Dust");

        animator.SetBool("IsMoving", true);
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(walk);
    }

    void HandleIdleAnimations()
    {
        particlesController.StopParticle("Dust");
        animator.SetBool("IsMoving", false);
        audioSource.Stop();
    }

    void HandleInputs()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            player.MovingDirection = 1;
            rb.AddForce(this.transform.right * player.Speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.MovingDirection = -1;
            rb.AddForce(-this.transform.right * player.Speed);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            HandleMovementAnimations();
        else
            HandleIdleAnimations();
    }
    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (player.GroundChecker.IsGrounded)
            {
                audioSource.PlayOneShot(jump);
                animator.SetTrigger("Jump");
                rb.AddForce(Vector2.up * player.JumpForce, ForceMode2D.Impulse);
                player.GroundChecker.IsGrounded = false;
            }
        }
    }

    public void Death()
    {
        gameController.gameSettings.UISettings.GameOver.SetActive(true);
        player.IsDead = true;
        timeController.SlowTime();
    }
}
