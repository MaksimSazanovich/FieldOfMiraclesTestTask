using Unity_onelove.Utilities;
using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "StaticData/GameSettings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [field: SerializeField] public int WordMinLength { get; private set; } 
        [field: SerializeField] public int NumberOfAttempts { get; private set; }

        [SerializeField] private WordsGenerator wordsGenerator;
        
        [ReadOnly]
        [SerializeField] private int availableWordMinLength;
        
        [ReadOnly]
        [SerializeField] private int availableWordMaxLength;
        private void OnValidate()
        {
            if (availableWordMinLength == 0)
            {
                Debug.Log(wordsGenerator.GetMinWordLength());
                availableWordMinLength = wordsGenerator.GetMinWordLength();
            }

            if (availableWordMaxLength == 0)
            {
                availableWordMaxLength = wordsGenerator.GetMaxWordLength();
            }

            if (WordMinLength > availableWordMaxLength || WordMinLength < availableWordMinLength)
            {
                WordMinLength = availableWordMinLength;
            }
            if(NumberOfAttempts < 1)
                NumberOfAttempts = 1;
        }
    }
}