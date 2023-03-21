using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveFileToString : MonoBehaviour
{   
    
    public TextMeshProUGUI text;
    public SaveFileManager SaveFileManager;

    public void SaveFileInTextBox()
    {
        text.text = SaveFileManager.Settings.FullPath;
    }

}
