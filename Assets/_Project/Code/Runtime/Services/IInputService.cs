using System;
using UnityEngine;

namespace Runtime.Services
{
    public interface IInputService
    {
        Vector3 MoveDirection { get; }
        void Enable();
        void Disable();
    }
}