using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] protected bool _oneTime = true;
    [SerializeField] protected bool _destroyAfterInteraction = true;
    private Color _color = new Color(0.9622642f, 0.6090001f, 0.4030616f);
    private SpriteRenderer _spriteRenderer;
    protected bool _highlight = true;

    protected virtual void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        Register();
    }

    private void Update()
    {
        if(_spriteRenderer == null)
        {
            return;
        }

        if (_highlight)
        {
            _spriteRenderer.color = _color;            
        }
        else
        {
            _spriteRenderer.color = Color.white;
        }

        _highlight = false;
    }

    private void Register()
    {
        InteractableLibrary.Instance.Add(this);
    }

    public virtual void Interact(GameObject user)
    {
        if (_oneTime)
        {
            InteractableLibrary.Instance.Remove(this);
        }
        if (_destroyAfterInteraction)
        {
            Destroy(gameObject);
        }
    }

    public virtual bool IsAvailable()
    {
        return true;
    }

    public virtual void OnCanInteract()
    {
        _highlight = true;
    }
}