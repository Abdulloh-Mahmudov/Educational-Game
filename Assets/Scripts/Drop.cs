using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    [SerializeField] private int _slotID;
    private PuzzlePiece piece;
    private Puzzle puzzle;
    private void Start()
    {
        puzzle = GameObject.Find("Puzzle").GetComponent<Puzzle>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        piece = eventData.pointerDrag.gameObject.GetComponent<PuzzlePiece>();
        if(piece._pieceID == _slotID)
        {
            piece.SetToSlot(transform.position);
            eventData.pointerDrag.transform.position = transform.position;
            puzzle.AddCorrectTile();
            piece.CorrectTile();
        }
    }

    public void SetID(int newID)
    {
        _slotID = newID;
    }
}
