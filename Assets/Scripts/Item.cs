using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _destroyTime;
    [SerializeField] private Vector3 _offset;
    private Vector3 _defaultPosition;
    private float _time;
    public string NameItem {get; set;}

    public bool IsParent
    {
        get
        {
            if (transform.parent != null)
                return true;

            return false;
        }
    }
    public virtual void Initialize(string nameItem)
    {
        _defaultPosition = transform.position;
        NameItem = nameItem;
    }

    public void SetOffset(Vector3 offset)
    {
        _offset = offset;
    }
    protected virtual void Update()
    {
        _time += Time.deltaTime;

        transform.Rotate(Vector3.up, Time.deltaTime * _rotateSpeed);

        if (IsParent)
        {
            transform.position = transform.parent.TransformPoint(_offset);
        }
        else
        {
            transform.position = _defaultPosition + Vector3.up * Mathf.Sin(_time) / 5;
        }
    }
    protected virtual void OnTransformParentChanged() 
    {
        if (IsParent == false)
            Destroy(gameObject, _destroyTime);
    }
}


