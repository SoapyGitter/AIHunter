using Assets.Scripts.Models.Challenges;
using Assets.Scripts.Models.Game;
using Assets.Scripts.Player.Models;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class MinigamePlayerHandler : MonoBehaviour
{
    public MinigamePlayer player;
    private GameController gameController;
    private void Awake()
    {
        player.RigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        player.SpriteRenderer = GetComponent<SpriteRenderer>();
        player.RigidBody.gravityScale = 0f;
        player.RigidBody.mass = 0.1f;

        gameController = GameObject.FindGameObjectWithTag(TagEnum.GameController).GetComponent<GameController>();

    }
    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        float spriteWidth = player.SpriteRenderer.sprite.bounds.size.x * transform.lossyScale.x;
        float spriteHeight = player.SpriteRenderer.sprite.bounds.size.y * transform.lossyScale.y;

        Vector2 leftEdge = new Vector2(transform.position.x - (spriteWidth / 2), transform.position.y);
        Vector2 rightEdge = new Vector2(transform.position.x + (spriteWidth / 2), transform.position.y);

        Vector2 upperEdge = new Vector2(transform.position.x, transform.position.y + (spriteHeight / 2));
        Vector2 downEdge = new Vector2(transform.position.x, transform.position.y - (spriteHeight / 2));

        var hitsLeft = Physics2D.RaycastAll(leftEdge, input, player.Range);
        var hitsRight = Physics2D.RaycastAll(rightEdge, input, player.Range);
        var hitsUp = Physics2D.RaycastAll(upperEdge, input, player.Range);
        var hitsDown = Physics2D.RaycastAll(downEdge, input, player.Range);


        player.Collides = hitsUp.Any(c => c.collider.tag == TagEnum.MinigameEnvironment) ||
                          hitsRight.Any(c => c.collider.tag == TagEnum.MinigameEnvironment) ||
                          hitsLeft.Any(c => c.collider.tag == TagEnum.MinigameEnvironment) ||
                          hitsDown.Any(c => c.collider.tag == TagEnum.MinigameEnvironment);
        var foundOrb = hitsUp.Any(c => c.collider.tag == TagEnum.ExitOrb) ||
                          hitsRight.Any(c => c.collider.tag == TagEnum.ExitOrb) ||
                          hitsLeft.Any(c => c.collider.tag == TagEnum.ExitOrb) ||
                          hitsDown.Any(c => c.collider.tag == TagEnum.ExitOrb);

        if (foundOrb)
        {
            var handler = gameObject.GetComponentInParent(typeof(MinigameHandler)).GetComponent<MinigameHandler>();
            gameController.FoundLight();
            handler.CloseGame();
        }


        if (!player.Collides)
            transform.position += new Vector3(input.x, input.y, 0) * player.Speed * Time.unscaledDeltaTime;
    }
}
