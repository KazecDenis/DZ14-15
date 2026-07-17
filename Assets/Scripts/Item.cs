using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] protected ParticleSystem _picUpEffect;

    public string NameItem {get; protected set;}
    private RotatorEffect _rotatorEffect;


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
            _rotatorEffect.enabled = false;
            ApplyEffectTake(_picUpEffect);
    }
    protected virtual void ApplyEffectTake(ParticleSystem particleSystem)
    {
        if (particleSystem != null)
        {
            particleSystem.transform.position = transform.position;
            particleSystem.Play();
        }
        else
        {
            Debug.LogError("pupupu");
        }
            
    }
    public abstract void Use(Character character);

    protected void DestroyWithItem(ParticleSystem particleSystem)
    {   
        if (particleSystem != null)
        {
            particleSystem.transform.position = transform.position;
            particleSystem.Play();
        }
        else
        {
            Debug.LogError("pupupu");
        }
            
        Destroy(gameObject);
    }

    protected void MessageUseItem()
    {
        Debug.Log($"предмет {NameItem} был использован");
    }
}


