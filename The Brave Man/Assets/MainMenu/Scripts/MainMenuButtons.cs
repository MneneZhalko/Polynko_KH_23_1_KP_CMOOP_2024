using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Скрипт для переходу до різних сцен за номером через головне меню
public class MainMenuButtons : MonoBehaviour
{
    // Додаємо зміну номеру сцени
    public int scene;

    // Відтворюємо переход між ними
    public void changeScene()
    {
        SceneManager.LoadScene(scene);
    }
}