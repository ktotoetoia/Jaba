using UnityEngine;
using UnityEngine.UIElements;

public class TouchscreenInput : MonoBehaviour
{
    private const string MoveLeftButtonName = "MoveLeft";
    private const string MoveRightButtonName = "MoveRight";
    private const string JumpButtonName = "Jump";

    [SerializeField] private UIDocument _document;
    [SerializeField] private InputAdaptor _adaptor;
    private Button _moveLeftButton;
    private Button _moveRightButton;
    private Button _jumpButton;
    private float _jumpHoldTime;

    private void Start()
    {
        Bind();
    }

    private void Bind()
    {
        _moveLeftButton = _document.rootVisualElement.Q<Button>(MoveLeftButtonName);
        _moveRightButton = _document.rootVisualElement.Q<Button>(MoveRightButtonName);
        _jumpButton = _document.rootVisualElement.Q<Button>(JumpButtonName);

        _moveLeftButton.RegisterCallback<PointerDownEvent>(e =>
        {
            _adaptor.Horizontal = -1;
        }, TrickleDown.TrickleDown);
        _moveLeftButton.RegisterCallback<PointerUpEvent>(e =>
        {
            _adaptor.Horizontal = _adaptor.Horizontal == -1 ? 0 : 1;
        }, TrickleDown.TrickleDown);


        _moveRightButton.RegisterCallback<PointerDownEvent>(e =>
        {
            _adaptor.Horizontal = 1;
        }, TrickleDown.TrickleDown);
        _moveRightButton.RegisterCallback<PointerUpEvent>(e =>
        {
            _adaptor.Horizontal = _adaptor.Horizontal == 1 ? 0 : -1;
        }, TrickleDown.TrickleDown);

        _jumpButton.RegisterCallback<PointerDownEvent>(e =>
        {
            _jumpHoldTime = Time.time;
        }, TrickleDown.TrickleDown);

        _jumpButton.RegisterCallback<PointerUpEvent>(e =>
        {
            _adaptor.JumpPower = Time.time - _jumpHoldTime;
            _adaptor.Jumped = true;
            _jumpHoldTime = 0;
        }, TrickleDown.TrickleDown);
    }
}