﻿namespace Runtime.Infrastructure.States
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}