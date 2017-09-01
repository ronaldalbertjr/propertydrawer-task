using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using UnityEditorInternal;

[CustomPropertyDrawer(typeof(LayerSelectorAttribute))]
public class LayerSelectorDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Rect popupRect = new Rect(position.x, position.y, position.width, position.height);


        int index = System.Array.IndexOf(InternalEditorUtility.layers, LayerMask.LayerToName(property.intValue));
        var options = InternalEditorUtility.layers.ToList();
        options.Add("");
        options.Add("New Layer");
        index = EditorGUI.Popup(popupRect, "Layers: ", index, options.ToArray());


        if( index == options.Count - 1)
        {
            var a = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0];
            Selection.activeObject = a;
        }
        else
        {
            string layerName = InternalEditorUtility.layers[index];
            property.intValue = LayerMask.NameToLayer(layerName);
        }
    }
}
