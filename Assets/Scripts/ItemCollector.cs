using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Transform _itemTarget;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Character _characterTarget;
    [SerializeField] private ParticleSystem _takeItemEffect;
    private const string _nameKeyHeart = "Health";
    private const string _nameKeySpeed = "SpeedBoost";
    private const string _nameKeyShoot = "Shoot";
    private List<Item> _items;
    private int _maxItem = 1;

    public bool HasNameItem(string name)
    {
        foreach (var item in _items)
        {
            if (item.NameItem == name)
            {
                return true;
            }
        }
        return false;
    }
    private void Awake()
    {
        _items = new List<Item>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        Item item = other.gameObject.GetComponent<Item>();

        if(item != null)
        {
            if (_items.Count < _maxItem)
            {
                switch (item.NameItem)
                {
                    case _nameKeyHeart:
                        AddItem(item);
                        break;
                    case _nameKeySpeed:
                        AddItem(item);
                        break;
                    case _nameKeyShoot:
                        AddItem(item);
                        break;
                    default:
                        Debug.LogError("что то не то)");
                        break;
                }
            }
            else
            {
                Debug.Log($"у вас максимально количество предметов!");
            }
        }
    }
    public void AddItem(Item item)
    {
        _items.Add(item);
        Debug.Log($"предмет {item.NameItem} подобран! что бы воспользоваться предметом нажмите F");
        _takeItemEffect.transform.position = item.transform.position;
        _takeItemEffect.Play();
        item.transform.SetParent(_itemTarget);
        item.SetOffset(_offset);
    }
    public void UseItem(string itemName)
    {
        for (int i = _items.Count - 1; i >= 0; i--)
        {
            if(_items[i].NameItem == itemName)
            {
                Debug.Log($"Вы использовали предмет {_items[i].NameItem}");
                _items[i].transform.SetParent(null);
                Destroy(_items[i].gameObject);
                _items.RemoveAt(i);
                break;
            }
        }
    }
}
                
       

