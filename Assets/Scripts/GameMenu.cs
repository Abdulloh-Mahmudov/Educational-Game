using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private string _currentProfile;
    [SerializeField] private Text _puzzleScoreText;
    [SerializeField] private Text _mathScoreText;
    [SerializeField] private Text _tileScoreText;
    // Start is called before the first frame update
    void OnEnable()
    {
        _currentProfile = PlayerPrefs.GetString("CurrentProfile");
        _puzzleScoreText.text = PlayerPrefs.GetInt(_currentProfile + "_PuzzleScore").ToString();
        _mathScoreText.text = PlayerPrefs.GetInt(_currentProfile + "_MathScore").ToString();
        _tileScoreText.text = PlayerPrefs.GetInt(_currentProfile + "_TileScore").ToString();
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
