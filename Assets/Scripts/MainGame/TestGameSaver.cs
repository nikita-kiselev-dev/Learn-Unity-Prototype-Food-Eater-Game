using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class TestGameSaver : MonoBehaviour
{
    private void Start()
    {
        string path = Application.persistentDataPath + "/test2_savefile.json";
    }
}
