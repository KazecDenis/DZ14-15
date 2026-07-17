using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] protected ParticleSystem _picUpEffect;
    [SerializeField] protected ParticleSystem _useEffect;
    [SerializeField] protected string _nameItem;
    private RotatorEffect _rotatorEffect;
    private float _delay = 1f;
    private float _destroyTargetOffsetY = 5f;
    public string NameItem => _nameItem;

    private void Awake()
    {
        _rotatorEffect = GetComponent<RotatorEffect>();
    }

    public void SetOffset(Vector3 offset)
    {
        _offset = offset;
    }

    public virtual void PicUpItem(Transform parent,Vector3 offset) 
    {
        transform.SetParent(parent);
        transform.localPosition = offset;
        _rotatorEffect.OffRotation();
        PicUpEffectTake();
    }
    public virtual void PicUpEffectTake()
    {
        if (_picUpEffect != null)
        {
            _picUpEffect.transform.position = transform.position;
            _picUpEffect.Play();
        }
        else
        {
            Debug.LogError("_picUpEffect null");
        }
            
    }
    public abstract void Use(Character character);

    public void DestroyWithItem(Character character)
    {   
        if (_useEffect != null)
        {
            _useEffect.transform.SetParent(null);
            Vector3 targetEffect = new Vector3(character.transform.position.x, _destroyTargetOffsetY, character.transform.position.z);
            _useEffect.transform.position = targetEffect;
            _useEffect.Play();
            Destroy(_useEffect.gameObject, _delay);
        }
        else
        {
            Debug.LogError("_useEffect null");
        }

        Destroy(gameObject);
    }

    protected void MessageUseItem()
    {
        Debug.Log($"предмет {NameItem} был использован");
    }
}
            


