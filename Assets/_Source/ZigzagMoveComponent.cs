using UnityEngine;

namespace _Source
{
    public struct ZigzagMoveComponent 
    {
        public Transform Transform;    
        public float ForwardSpeed;
        public float SideAmplitude;
        public float Frequency;
        public Vector3 StartPosition;
        public float TimeOffset;
    }
}