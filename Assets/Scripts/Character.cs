using UnityEngine;

public class Character : MonoBehaviour
{
   [SerializeField] private int _health;
   [SerializeField] private float _moveSpeed;
   [SerializeField] private float _speedBoost;
   [SerializeField] private float _speedLimit;
   [SerializeField] private GameObject _prefabBullet;
   [SerializeField] private Transform _targetShoot;
   [SerializeField] private float _speedBullet;
   [SerializeField] private float _destroyTimeBullet;
   [SerializeField] private int _healBoost;
   [SerializeField] private ParticleSystem _applicationItemEffect;
   private ItemCollector _itemCollector;
   private const string _nameKeyHeart = "Health";
   private const string _nameKeySpeed = "SpeedBoost";
   private const string _nameKeyShoot = "Shoot";
   public int Health {get => _health; private set => _health = value;}
   public float MoveSpeed {get => _moveSpeed; private set => _moveSpeed = value;}

    private void Awake()
    {
      _itemCollector = GetComponent<ItemCollector>();
    }

    private void Update()
    {
      bool _useItemCommand = Input.GetKeyDown(KeyCode.F);

      if (_useItemCommand && _itemCollector.HasNameItem(_nameKeyShoot))
      {
         applicationShoot();
      }
      else if (_useItemCommand && _itemCollector.HasNameItem(_nameKeyHeart))
      {
         applicationHeal(_healBoost);
      }
      else if (_useItemCommand && _itemCollector.HasNameItem(_nameKeySpeed))
      {
         applicationAddSpeed(_speedBoost);
      }
    }
    public void applicationHeal(int health)
   {
      if (health < 0)
         Debug.Log("хил меньше 0");
      
         Health += health;
         PlayApplicationEffect(_applicationItemEffect);
         _itemCollector.UseItem(_nameKeyHeart);
         Debug.Log($"жизни игрока - {Health}");
   }

   public void applicationAddSpeed(float speedBoost)
   {
      MoveSpeed += speedBoost;
      _itemCollector.UseItem(_nameKeySpeed);
      PlayApplicationEffect(_applicationItemEffect);
      if (MoveSpeed >= _speedLimit)
      {
         MoveSpeed = _speedLimit;
         Debug.Log("Вы уже очень быстрый, Достаточно.");
      }
   }

   public void applicationShoot()
   {
      GameObject newBullet = Instantiate(_prefabBullet, _targetShoot.position, _targetShoot.rotation);
      Rigidbody rigidbody = newBullet.GetComponent<Rigidbody>();

      if (rigidbody != null)
         rigidbody.velocity = transform.forward * _speedBullet;
      else
         Debug.Log("Rigidbody на bullet отсутствует");

      PlayApplicationEffect(_applicationItemEffect);
      _itemCollector.UseItem(_nameKeyShoot);
      Destroy(newBullet.gameObject, _destroyTimeBullet);
   }
   private void PlayApplicationEffect(ParticleSystem effect)
   {
      effect.Play();
   }
}
