using UnityEngine;

public class Character : MonoBehaviour
{
   [SerializeField] private int _health;
   [SerializeField] private int _maxHealth;
   [SerializeField] private float _moveSpeed;
   [SerializeField] private float _speedBoost;
   [SerializeField] private float _speedLimit;
   [SerializeField] private Transform _targetShoot;
   private ItemCollector _itemCollector;
   public int Health {get => _health; set => _health = value;}
   public float MoveSpeed {get => _moveSpeed; private set => _moveSpeed = value;}

    private void Awake()
    {
      _itemCollector = GetComponent<ItemCollector>();
    }

    private void Update()
    {
      bool _useItemCommand = Input.GetKeyDown(KeyCode.F);

      if (_itemCollector.IsPicUp() == false)
      {
         return;
      }

      if (_useItemCommand && _itemCollector != null)
      {
         Item currentItem = _itemCollector.GetCurrentItem();
         currentItem.Use(this);
         _itemCollector.RemoveItem(currentItem);
      }
    }

    public void AddHeal(int amount)
   {
         Health += amount;
         Debug.Log($"жизни игрока - {Health}");

         if (Health >= _maxHealth)
         {
            Health = _maxHealth;
            Debug.Log("у вас максимум жизней");
         }
   }

   public void AddSpeed(float speedBoost)
   {
      MoveSpeed += speedBoost;
      
      if (MoveSpeed >= _speedLimit)
      {
         MoveSpeed = _speedLimit;
         Debug.Log("Вы уже очень быстрый, Достаточно.");
      }
   }

   public void AddShoot(GameObject prefabBullet, float speedBullet, float destroyTimeBullet)
   {
      GameObject newBullet = Instantiate(prefabBullet, _targetShoot.position, _targetShoot.rotation);
      Rigidbody rigidbody = newBullet.GetComponent<Rigidbody>();

      if (rigidbody != null)
         rigidbody.velocity = transform.forward * speedBullet;
      else
         Debug.Log("Rigidbody на bullet отсутствует");

      Destroy(newBullet.gameObject, destroyTimeBullet);
   }
}
   
