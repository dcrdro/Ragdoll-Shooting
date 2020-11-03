using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonusesSpawner : MonoBehaviour
{
    [SerializeField] private MonoBehaviour factory; // as IFactory<int, GameObject>
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval;

    // for removing dependency on a specific factory
    private IFactory<int, GameObject> Factory => (IFactory<int, GameObject>) factory;

    private IEnumerator Start()
    {
        WaitForSeconds spawnWait = new WaitForSeconds(spawnInterval);
        while (true)
        {
            yield return spawnWait;
            Spawn();
        }
    }

    private void Spawn()
    {
        int randomIndex = Random.Range(0, Factory.Size);
        GameObject product = Factory.Produce(randomIndex);

        product.transform.parent = spawnPoint;
        product.transform.localPosition = Vector3.zero;
    }

    private void OnDisable() => StopAllCoroutines();
}
