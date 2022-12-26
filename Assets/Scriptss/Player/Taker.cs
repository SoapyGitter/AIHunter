using Assets.Scripts.Player.Models;
using System.Linq;
using UnityEngine;

public class Taker : MonoBehaviour
{

    public delegate void OnTakerChangeDelegate();
    public event OnTakerChangeDelegate OnTakerChange;

    public TakerSettings taker = new();
    public float ShakePowerDivision = 5f;
    void ResetTimer() => taker.Timer.currentTime = 0f;
    void CheckTime()
    {
        if (!(taker.CanTakeItem = taker.Timer.CheckTime()))
            taker.Timer.currentTime += Time.deltaTime;
    }
    void Update()
    {
        CheckTime();
        if (Input.GetMouseButton(1) && Physics2D.OverlapCircle(this.transform.position, taker.Radius, taker.LayerMask))
        {
            var item = Physics2D.OverlapCircleAll(this.transform.position, taker.Radius, taker.LayerMask).FirstOrDefault();
            if (!Physics2D.OverlapCircleAll(this.transform.position, taker.Radius).Any(c => c.tag != "Item" && c.isTrigger == false))
            {
                if (taker.CanTakeItem)
                {
                    taker.HasItem = true;
                    var itemTransform = item.GetComponent<Transform>();
                    itemTransform.position = Vector3.Slerp(itemTransform.position, transform.position, .5f);
                    item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
                else
                    taker.HasItem = false;


                //Charging.
                if (Input.GetMouseButton(0))
                {
                    //TODO: Fix CameraShake
                    //StartCoroutine(taker.CameraShake.Shake((taker.MaxPower + 1 - taker.Power) / ShakePowerDivision, taker.Power / ShakePowerDivision));
                    if (taker.Power < taker.MaxPower)
                        taker.Power += Time.deltaTime;
                }
                //Charge Release.
                else if (Input.GetMouseButtonUp(0))
                {
                    var dir = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;
                    item.GetComponent<Rigidbody2D>().AddForce(dir * taker.Power * taker.Multiplyer, ForceMode2D.Impulse);
                    taker.Power = 1f;
                    ResetTimer();
                }
            }
        }
        else
            taker.Power = 1f;
    }
}
