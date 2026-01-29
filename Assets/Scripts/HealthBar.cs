using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private int _health;
    [SerializeField] private Text _text;
    // Start is called before the first frame update
    void Start()
    {
        _health = 100;
        _slider.value = _health;
        _text.text = _slider.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_health >= 1)
            {
                _health -= 20;
                _slider.value = _health;
                _text.text = _slider.value.ToString();
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (_health <= 99)
            {
                _health += 20;
                _slider.value = _health;
                _text.text = _slider.value.ToString();
            }
        }
    }
}
