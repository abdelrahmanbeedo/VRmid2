using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SocketPuzzle : MonoBehaviour
{
    private XRSocketInteractor socket;
    private bool solved = false;

    private void Awake() => socket = GetComponent<XRSocketInteractor>();

    private void OnEnable() =>
        socket.selectEntered.AddListener(OnItemPlaced);

    private void OnDisable() =>
        socket.selectEntered.RemoveListener(OnItemPlaced);

    private void OnItemPlaced(SelectEnterEventArgs args)
    {
        if (solved) return;
        solved = true;
        PuzzleManager.Instance.PuzzleSolved();
    }
}