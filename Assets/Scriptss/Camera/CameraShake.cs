using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float x = Random.Range(-1f, 1f) * magnitude;
        float y = Random.Range(-1f, 1f) * magnitude;
        
        transform.localPosition = Vector3.Slerp(transform.localPosition, new Vector3(x, y, originalPos.z), duration);
        
        yield return null;
        
        transform.localPosition = originalPos;
    }
}
