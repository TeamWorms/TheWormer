using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {
    public GameObject losego;
    public Text policeAlert;
    public void InitUI()
    {
        losego.SetActive(false);
        policeAlert.enabled = false;
    }
    public void ShowPoliceAlert()
    {
        policeAlert.enabled = true;
    }
    public void disablePoliceAlert()
    {
        policeAlert.enabled = false;
    }
    public void ShowLoseGame()
    {
        losego.SetActive(true);

    }
    public void ReplayButtonDown()
    {
        GameControl.Instance.Restart();
    }

    public void HideLoseGame()
    {
        losego.SetActive(false);
    }
}
