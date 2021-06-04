using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCArrayList : MonoBehaviour
{
    private int index;
    [SerializeField] private ChemMcArrayList[] chemMcArrayList;
    public void SetValue(int index , ChemMcArrayList subClass) {
        chemMcArrayList[index] = subClass;
    }

    public ChemMcArrayList GetValue (int index) {
        return chemMcArrayList[index];
    }

    public void SetCurrentIndex(int index)
    {
        this.index = index;
    }

    public int getCurrentIndex()
    {
        return index;
    }
    public int GetSize()
    {
        return chemMcArrayList.Length;
    }
}

[System.Serializable]
public class ChemMcArrayList {
    public Sprite questionImage;
    public string ansA;
    public string ansB;
    public string ansC;
    public string ansD;
    public string ans;
}
