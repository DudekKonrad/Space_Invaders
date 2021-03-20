using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Players/Player")]
public class PlayerScriptable : ScriptableObject
{
   public string playerName;
   public int lives;
   public Sprite playerSprite;
}
