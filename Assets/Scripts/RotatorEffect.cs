using UnityEngine;

public class RotatorEffect : MonoBehaviour
{
   [SerializeField] private float _rotateSpeed;
    private void Update()
    {
        transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }  
    public void OffRotation()
    {
        enabled = false;
    }
}


