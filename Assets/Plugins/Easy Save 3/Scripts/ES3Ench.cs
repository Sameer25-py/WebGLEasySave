using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ES3Ench : MonoBehaviour
{
    public static ES3Ench    Inst;
    public        InputField InputField;

    void Awake()
    {
        Inst = this;
    }


    public void SaveFromInput()
    {
        PlayerPrefs.SetString(ES3Settings.defaultSettings.path, InputField.text);
        PlayerPrefs.Save();
    }
}