using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {
    public GameObject losego;
    public GameObject winGO;
    public Text policeAlert;
    public Text scoreText;
    public void InitUI()
    {
        losego.SetActive(false);
        policeAlert.enabled = false;
        winGO.SetActive(false);
        
    }
    public void ShowPoliceAlert()
    {
        policeAlert.enabled = true;
    }
    public void disablePoliceAlert()
    {
        policeAlert.enabled = false;
    }
    public void SetScoreText(int score)
    {
        scoreText.text = "Score:"+score;
    }
    public void ShowWinGame()
    {

    }
    public void ShowLoseGame()
    {
        losego.SetActive(true);

    }
    public void ReplayButtonDown()
    {
        GameControl.Instance.Restart();
    }
    public void RestartButtonDown()
    {
        GameControl.Instance.Restart();
    }
    public void HideLoseGame()
    {
        losego.SetActive(false);
    }
}
