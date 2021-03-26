using UnityEngine;

namespace ScriptableObjects
{
   [CreateAssetMenu(fileName = "New Player", menuName = "Game/Player")]
   public class PlayerScriptable : ScriptableObject
   {
      public int lives;
      public float xRange;
      public int score;
      public float speed;
   }
}
