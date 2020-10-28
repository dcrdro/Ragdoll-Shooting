using System.Collections;
using UnityEngine;

public class TimedExplosion : MonoBehaviour
{
    [SerializeField] private ExplosionCollidable explosionCollidable;
    [SerializeField] private float explosionDelay;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(explosionDelay);
        explosionCollidable.OnCollide(null); // rework
    }
}
