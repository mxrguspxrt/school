using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;

namespace Trips
{
    public class Gameplay
    {
        public string[] selections;
        public string currentSelection;
        public int[,] winningRows;

        public Gameplay()
        {
            currentSelection = "o";
            selections = new string[9];
            winningRows = new int[,]{
                {0,1,2},
                {3,4,5},
                {6,7,8},
                {0,3,5},
                {1,4,7},
                {2,5,8},
                {0,4,8},
                {2,4,6}
            };
        }

        public bool selectSlot(int number)
        {
            if (selections[number] == null)
            {
                selections[number] = toggleSelection();
                Debug.WriteLine("Chose " + number + " " + selections[number]);
                return true;
            } else
            {
                return false;
            }
        }

        public string toggleSelection()
        {
            currentSelection = currentSelection=="o" ? "x" : "o";
            return currentSelection;
        }

        public bool hasFinished()
        {
            for(int x=0; x<winningRows.GetLength(0); x+=1)
            {
                for (int y = 0; y < winningRows.GetLength(1); y+=1)
                {
                    Debug.WriteLine(winningRows[x,y]);
                }
            }
            return false;
        }

    }
}
