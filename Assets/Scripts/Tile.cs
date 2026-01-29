using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject _cover;
    [SerializeField] private Button _tile;
    private MatchTile _matchTile;
    // Start is called before the first frame update
    void Start()
    {
        _matchTile = GameObject.Find("MatchTile").GetComponent<MatchTile>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCover()
    {
        _cover.SetActive(false);
        _tile.image.raycastTarget = false;
    }

    public void TileClicked()
    {
        OpenCover();
        _matchTile.TileSelected(this);
    }

    public void CloseCover()
    {
        _cover.SetActive(true);
        _tile.image.raycastTarget = true;
    }

    public void DisableTile()
    {
        _cover.SetActive(false);
        _tile.gameObject.SetActive(false);
    }

    public void EnableTile()
    {
        _cover.SetActive(true);
        _tile.gameObject.SetActive(true);
    }

    public Sprite GiveImage()
    {
     return _tile.image.sprite;
    }

    public void SetImage(Sprite image)
    {
        _tile.image.sprite = image;
    }
}
