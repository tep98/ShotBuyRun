using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void GetDeviceInfo();

    public string deviceInfo;

    public void GettingDevice(string _device)
    {
        deviceInfo = _device;
    }
}
