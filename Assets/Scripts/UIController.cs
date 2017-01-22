using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {
    public GameObject losego;
    
    public void InitUI()
    {
        losego.SetActive(false);
    }
	public void ShowLoseGame()
    {
        losego.SetActive(true);

    }
    public void ReplayButtonDown()
    {
        GameControl.Instance.Restart();
    }
}
