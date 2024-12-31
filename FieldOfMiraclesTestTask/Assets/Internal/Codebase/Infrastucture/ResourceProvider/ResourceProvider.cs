using UnityEngine;

namespace Unity_one_love.FieldsOfMiraclesTestTask
{
    public class ResourceProvider
    {
        public GameSettings GetGameSettings()
        {
            return Resources.Load<GameSettings>(ResourcePaths.GameSettingsPath);
        }
    }
}