using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void HomeToMenu() {
        SceneManager.LoadScene("MenuScene");
    }
}