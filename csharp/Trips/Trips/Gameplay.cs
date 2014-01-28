using System;
using System.Collections.Generic;
using System.Collections;
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
        public List<int[]> winningRows;

        public Gameplay()
        {
            currentSelection = "o";
            selections = new string[9];
            winningRows = new List<int[]>();
            winningRows.Add(new int[]{0,1,2});
            winningRows.Add(new int[]{3,4,5});
            winningRows.Add(new int[]{6,7,8});
            winningRows.Add(new int[]{0,3,5});
            winningRows.Add(new int[]{1,4,7});
            winningRows.Add(new int[]{2,5,8});
            winningRows.Add(new int[]{0,4,8});
            winningRows.Add(new int[]{2,4,6});
        }

        public bool selectSlot(int position)
        {
            if (selections[position] == null && !hasFinished())
            {
                selections[position] = toggleSelection();
                Debug.WriteLine("Chose " + position + " " + selections[position]);
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

        public string[] getSelectionsValues(int[] positions)
        {
            string[] values = new string[positions.Length];
            for (int i=0; i<positions.Length; i+=1)
            {
                values[i] = selections[positions[i]];
            }
            return values;
        }

        public bool allAreEqualAndNotNulls(string[] characters)
        {
            string last = null;
            for (int i = 0; i < characters.Length; i += 1)
            {
                if (characters[i] == null)
                {
                    return false;
                }
                if (i != 0 && characters[i] != last)
                {
                    return false;
                }
                last = characters[i];
            }
            return true;
        }

        public int[] getWinningRow()
        {
            foreach (int[] winningRow in winningRows)
            {
                string[] selectionValues = getSelectionsValues(winningRow);
                bool areEqual = allAreEqualAndNotNulls(selectionValues);
                if (areEqual)
                {
                    return winningRow;
                }
            }
            return null;
        }

        public bool hasFinished()
        {
            return getWinningRow() != null;
        }

    }
}
