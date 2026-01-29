using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileGame : MonoBehaviour
{
    [SerializeField] private int _score = 0;
    [SerializeField] private Text _scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int buff)
    {
        _score += buff;
        _scoreBoard.text = "Score: " + _score;
    }
}
