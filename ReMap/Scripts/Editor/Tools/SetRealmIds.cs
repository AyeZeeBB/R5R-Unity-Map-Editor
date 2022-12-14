using UnityEngine;
using UnityEditor;

public class SetRealmIds : EditorWindow
{
    private GameObject source;
    private int realmID = 0;

    [MenuItem("ReMap/Tools/RealmID Tool", false, 100)]
    public static void Init()
    {
        SetRealmIds window = (SetRealmIds)EditorWindow.GetWindow(typeof(SetRealmIds), false, "RealmID Tool");
        window.Show();
        window.minSize = new Vector2(375, 70);
        window.maxSize = new Vector2(375, 70);
    }

    void OnGUI()
    {
        GUILayout.BeginVertical("box");
        source = EditorGUILayout.ObjectField(source, typeof(Object), true) as GameObject;
        realmID = EditorGUILayout.IntField("RealmID:", realmID);
        GUILayout.EndVertical();

        if (GUILayout.Button("Set Realm IDS"))
            SetID();
    }

    void SetID()
    {
        if(source == null)
            return;

        foreach (Transform child in source.transform) {
            PropScript script = child.gameObject.GetComponent<PropScript>();
            if(script != null)
                script.realmID = realmID;
        }
    }
}
