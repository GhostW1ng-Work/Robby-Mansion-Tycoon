using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private Quaternion _rotation;
     
    public Vector3 Position => _position;
    public Quaternion Rotation => _rotation;
}
