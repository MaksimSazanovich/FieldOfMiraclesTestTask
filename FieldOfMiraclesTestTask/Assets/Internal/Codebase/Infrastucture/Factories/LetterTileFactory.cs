using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class LetterTileFactory
    {
        public LetterTile CreateLetterTile(char letter, Transform parent)
        {
            var config = Resources.Load<LetterTileConfig>(ResourcePaths.LetterTileConfigPath);
            var letterTile = Object.Instantiate(config.LetterTile, parent);
            
            letterTile.Init(letter);
            
            return letterTile;
        }
    }
}