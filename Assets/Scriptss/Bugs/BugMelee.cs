using Assets.Scripts.Player.Models;
using UnityEngine;

public class BugMelee : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == TagEnum.Player)
            collision.GetComponent<Movement>().Death();
    }
}
