using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] _menus;
    [SerializeField] private GameObject _pauseMenu;

    public void TurnOnMenu(int _menuID)
    {
        foreach(GameObject menu in _menus)
        {
            menu.SetActive(false);
        }
        _menus[_menuID].SetActive(true);
        PauseMenuOff();
    }

    public void PauseMenuOn()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
    }

    public void PauseMenuOff()
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
    }
}
