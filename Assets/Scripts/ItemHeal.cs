
using UnityEngine;

public class ItemHeal : Item
{
    [SerializeField] private int _healAmount;
    public override void Use(Character character)
    {
        if (character == null)
            return;

        character.AddHeal(_healAmount);
        DestroyWithItem(character);
        MessageUseItem();
    }
   
}

