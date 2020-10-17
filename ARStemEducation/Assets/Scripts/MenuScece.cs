using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScece : MonoBehaviour
{
    public void MenuToChem()
    {
        SceneManager.LoadScene("ElementsScene");
    }
    public void MenuToElectric()
    {
        SceneManager.LoadScene("ElectricScene");
    }
    public void MenuToHome()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
