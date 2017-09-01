using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomPropertyDrawer(typeof(TagSelectorAttribute))]
public class TagSelectorDrawer :  PropertyDrawer
{
    int index;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.String)
        {
            for (int i = 0; i < UnityEditorInternal.InternalEditorUtility.tags.Length; i++)
            {
                if (UnityEditorInternal.InternalEditorUtility.tags[i].Equals(property.stringValue))
                {
                    index = i;
                }
            }


            Rect popupRect = new Rect(position.x, position.y, position.width, position.height);
            index = EditorGUI.Popup(popupRect, "Tags: ", index, InternalEditorUtility.tags);
            property.stringValue = UnityEditorInternal.InternalEditorUtility.tags[index];
        }
    }
}
