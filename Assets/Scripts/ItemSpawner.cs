using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnTargets;
    [SerializeField] private List<Item> _itemPrefabs;
    [SerializeField] private float _coolDown;
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _coolDown || _coolDown == 0)
        {
            List<SpawnPoint> emptyPoints = GetEmptyPoints();

            if (emptyPoints.Count == 0)
            {
                _timer = 0;
                return;
            }

            SpawnPoint spawnPoint = _spawnTargets[Random.Range(0, emptyPoints.Count)];
            Item item = Instantiate(_itemPrefabs[Random.Range(0, _itemPrefabs.Count)], spawnPoint.Position, Quaternion.identity);

            if (item != null)
            {
                spawnPoint.Occupy(item);
                _timer = 0;
            }
            else
            {
                Debug.LogError($"не удалось создать объект {item.NameItem}");
            }    
        }
    }
    private List<SpawnPoint> GetEmptyPoints()
    {
        List<SpawnPoint> emptyPoints = new List<SpawnPoint>();

        foreach (SpawnPoint spawnPoints in _spawnTargets)
        {
            if (spawnPoints.IsEmpty)
                emptyPoints.Add(spawnPoints);
        }
        
        return emptyPoints;
    }
}
        

            

     

