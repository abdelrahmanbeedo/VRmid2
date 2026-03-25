using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class KeyholeDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private AudioClip unlockSound;

    private XRSocketInteractor socket;
    private bool unlocked = false;

    private void Awake() => socket = GetComponent<XRSocketInteractor>();

    private void OnEnable() =>
        socket.selectEntered.AddListener(OnKeyInserted);

    private void OnDisable() =>
        socket.selectEntered.RemoveListener(OnKeyInserted);

    private void OnKeyInserted(SelectEnterEventArgs args)
    {
        if (unlocked) return;
        unlocked = true;

        if (unlockSound != null)
            AudioSource.PlayClipAtPoint(unlockSound, transform.position);

        // Open the door
        if (door != null)
            StartCoroutine(OpenDoor());

        // Tell the puzzle manager
        PuzzleManager.Instance.PuzzleSolved();
    }

    private System.Collections.IEnumerator OpenDoor()
    {
        float elapsed = 0f;
        float duration = 1.5f;
        Quaternion startRot = door.transform.rotation;
        Quaternion endRot = startRot * Quaternion.Euler(0, 90, 0);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            door.transform.rotation = Quaternion.Lerp(startRot, endRot, elapsed / duration);
            yield return null;
        }

        door.transform.rotation = endRot;
    }
}