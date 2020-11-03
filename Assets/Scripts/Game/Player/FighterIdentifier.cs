using UnityEngine;

namespace Game.Player
{
    public class FighterIdentifier : MonoBehaviour
    {
        [SerializeField] private FighterID fighterID;

        public FighterID FighterID => fighterID;
    }
}
