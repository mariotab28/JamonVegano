using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
//using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    //public Dropdown resolutionDropdown;
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    void Start() {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions(); //Borra las opciones del dropdown

        //Lista con las resoluciones posibles para el jugador
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            if(i > 0 && (resolutions[i].width != resolutions[i - 1].width ||  //Comprueba que no está añadiendo una opción repetida
                resolutions[i].height != resolutions[i - 1].height))
                options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width ||   //Pone la opción por defecto a la resolución actual de la pantalla
                resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options); //Añade las nuevas opciones al dropdown
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }


    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


    public void SetVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
    }


    public void SetQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);

    }


    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }
}
