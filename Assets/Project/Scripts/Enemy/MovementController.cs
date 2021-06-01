﻿using Runtime;
using System;

namespace Enemy
{
    class MovementController : IController
    {
        public void OnStart()
        {
        }

        public void OnStop()
        {
        }

        public void Tick()
        {
            foreach (EnemyData data in Game.Player.EnemyDatas)
            {
                data.View.MovementAgent.TickMovement();
            }
        }
    }
}
