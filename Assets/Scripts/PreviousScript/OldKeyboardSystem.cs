using System;
using System.Collections.Generic;
namespace Command
{
    public class OldKeyboardSystem : Command
    {
        private OldCircleController player;
        private float init_x, init_y;

        public OldKeyboardSystem(OldCircleController circle, float x, float y)
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