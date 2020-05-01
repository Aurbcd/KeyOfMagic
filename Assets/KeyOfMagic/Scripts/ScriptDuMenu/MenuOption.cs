using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Audio;

public class MenuOption : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float vol)
    {
        audioMixer.SetFloat("VolMaster", vol);
    }

    public void SetSensibility(float sens)
    {
        CameraRotationFixed.turnSpeed = sens;
    }

    public void Inverser(bool i)
    {
        if(i)
            CameraRotationFixed.inverser = -1;
        if (!i)
            CameraRotationFixed.inverser = 1;

    }


    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetMusic(bool m)
    {
        if (m)
        {
            audioMixer.SetFloat("VolMusic", -5);
        }
        if (!m)
        {
            audioMixer.SetFloat("VolMusic", -80);
        }
    }
    public void SetNotif(bool n)
    {
        if (n)
        {
            audioMixer.SetFloat("VolNotif", -5);
        }
        if (!n)
        {
            audioMixer.SetFloat("VolNotifs", -80);
        }
    }
}
