using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject panel;
    public GameObject panelpengaturan;
    public GameObject panelkredit;
    public GameObject panelAlfred;
    public GameObject panelBila;
    public GameObject panelShalwa;
    public GameObject panelSherafine;
    public GameObject panelVanisa;


    public void OpenPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);
            Pause();
        }
        else
        {
            Resume();
        }
    }
    public void OpenPengaturan()
    {
        panelpengaturan.SetActive(true);
    }
    public void OpenKredit()
    {
        panelkredit.SetActive(true);
    }

    public void ClosePengaturan()
    {
        panelpengaturan.SetActive(false);
    }
    public void CloseKredit()
    {
        panelkredit.SetActive(false);
        panelAlfred.SetActive(false);
        panelBila.SetActive(false);
        panelShalwa.SetActive(false);
        panelSherafine.SetActive(false);
        panelVanisa.SetActive(false);
    }
    public void OpenPanelAlfred()
    {
        panelAlfred.SetActive(true);
        panelBila.SetActive(false);
        panelShalwa.SetActive(false);
        panelSherafine.SetActive(false);
        panelVanisa.SetActive(false);
    }
    public void OpenPanelBila()
    {
        panelBila.SetActive(true);
        panelAlfred.SetActive(false);
        panelShalwa.SetActive(false);
        panelSherafine.SetActive(false);
        panelVanisa.SetActive(false);
    }
    public void OpenPanelShalwa()
    {
        panelShalwa.SetActive(true);
        panelAlfred.SetActive(false);
        panelBila.SetActive(false);
        panelSherafine.SetActive(false);
        panelVanisa.SetActive(false);
    }
    public void OpenPanelSherafine()
    {
        panelSherafine.SetActive(true);
        panelAlfred.SetActive(false);
        panelBila.SetActive(false);
        panelShalwa.SetActive(false);
        panelVanisa.SetActive(false);
    }
    public void OpenPanelVanisa()
    {
        panelVanisa.SetActive(true);
        panelAlfred.SetActive(false);
        panelBila.SetActive(false);
        panelShalwa.SetActive(false);
        panelSherafine.SetActive(false);
    }
    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    public void Restart()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }
    public void MulaiLoading()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayDialog()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}