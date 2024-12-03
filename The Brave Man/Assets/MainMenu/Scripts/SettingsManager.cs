// Скрипт для видалення прогресу гри
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public void DeleteProgressButtonOnClick()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        DestroyAllDontDestroyOnLoadObjects();
    }

    public void DestroyAllDontDestroyOnLoadObjects()
    {
        var tempScene = SceneManager.CreateScene("TempScene");

        var dontDestroyOnLoadObjects = GetDontDestroyOnLoadObjects();
        foreach (var obj in dontDestroyOnLoadObjects)
        {
            SceneManager.MoveGameObjectToScene(obj, tempScene);
        }

        SceneManager.UnloadSceneAsync(tempScene);
    }

    private List<GameObject> GetDontDestroyOnLoadObjects()
    {
        List<GameObject> dontDestroyOnLoadObjects = new List<GameObject>();
        GameObject temp = null;
        try
        {
            temp = new GameObject();
            DontDestroyOnLoad(temp);
            var tempScene = temp.scene;
            SceneManager.MoveGameObjectToScene(temp, SceneManager.GetActiveScene());
            dontDestroyOnLoadObjects.AddRange(tempScene.GetRootGameObjects());
        }
        finally
        {
            if (temp != null)
            {
                Destroy(temp);
            }
        }
        return dontDestroyOnLoadObjects;
    }
}