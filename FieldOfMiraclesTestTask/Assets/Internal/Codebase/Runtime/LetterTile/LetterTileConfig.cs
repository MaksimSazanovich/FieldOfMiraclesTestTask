using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    [CreateAssetMenu(fileName = "LetterTileConfig", menuName = "StaticData/LetterTileConfig", order = 1)]
    public class LetterTileConfig : ScriptableObject
    {
        [field: SerializeField] public LetterTile LetterTile { get; private set; }
    }
}