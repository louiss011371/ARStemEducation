using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElementSelection : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    private int currentElement;
    public TextMeshProUGUI changingText;
    private string elementName;
    private void Awake()
    {
        SelectElement(0);
        changingText = FindObjectOfType<TextMeshProUGUI>();
 
    }

    private void SelectElement(int index)
    {
        previousButton.interactable = (index != 0); // Can select if it isn't the first element
        nextButton.interactable = (index != transform.childCount - 1); // Can select if it isn't the last element
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
        elementName = transform.GetChild(currentElement).gameObject.name;
        //changingText.GetComponent<Text>().text = elementName;
        ////changingText.name = elementName;
        changingText.text = elementName;
        // Debug.Log(elementName);
    }

    public void ChangeElement(int change)
    {
        currentElement += change;
        SelectElement(currentElement);
        //Debug.Log(transform.GetChild(currentElement).gameObject.name);
    }
}
