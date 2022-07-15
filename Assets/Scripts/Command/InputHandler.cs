using System;
using System.Collections.Generic;
using UnityEngine;
using Command;
namespace Command
{
    public class InputHandler : MonoBehaviour
    {
        public CircleController player;

        // Enum Command
        public InputType inputType;

        private void FixedUpdate()
        {
            if (inputType == InputType.Keyboard)
            {
                Command move = KeyboardInput();
                if (move != null)
                {
                    move.Init();
                }
            }
            else if (inputType == InputType.Cursor)
            {        
                Command move = CursorMovement();
                if (move != null)
                {
                    move.Init();
                }
            }
        }

        // Inputan dari keyboard
        private Command KeyboardInput()
        {
            float inputX = Input.GetAxis("Horizontal"); //ke kiri dan kanan
            float inputY = Input.GetAxis("Vertical"); //ke atas dan bawah

            // manggil Script KeyBoardMove
            return new KeyboardSystem(player, inputX, inputY); //pake fungsi di keyboardsystem
        }

        private Command CursorMovement()
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            return new CursorSystem(player, position);
        }

        // Jenis inputan
        public enum InputType
        {
            Keyboard,
            Cursor
        }
    }
}