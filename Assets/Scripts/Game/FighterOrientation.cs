using UnityEngine;

public class FighterOrientation : MonoBehaviour
{
    [SerializeField] private FighterIdentifier fighterIdentifier;
    [SerializeField] private FighterConfigMapper fighterConfigMapper;

    private void Awake()
    {
        Vector3 rotation = fighterConfigMapper[fighterIdentifier.FighterID].Rotation;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
