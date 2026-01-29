using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private Image _image;
    [SerializeField] private Vector3 _originalPos;
    public int _pieceID;
    private bool isRightPiece;

    private void OnEnable()
    {
        _image = GetComponent<Image>();
        isRightPiece = false;
    }

    private void Update()
    {
        if(isRightPiece == true)
        {
            _image.raycastTarget = false;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _originalPos = transform.position;
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = _originalPos;
        _image.raycastTarget = true;
    }

    public void SetToSlot(Vector3 newPos)
    {
        _originalPos = newPos;
    }

    public void SetImage(Sprite sprite)
    {
        if(_image != null)
        _image.sprite = sprite;
    }

    public void SetID(int newID)
    {
        _pieceID = newID;
    }

    public void CorrectTile()
    {
        isRightPiece = true;
    }

    public void NewGame()
    {
        isRightPiece = false;
        if(_image != null)
        _image.raycastTarget = true;
    }
}
