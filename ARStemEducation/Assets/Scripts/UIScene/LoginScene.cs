using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginScene : MonoBehaviour
{
    [SerializeField]
    private GameObject userIdInputField, passwordInputField;
    [SerializeField]
    private GameObject loginButton;
    private string userIdText, passwordText;
    // Start is called before the first frame update

    public void Login()
    {
        userIdText = userIdInputField.GetComponent<Text>().text;
        passwordText = passwordInputField.GetComponent<Text>().text;
        Debug.Log("user id " + userIdText);
        Debug.Log("user password " + passwordText);
        if(userIdText == "207102400" && passwordText == "123456")
        {
            Debug.Log("Login success");
            SceneManager.LoadScene("MenuScene");
        } else
        {
            Debug.Log("Wrong user id or password");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
