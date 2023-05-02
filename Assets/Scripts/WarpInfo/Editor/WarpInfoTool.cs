using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WarpInfoTool : ScriptableWizard
{

    public string OutputFileName;

    [MenuItem("SaapasJalka/WarpInfo/Make Warp Info of selected object")]
    [ExecuteInEditMode]
    static void MakeWarpInfoOfObject()
    {
        Debug.Log("Hello World");
        ScriptableWizard.DisplayWizard<WarpInfoTool>("Create Warp Info of object");
    }

    void OnWizardCreate()
    {

        if(OutputFileName != "" && Selection.activeGameObject)
        {
        WarpInfo info = ScriptableObject.CreateInstance<WarpInfo>();
        GameObject target = Selection.activeGameObject;
        info.Position = target.transform.position;
        info.SceneIndex = target.scene.buildIndex;

        AssetDatabase.CreateAsset(info, $"Assets/Scripts/WarpInfo/{OutputFileName}.asset");
        }
        
    }

    void OnWizardUpdate()
    {
        if(OutputFileName == "")
        helpString = "Please provide a file name!";
    }


}
