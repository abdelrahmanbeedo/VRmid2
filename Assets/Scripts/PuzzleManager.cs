using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    
    [SerializeField] private GameObject exitDoor;
    private int puzzlesSolved = 0;
    private int totalPuzzles = 3;

    private void Awake() => Instance = this;

    public void PuzzleSolved()
    {
        puzzlesSolved++;
        Debug.Log($"Puzzles solved: {puzzlesSolved}/{totalPuzzles}");
        if (puzzlesSolved >= totalPuzzles)
            OpenExit();
    }

    private void OpenExit()
    {
        if (exitDoor != null)
            exitDoor.SetActive(false); // or animate it
        Debug.Log("EXIT UNLOCKED");
    }
}