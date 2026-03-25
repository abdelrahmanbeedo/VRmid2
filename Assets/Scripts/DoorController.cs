using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip openSFX;

    public void OpenDoor()
    {
        if (openSFX != null)
            StartCoroutine(PlayThenDisable());
        else
            gameObject.SetActive(false);
    }

    private IEnumerator PlayThenDisable()
    {
        audioSource.PlayOneShot(openSFX);
        yield return new WaitForSeconds(openSFX.length);
        gameObject.SetActive(false);
    }
}