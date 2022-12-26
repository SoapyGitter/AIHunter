using Assets.Scripts.Player.Models;
using Assets.Scriptss.Models.Animations.AnimationsEnum.Player;
using Assets.Scriptss.Models.Particles.ParticlesEnums;
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
        InitComponents();
    }

    private void InitComponents()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        timeController = GameObject.FindGameObjectWithTag(TagEnum.GameController).GetComponent<TimeController>();
        gameController = GameObject.FindGameObjectWithTag(TagEnum.GameController).GetComponent<GameController>();
        particlesController = GameObject.FindGameObjectWithTag(TagEnum.ParticleController).GetComponent<ParticlesController>();
        player.GFX = GameObject.FindGameObjectWithTag(TagEnum.PlayerGFX);
        animator = player.GFX.GetComponent<Animator>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        HandleInputs();

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            HandleMovementAnimations();
        else
            HandleIdleAnimations();
    }

    void Update()
    {
        player.GroundChecker.IsGrounded = Physics2D.OverlapCircle(player.GroundChecker.Point.position, player.GroundChecker.Radius, player.GroundChecker.LayerMask);

        HandleJumping();
    }

    #region Logic Handlers
    private void HandleJumping()
    {
        if (!player.GroundChecker.IsGrounded)
            HandleAir();
        else
        {
            HadleGroundedAnimations();
            HandleGround();
        }

        if (Input.GetKeyDown(KeyCode.Space) && player.GroundChecker.IsGrounded)
        {
            HandleJumpAnimations();
            rb.AddForce(Vector2.up * player.JumpForce, ForceMode2D.Impulse);
            player.GroundChecker.IsGrounded = false;
        }
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
    }

    void HandleAir()
    {
        rb.drag = player.RigidBodySettings.AirDrag;
        rb.gravityScale = player.RigidBodySettings.AirGravityScale;
    }

    void HandleGround()
    {
        rb.drag = player.RigidBodySettings.GroundDrag;
        rb.gravityScale = player.RigidBodySettings.AirGravityScale;

    }

    #endregion

    #region Animation Handlers
    void HandleMovementAnimations()
    {

        if (player.GroundChecker.IsGrounded)
            particlesController.PlayParticle(ParticlesEnum.PlayerDustMoving.ToStringFast());
        else
            particlesController.StopParticle(ParticlesEnum.PlayerDustMoving.ToStringFast());

        animator.SetBool(PlayerAnimationsEnum.IsMoving.ToStringFast(), true);
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(walk);
    }

    void HandleIdleAnimations()
    {
        particlesController.StopParticle(ParticlesEnum.PlayerDustMoving.ToStringFast());
        animator.SetBool(PlayerAnimationsEnum.IsMoving.ToStringFast(), false);
        audioSource.Stop();
    }

    void HandleJumpAnimations()
    {
        particlesController.PlayParticle(ParticlesEnum.PlayerDustJump.ToStringFast());
        audioSource.PlayOneShot(jump);
        animator.SetTrigger(PlayerAnimationsEnum.Jump.ToStringFast());
    }

    void HadleGroundedAnimations()
    {
        animator.ResetTrigger(PlayerAnimationsEnum.Jump.ToStringFast());

    }

    #endregion

    public void Death()
    {
        gameController.gameSettings.UISettings.GameOver.SetActive(true);
        player.IsDead = true;
        timeController.SlowTime();
    }
}
