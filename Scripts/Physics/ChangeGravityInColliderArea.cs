using UnityEngine;

public class ChangeGravityInColliderArea : MonoBehaviour
{
    [SerializeField] private float _gravityScaleMultiplier;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out StopGravityIfGrounded sgif))
        {
            sgif.DefaultGravity *= _gravityScaleMultiplier;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out StopGravityIfGrounded sgif))
        {
            sgif.DefaultGravity /= _gravityScaleMultiplier;
        }
    }
}