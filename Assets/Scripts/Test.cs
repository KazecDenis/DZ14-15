
using UnityEngine;

public class Test : MonoBehaviour
{
  [SerializeField] private ParticleSystem _particle;

    private void Start()
    {
        if (_particle != null)
            _particle.Play();
    }
}
