using System;
using System.Collections.Generic;
namespace Command
{
    public class KeyboardSystem : Command
    {
        private CircleController player;
        private float init_x, init_y;

        public KeyboardSystem(CircleController circle, float x, float y)
        {
            player = circle;
            init_x = x;
            init_y = y;
        }

        // Using command class
        public override void Init()
        {
            player.MoveInput(init_x, init_y);
        }
    }
}