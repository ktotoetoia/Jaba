using UnityEngine;
using System.Collections;

public class ThrowOnTriggerEnter : MonoBehaviour
{
    public event System.Action Throwed;
    public event System.Action Entered;

    [SerializeField] private bool _knockBack;
    [SerializeField] private Vector2 _force;
    [SerializeField] private float _waitTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IGroundInfo groundInfo) &&
           collision.TryGetComponent(out Rigidbody2D rigidbody))
        {
            StartCoroutine(ThrowCoroutine(rigidbody, groundInfo));
        }

    }

    private IEnumerator ThrowCoroutine(Rigidbody2D rigidbody, IGroundInfo groundInfo)
    {
        Entered?.Invoke();

        yield return new WaitForSeconds(_waitTime);
        Throw(rigidbody,groundInfo);
     
        Throwed?.Invoke();
    }

    private void Throw(Rigidbody2D rigidbody, IGroundInfo groundInfo)
    {
        Vector2 velocity = _force;

        if (_knockBack)
        {
            velocity.x *= rigidbody.position.x > transform.position.x ? 1 : -1;
        }

        rigidbody.velocity = velocity;
        groundInfo.IgnoreGround(2);
    }
}
