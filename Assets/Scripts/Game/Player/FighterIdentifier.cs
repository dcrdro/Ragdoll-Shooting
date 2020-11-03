using UnityEngine;

public class FighterIdentifier : MonoBehaviour
{
    [SerializeField] private FighterID fighterID;

    public FighterID FighterID => fighterID;
}
