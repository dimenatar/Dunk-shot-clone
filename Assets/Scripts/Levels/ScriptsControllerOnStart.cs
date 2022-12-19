using UnityEngine;

public class ScriptsControllerOnStart : MonoBehaviour
{
    [SerializeField] private DragController _dragController;
    [SerializeField] private InputManager _inputManager;

    private void Awake()
    {
        InvisibleBackgroundPointerDown.OnLevelStart += Enable;
    }

    private void OnDestroy()
    {
        InvisibleBackgroundPointerDown.OnLevelStart -= Enable;
    }

    private void Enable()
    {
        _dragController.enabled = true;
        _inputManager.enabled = true;
    }
}
