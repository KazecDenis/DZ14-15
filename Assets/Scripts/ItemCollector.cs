using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Transform _itemTarget;
    [SerializeField] private Vector3 _offset;
    private List<Item> _items;
    private int _maxItem = 1;

    public bool IsPicUp()
    {
        if (_items.Count == 0)
            return false;

        return true;
    }
    
    private void Awake()
    {
        _items = new List<Item>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (_items.Count >= _maxItem)
        {
            Debug.Log("У вас максимально количество предметов");
            return;
        }

        Item item = other.GetComponent<Item>();

        if (item != null)
        {
            AddItem(item);
        }
    }
    public void AddItem(Item item)
    {
        _items.Add(item);
        item.PicUpItem(_itemTarget, _offset);
        Debug.Log($"предмет {item.NameItem} подобран! что бы воспользоваться предметом нажмите F");
    }
    
    public Item GetCurrentItem()
    {
        if (_items.Count == 0)
            return null;
        
        return _items[0];
    }

    public void RemoveItem(Item item)
    {
        if (_items.Contains(item))
            _items.Remove(item);
    }
}
                
       

