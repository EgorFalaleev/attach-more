using UnityEngine;

namespace Runtime.Services.Input
{
    public interface IInputService
    {
        Vector3 MoveDirection { get; }
        void Enable();
        void Disable();
    }
}