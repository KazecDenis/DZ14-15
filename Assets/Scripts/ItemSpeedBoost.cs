using UnityEngine;

public class ItemSpeedBoost : Item
{
   [SerializeField] private float _speedBoost;
   [SerializeField] private ParticleSystem _useEffect;

    public override void Use(Character character)
    {
        if (character == null)
            return;

        character.AddSpeed(_speedBoost);
        DestroyWithItem(_useEffect);
        MessageUseItem();
    }
}

