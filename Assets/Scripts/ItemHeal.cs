
using UnityEngine;

public class ItemHeal : Item
{
    [SerializeField] private int _healAmount;
    [SerializeField] private ParticleSystem _useEffect;
    public override void Use(Character character)
    {
        if (character == null)
            return;

        character.AddHeal(_healAmount);
        DestroyWithItem(_useEffect);
        MessageUseItem();
    }
   
}

