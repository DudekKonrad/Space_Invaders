using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Projectile", menuName = "Game/Projectile")]
    public class ProjectileScriptable : ScriptableObject
    {
        public float speed;
        public float timeToDestroy;
    }
}
