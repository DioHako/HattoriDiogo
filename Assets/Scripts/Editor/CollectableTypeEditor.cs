using UnityEditor;

[CustomEditor(typeof(Collectables))]
public class CollectableTypeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var type = serializedObject.FindProperty("collectableTypes");
        EditorGUILayout.PropertyField(type);
        
        EditorGUILayout.Space();

        switch (type.enumValueIndex)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                DisplayPowerUps();
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void DisplayPowerUps()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("PowerUp"));
    }
}
