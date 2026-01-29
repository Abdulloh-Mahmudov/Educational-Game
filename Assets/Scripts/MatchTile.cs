using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchTile : MonoBehaviour
{
    [SerializeField] private List<Sprite> _tileImages;
    [SerializeField] private List<Sprite> _tileImagesExample;
    [SerializeField] private Text _timerText;
    private float _timerTime;
    [SerializeField] private float _timerTimeOrigin;
    [SerializeField] private Text _scoreText;
    [SerializeField] private int _scoreNumber;
    [SerializeField] private int _selectedTiles;
    [SerializeField] private GameObject _gameEnd;
    private Tile _firstTile;
    private Sprite  _firstImage;
    private Tile _secondTile;
    private Sprite _secondImage;
    private CanvasGroup _grid;
    [SerializeField] private int _pairs;
    [SerializeField] private Button _next;
    [SerializeField] private GameObject _temproraryCover;



    // Start is called before the first frame update
    void OnEnable()
    {
        _grid = GameObject.Find("Grid").GetComponent<CanvasGroup>();
        _next.interactable = false;
        GenerateLevel();
        _timerTime = _timerTimeOrigin;
    }

    // Update is called once per frame
    void Update()
    {
        if(_pairs == 6)
        {
            _next.interactable = true;
            _pairs = 0;
        }
        if(_timerTime > 0)
        {
            _timerTime -= Time.deltaTime;
        }
        else
        {
            GameOver();
        }
        _timerText.text = ((int)_timerTime).ToString();
    }

    public void TileSelected(Tile tile)
    {
        if (_selectedTiles == 0)
        {
            _selectedTiles++;
            _firstTile = tile;
            _firstImage = _firstTile.GiveImage();
        }
        else if(_selectedTiles == 1)
        {
            _selectedTiles++;
            _secondTile = tile;
            _secondImage = _secondTile.GiveImage();
        }
        if (_selectedTiles >= 2)
        {
            _selectedTiles = 0;
            StartCoroutine(ClosingTiles());
            
        }

    }

    public void MatchTiles()
    {
        if (_firstTile != null && _secondTile != null)
        {
            _firstTile.DisableTile();
            _secondTile.DisableTile();
            AddScore();
        }  
    }

    public void AddScore()
    {
        _pairs++;
        _scoreNumber += 10;
        _scoreText.text = _scoreNumber.ToString();
    }


    public void GenerateLevel()
    {
        _next.interactable = false;
        for (int i = 0; i < _grid.transform.childCount; i++)
        {
            Tile childTile = _grid.transform.GetChild(i).GetComponent<Tile>();
            childTile.EnableTile();
            childTile.CloseCover();
            if (_tileImages.Count <= 0)
            {
                _tileImages = new List<Sprite>(_tileImagesExample);
            }
            Sprite randomSprite = _tileImages[Random.Range(0, _tileImages.Count)];
            childTile.SetImage(randomSprite);
            _tileImages.Remove(randomSprite);
        }
        StartCoroutine(ShowTiles());
    }

    public void GameOver()
    {
        _temproraryCover.SetActive(true);
        _gameEnd.SetActive(true);
        UpdateScore("TileScore", _scoreNumber);
    }

    public void UpdateScore(string scoreType, int score)
    {
        string profile = PlayerPrefs.GetString("CurrentProfile");
        string key = profile + "_" + scoreType;
        if(PlayerPrefs.GetInt(key) < score)
        {
            PlayerPrefs.SetInt(key, score);
            PlayerPrefs.Save();
        }
    }

    public void NewGame()
    {
        _temproraryCover.SetActive(false);
        _gameEnd.SetActive(false);
        _timerTime = _timerTimeOrigin;
        _scoreNumber = 0;
        _scoreText.text = _scoreNumber.ToString();
        GenerateLevel();
    }

    IEnumerator ClosingTiles()
    {
        _grid.interactable = false;
        yield return new WaitForSeconds(1f);
        _grid.interactable = true;
        if (_firstImage == _secondImage)
        {
            MatchTiles();
        }
        else
        {
            _firstTile.CloseCover();
            _secondTile.CloseCover();
        }
        _firstTile = null;
        _firstImage = null;
        _secondTile = null;
        _secondImage = null;
    }
    
    IEnumerator ShowTiles()
    {
        _temproraryCover.SetActive(true);
        _grid.interactable = true;
        for (int i = 0; i < _grid.transform.childCount; i++)
        {
            Tile childTile = _grid.transform.GetChild(i).GetComponent<Tile>();
            childTile.OpenCover();
        }
        yield return new WaitForSeconds(1f);
        _temproraryCover.SetActive(false);
        for (int i = 0; i < _grid.transform.childCount; i++)
        {
            Tile childTile = _grid.transform.GetChild(i).GetComponent<Tile>();
            childTile.CloseCover();
        }
    }
}
