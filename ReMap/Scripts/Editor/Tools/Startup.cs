using UnityEngine;
using UnityEditor;
using System.IO;

[InitializeOnLoad]
public class Startup : EditorWindow {

    static string currentDirectory = Directory.GetCurrentDirectory();
    static string relativeConfigFile = $"Assets/ReMap/Resources/startupconfig.json";
    static Startup()
    {
        //These will run when Unity starts up
        TagHelper.CheckAndCreateTags();

        if (!File.Exists(currentDirectory + "/" + relativeConfigFile))
        {
            Root myObject = new Root();
            myObject.ShowStartupWindow = true;
            string newJson = JsonUtility.ToJson(myObject);
            System.IO.File.WriteAllText(currentDirectory + "/" + relativeConfigFile, newJson);
        }

        string json = System.IO.File.ReadAllText(currentDirectory + "/" + relativeConfigFile);
        if (json != null)
        {
            Root myObject = JsonUtility.FromJson<Root>(json);
            if (myObject.ShowStartupWindow)
            {
                StartupWindow.Init();
            }
        }
    }

    public class Root
    {
        public bool ShowStartupWindow;
    }
}