using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    [SerializeField] private InputField _username;
    [SerializeField] private InputField _password;
    [SerializeField] private Text _debugText;
    [SerializeField] private string _realUsername;
    [SerializeField] private string _realPassword;
    [SerializeField] private GameObject _login;
    [SerializeField] private GameObject _account;

    public void Login()
    {
        if(_username.text.Length < 4 || _password.text.Length < 4)
        {
            _debugText.text = "Too short. Enter at least 4 characters for both username and password";
            _username.text = "";
            _password.text = "";
        }
        else
        {
            _debugText.text = "";
            if(_username.text == _realUsername && _password.text == _realPassword)
            {
                _debugText.text = "Successfull entry";
            }
            else
            {
                _debugText.text = "Wrong password or Username";
            }
        }
    }

    public void CreateAccount()
    {
        if (_username.text.Length < 4 || _password.text.Length < 4)
        {
            _debugText.text = "Too short. Enter at least 4 characters for both username and password";
            _username.text = "";
            _password.text = "";
        }
        else
        {
            _realUsername = _username.text;
            _realPassword = _password.text;
            _debugText.text = "Account successfully created. Pleas go back to Login";
            _username.text = "";
            _password.text = "";
        }
    }

    public void GoToAccount()
    {
        _account.SetActive(true);
        _login.SetActive(false);
        _debugText.text = "";
        _username.text = "";
        _password.text = "";
    }

    public void GoToLogin()
    {
        _login.SetActive(true);
        _account.SetActive(false);
        _debugText.text = "";
        _username.text = "";
        _password.text = "";
    }
}
