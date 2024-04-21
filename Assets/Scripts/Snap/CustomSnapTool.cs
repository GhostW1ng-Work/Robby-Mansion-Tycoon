/*using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditor.SceneManagement;
using UnityEngine;

[EditorTool("Custom Snap Move", typeof(CustomSnap))]
public class CustomSnapTool : EditorTool
{
    [SerializeField] private Texture2D _toolIcon;

    private Transform _oldTarget;
    private CustomSnapPoint[] _allPoints;
    private CustomSnapPoint[] _targetPoints;

    public override GUIContent toolbarIcon
    {
        get
        {
            return new GUIContent
            {
                image = _toolIcon,
                text = "Custom Snap Move Tool"
            };
        }
    }

    public override void OnToolGUI(EditorWindow window)
    {
        Transform targetTransform = ((CustomSnap)target).transform;
        if (targetTransform != _oldTarget)
        {
            PrefabStage prefabStage = PrefabStageUtility.GetPrefabStage(targetTransform.gameObject);

            if (prefabStage != null)
                _allPoints = prefabStage.prefabContentsRoot.GetComponentsInChildren<CustomSnapPoint>();
            else
                _allPoints = FindObjectsOfType<CustomSnapPoint>();
            _targetPoints = targetTransform.GetComponentsInChildren<CustomSnapPoint>();

            _oldTarget = targetTransform;
        }
        EditorGUI.BeginChangeCheck();
        Vector3 newPosition = Handles.PositionHandle(targetTransform.position, Quaternion.identity);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(targetTransform, "Move with snap tool");
            Move(targetTransform, newPosition);
        }
    }

    private void Move(Transform targetTransform, Vector3 newPosition)
    {


        Vector3 bestPosition = newPosition;
        float closestDistance = float.PositiveInfinity;

        foreach (CustomSnapPoint point in _allPoints)
        {
            if (point.transform.parent == targetTransform) continue;
            foreach (CustomSnapPoint ownPoint in _targetPoints)
            {
                Vector3 targetPosition = point.transform.position - (ownPoint.transform.position - targetTransform.position);
                float distance = Vector3.Distance(targetPosition, newPosition);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    bestPosition = targetPosition;
                }
            }
        }

        if (closestDistance < 1f)
        {
            targetTransform.position = bestPosition;
        }
        else
        {
            targetTransform.position = newPosition;
        }
    }
}
*/