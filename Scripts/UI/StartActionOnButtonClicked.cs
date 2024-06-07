using UnityEngine;
using UnityEngine.UIElements;
using AYellowpaper;

public class StartActionOnButtonClicked : MonoBehaviour
{
    [SerializeField] private InterfaceReference<ICanBeActivated> _toActivate;
    [SerializeField] private string _buttonName;
    [SerializeField] private bool _oneTime;
    private Button button;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        button = root.Q<Button>(_buttonName);
        button.clicked += ChangeScene;
    }

    private void ChangeScene()
    {
        button.SetEnabled(!_oneTime);

        _toActivate.Value.Activate(null);
    }
}