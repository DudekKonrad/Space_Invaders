using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Gameplay", menuName = "Game/Gameplay")]
    public class GameplayScriptable : ScriptableObject
    {
        public int countDownTime;
    }
}
