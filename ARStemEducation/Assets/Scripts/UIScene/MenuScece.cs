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
    public void MenuToMaths()
    {
        SceneManager.LoadScene("Maths");
    }
    public void MenuToHome()
    {
        SceneManager.LoadScene("HomeScene");
    }
    public void MenuToTestMode()
    {
        SceneManager.LoadScene("TestModeScene");
    }
}
