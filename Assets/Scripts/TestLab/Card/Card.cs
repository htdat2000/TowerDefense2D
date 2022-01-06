using UnityEngine;

[CreateAssetMenu(fileName = "newCard", menuName = "Cards/Card" )]
public class Card : ScriptableObject
{
   public new string name;
   public Sprite icon;
}
