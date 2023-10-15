using UnityEngine;

public class EscapeToMainMenu : MonoBehaviour
{
    [SerializeField] private SceneTransitionCommand _command;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _command.ApplyTransition();
            gameObject.SetActive(false);
        }
    }
}
