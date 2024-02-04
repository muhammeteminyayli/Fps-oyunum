using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Interface : MonoBehaviour
{

    [SerializeField] private GameObject settings;
    public void Start() {
        settings.SetActive(false);
    }
 
    public void PlayGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("InGame");
    }
    public void SettingsOpen(){
        settings.SetActive(true);
    }
    public void SettingsClose(){
        settings.SetActive(false);
    }
    public void VeryLow(){
        QualitySettings.SetQualityLevel(0);
    }
    public void Low(){
        QualitySettings.SetQualityLevel(1);
    }
    public void Medium(){
        QualitySettings.SetQualityLevel(2);
    }
    public void High(){
        QualitySettings.SetQualityLevel(3);
    }
    public void VeryHigh(){
        QualitySettings.SetQualityLevel(4);
    }
    public void Ultra(){
        QualitySettings.SetQualityLevel(5);
    }
    public void QuitGame(){
        Application.Quit();
    }
    }

