using System;
using System.Collections;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveObject
{
    public int Num, Over, NumTwo;
}

public class SaveFileManager : MonoBehaviour
{
    public ES3Settings Settings;
    public string      Url, SaveFileName, Password;

    private ES3Cloud _cloud;

    public IEnumerator LoadFileFromRemote()
    {
        yield return _cloud.DownloadFile(Settings.path, Settings);
        if (_cloud.isError)
        {
            Debug.LogError(_cloud.error);
            Debug.Log($"Error downloading file: {Url}/{SaveFileName}");
            yield break;
        }
        else
        {
            Debug.Log($"Download Complete: {Url}/{SaveFileName}");
        }
    }

    public IEnumerator SaveFileToRemote()
    {
        yield return _cloud.UploadFile(Settings.path, Settings);
        if (_cloud.isError)
        {
            Debug.LogError(_cloud.errorCode);
            Debug.Log($"Error Uploading file: {Url}/{SaveFileName}");
            yield break;
        }
        else
        {
            Debug.Log($"Upload Complete: {Url}/{SaveFileName}");
        }
    }

    public IEnumerator SyncWithRemote()
    {
        yield return _cloud.Sync(SaveFileName, Settings);
        if (_cloud.isError)
        {
            Debug.Log($"Error Syncing file: {Url}/{SaveFileName}");
            yield break;
        }
        else
        {
            Debug.Log($"Sync Complete: {Url}/{SaveFileName}");
        }
    }

    private void Start()
    {
        Settings = new ES3Settings
        {
            path               = Path.Join(Application.streamingAssetsPath, SaveFileName),
            encryptionType = ES3.EncryptionType.AES,
            encryptionPassword = "password"
        };
        _cloud = new ES3Cloud(Url, "");
    }
}