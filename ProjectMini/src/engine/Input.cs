using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMini.src.engine
{
    public static class Input
    {
        private static KeyboardState v_keyboardCurrentFrame;
        private static KeyboardState v_keyboardLastFrame;

        private static GamePadState v_gamePadCurrent;
        private static GamePadState V_gamePadLast;

        private static MouseState v_mouseCurrent;
        private static MouseState v_mouseLast;

        public static void TickStart()
        {
            v_keyboardCurrentFrame = Keyboard.GetState();
            v_gamePadCurrent = GamePad.GetState(PlayerIndex.One);
            v_mouseCurrent = Mouse.GetState();
        }

        public static void TickEnd()
        {
            v_keyboardLastFrame = v_keyboardCurrentFrame;
            V_gamePadLast = v_gamePadCurrent;
            v_mouseLast = v_mouseCurrent;
        }

        public static bool GetKey(Keys key)
        {
            return v_keyboardCurrentFrame.IsKeyDown(key);
        }

        public static bool GetKeyUp(Keys key)
        {
            return v_keyboardCurrentFrame.IsKeyUp(key) && v_keyboardLastFrame.IsKeyDown(key);
        }

        public static bool GetKeyDown(Keys key)
        {
            return v_keyboardCurrentFrame.IsKeyDown(key) && v_keyboardLastFrame.IsKeyUp(key);
        }


        public static bool GetButtonUp(Buttons key)
        {
            return v_gamePadCurrent.IsButtonUp(key) && V_gamePadLast.IsButtonDown(key);
        }

        public static bool GetButtonDown(Buttons key)
        {
            return v_gamePadCurrent.IsButtonDown(key) && V_gamePadLast.IsButtonUp(key);
        }

        public static bool GetMouseButtonUp(MouseButtom key)
        {
            switch (key)
            {
                case MouseButtom.none:
                    return false;
                case MouseButtom.Left:
                    return v_mouseCurrent.LeftButton == ButtonState.Released && v_mouseLast.LeftButton == ButtonState.Pressed;
                case MouseButtom.Right:
                    return v_mouseCurrent.RightButton == ButtonState.Released && v_mouseLast.RightButton == ButtonState.Pressed;
                case MouseButtom.Midle:
                    return v_mouseCurrent.MiddleButton == ButtonState.Released && v_mouseLast.MiddleButton == ButtonState.Pressed;
                case MouseButtom.Buttom1:
                    return v_mouseCurrent.XButton1 == ButtonState.Released && v_mouseLast.XButton1 == ButtonState.Pressed;
                case MouseButtom.Buttom2:
                    return v_mouseCurrent.XButton2 == ButtonState.Released && v_mouseLast.XButton2 == ButtonState.Pressed;
                default:
                    return false;
            }
        }

        public static bool GetMouseButtonDown(MouseButtom key)
        {
            switch (key)
            {
                case MouseButtom.none:
                    return false;
                case MouseButtom.Left:
                    return v_mouseCurrent.LeftButton == ButtonState.Pressed && v_mouseLast.LeftButton == ButtonState.Released;
                case MouseButtom.Right:
                    return v_mouseCurrent.RightButton == ButtonState.Pressed && v_mouseLast.RightButton == ButtonState.Released;
                case MouseButtom.Midle:
                    return v_mouseCurrent.MiddleButton == ButtonState.Pressed && v_mouseLast.MiddleButton == ButtonState.Released;
                case MouseButtom.Buttom1:
                    return v_mouseCurrent.XButton1 == ButtonState.Pressed && v_mouseLast.XButton1 == ButtonState.Released;
                case MouseButtom.Buttom2:
                    return v_mouseCurrent.XButton2 == ButtonState.Pressed && v_mouseLast.XButton2 == ButtonState.Released;
                default:
                    return false;
            }
        }
    }

    public enum MouseButtom : byte
    {
        none, Left, Right, Midle, Buttom1, Buttom2
    }
}
