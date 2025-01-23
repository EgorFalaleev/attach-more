using UnityEngine;

namespace Runtime.Services
{
    public interface IInputService
    {
        Vector2 MoveDirection { get; }
    }
}