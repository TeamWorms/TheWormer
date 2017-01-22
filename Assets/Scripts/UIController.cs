using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {
    public Text loseText;
    public void InitUI()
    {
        loseText.enabled = false;
    }
	public void ShowLoseGame()
    {
        loseText.enabled = true;
    }
}
