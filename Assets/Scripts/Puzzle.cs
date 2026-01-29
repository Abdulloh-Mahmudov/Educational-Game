using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private string _scoreType;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private List<int> _spriteID;
    [SerializeField] private List<Vector3> _startPos;
    [SerializeField] private List<Vector3> _originalPos;
    [SerializeField] private GameObject _gridSlot;
    [SerializeField] private GameObject _gridPuzzlePiece;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _temproraryCover;
    [SerializeField] private Text _timerText;
    [SerializeField] private Text _scoreText;
    private float _timerTime;
    [SerializeField] private float _timerTimeOrigin;
    [SerializeField] private int _correctTiles;
    [SerializeField] private int _scoreNumber;
    [SerializeField] private Button _next;

    private void Awake()
    {
        for (int i = 0; i < _gridPuzzlePiece.transform.childCount; i++)
        {
            _startPos.Add(_gridPuzzlePiece.transform.GetChild(i).transform.position);
        }
        _originalPos = new List<Vector3>(_startPos);
    }

    private void OnEnable()
    {
        _timerTime = _timerTimeOrigin;
        NewGame();
    }

    private void Update()
    {
        if (_correctTiles == 16)
        {
            _next.interactable = true;
        }
        if (_timerTime > 0)
        {
            _timerTime -= Time.deltaTime;
        }
        else
        {
            GameOver();
        }
        _timerText.text = ((int)_timerTime).ToString();
    }

    public void GeneratePuzzle()
    {
        _spriteID.Clear();
        for (int i = 0; i < _gridSlot.transform.childCount; i++)
        {
            Drop slot = _gridSlot.transform.GetChild(i).GetComponent<Drop>();
            slot.SetID(i);
        }

        for(int i = 0; i < _sprites.Count; i++)
        {
            _spriteID.Add(i);
        }

        for (int i = 0; i < _gridPuzzlePiece.transform.childCount; i++)
        {
            PuzzlePiece piece = _gridPuzzlePiece.transform.GetChild(i).GetComponent<PuzzlePiece>();
            piece.NewGame();
            piece.SetID(i);
            piece.SetImage(_sprites[i]);
        }

        ShufflePieces();
        _next.interactable = false;
    }

    public void ShufflePieces()
    {
        for (int i = 0; i < _gridPuzzlePiece.transform.childCount; i++)
        {
            Transform piece = _gridPuzzlePiece.transform.GetChild(i).transform;
            int randomPos = Random.Range(0, _startPos.Count);
            piece.position = _startPos[randomPos];
            piece.GetComponent<PuzzlePiece>().SetToSlot(_startPos[randomPos]);
            _startPos.RemoveAt(randomPos);
        }
        _startPos = new List<Vector3>(_originalPos);
    }

    public void GameOver()
    {
        _temproraryCover.SetActive(true);
        _gameOver.SetActive(true);
        UpdateScore("PuzzleScore", _scoreNumber);
    }

    public void UpdateScore(string scoreType, int score)
    {
        string profile = PlayerPrefs.GetString("CurrentProfile");
        string key = profile + "_" + scoreType;
        if (PlayerPrefs.GetInt(key) < score)
        {
            PlayerPrefs.SetInt(key, score);
            PlayerPrefs.Save();
        }
    }

    public void NewGame()
    {
        _correctTiles = 0;
        _temproraryCover.SetActive(false);
        _gameOver.SetActive(false);
        _timerTime = _timerTimeOrigin;
        _scoreNumber = 0;
        _scoreText.text = _scoreNumber.ToString();
        GeneratePuzzle();
    }

    public void AddCorrectTile()
    {
        _correctTiles++;
        _scoreNumber += 10;
        _scoreText.text = _scoreNumber.ToString();
    }
}
