using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    public GameObject NavigationMenu;
    public GameObject ToolsMenu;
    public GameObject MaterialsMenu;
    public GameObject SettingMenu;
    public GameObject ProjectsMenu;

    public void Start()
    {
        CloseWindows();
    }

    private void CloseWindows()
    {
        NavigationMenu.SetActive(false);
        ToolsMenu.SetActive(false);
        MaterialsMenu.SetActive(false);
        SettingMenu.SetActive(false);
        ProjectsMenu.SetActive(false);
    }

    public void OpenNavigationWindow()
    {
        CloseWindows();
        NavigationMenu.SetActive(true);
    }

    public void OpenToolsMenu()
    {
        CloseWindows();
        ToolsMenu.SetActive(true);
    }

    public void OpenMaterialsMenu()
    {
        CloseWindows();
        MaterialsMenu.SetActive(true);
    }

    public void OpenSettingsWindow()
    {
        CloseWindows();
        SettingMenu.SetActive(true);
    }

    public void OpenProjectsWindow()
    {
        CloseWindows();
        ProjectsMenu.SetActive(true);
    }
}