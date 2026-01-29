using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathGame : MonoBehaviour
{
    [SerializeField] private int _minRange;
    [SerializeField] private int _maxRange;
    [SerializeField] private Text _number1;
    [SerializeField] private Text _number2;
    [SerializeField] private Text _debugText;
    [SerializeField] private InputField _playerInputField;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Text _timerText;
    [SerializeField] private Text _scoreText;
    private float _timerTime;
    [SerializeField] private int _scoreNumber;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _gameUI;
    [SerializeField]private float _timerTimeOrigin;
    private int _answer;
    private int _playerInput;

    // Start is called before the first frame update
    private void OnEnable()
    {
        _timerTime = _timerTimeOrigin;
        NewGame();
        GenerateQuestion();
    }



    // Update is called once per frame
    void Update()
    {
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
    public void GenerateQuestion()
    {
        _playerInputField.interactable = true;
        _nextButton.interactable = false;
        _playerInputField.text = "";
        _debugText.text = "";
        int number1 = Random.Range(_minRange, _maxRange);
        _number1.text = number1.ToString();
        int number2 = Random.Range(_minRange, _maxRange);
        _number2.text = number2.ToString();
        _answer = number1 + number2;
    }

    public void CheckAnswer()
    {
        _nextButton.interactable = true;
        _playerInputField.interactable = false;
        _playerInput = int.Parse(_playerInputField.text);
        if(_playerInput == _answer)
        {
            _debugText.text = "Correct";
            _scoreNumber += 10;
            _scoreText.text = _scoreNumber.ToString();
        }
        else
        {
            _debugText.text = "Incorrect. The right answer is " + _answer.ToString();
        }
    }

    public void GameOver()
    {
        _gameOver.SetActive(true);
        _gameUI.SetActive(false);
        UpdateScore("MathScore", _scoreNumber);

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
        _gameOver.SetActive(false);
        _gameUI.SetActive(true);
        _timerTime = _timerTimeOrigin;
        _scoreNumber = 0;
        _playerInputField.text = "";
        _nextButton.interactable = false;
        _scoreText.text = _scoreNumber.ToString();
        GenerateQuestion();
    }
}
