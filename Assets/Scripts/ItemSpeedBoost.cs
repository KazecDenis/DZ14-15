using UnityEngine;

public class ItemSpeedBoost : Item
{
   [SerializeField] private float _speedBoost;
       public override void Use(Character character)
    {
        if (character == null)
            return;

        character.AddSpeed(_speedBoost);
        DestroyWithItem(character);
        MessageUseItem();
    }
}

