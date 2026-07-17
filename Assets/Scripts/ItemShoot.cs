using UnityEngine;

public class ItemShoot : Item
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _destroyTimeBullet;
    public override void Use(Character character)
    {
        if (character == null)
            return;

        character.AddShoot(_bulletPrefab, _bulletSpeed, _destroyTimeBullet);
        DestroyWithItem(character);
        MessageUseItem();
    }
}

