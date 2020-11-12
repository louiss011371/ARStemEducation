using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScece : MonoBehaviour
{
    public void MenuToChem()
    {
        SceneManager.LoadScene("ARElementVuforia");
    }
    public void MenuToARLab()
    {
        SceneManager.LoadScene("TestScene");
    }
    public void MenuToElectric()
    {
        SceneManager.LoadScene("ARElectricVuforia");
    }
    public void MenuToHome()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
