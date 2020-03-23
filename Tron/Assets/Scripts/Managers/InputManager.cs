using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    // Basis

    [System.Serializable]
    public class PlayerInput
    {
        public int playerID;

        public KeyCode right;
        public KeyCode left;
        public KeyCode up;
        public KeyCode down;
        public KeyCode pause;
        public KeyCode select;
        public KeyCode back;
        public KeyCode track;
    }

    public PlayerInput[] players;
}
