using UnityEngine;

public class LegacyInput : MonoBehaviour
{
    [SerializeField] private InputAdaptor _adaptor;

    private void Update()
    {
        _adaptor.Horizontal = Input.GetAxisRaw(InputConstants.Horizontal);

        if (Input.GetKey(KeyCode.Space))
        {
            _adaptor.JumpPower += Time.deltaTime;
        }

        _adaptor.Interact = Input.GetKeyUp(KeyCode.E);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _adaptor.Jumped = true;
        }
    }
}