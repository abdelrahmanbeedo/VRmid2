using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonDoor : MonoBehaviour
{
    public GameObject door;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable;

    void Start()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OpenDoor);
    }

    void OpenDoor(SelectEnterEventArgs args)
    {
        Debug.Log("Pressed");
        door.transform.Translate(0, 0, 2); // moves forward
    }
}