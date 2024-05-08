using System;
using System.Windows;
using System.Windows.Controls;

namespace Lab3
{
    internal class RightPanel
    {
        private Grid gridCurrent;

        private bool nextStatus = true;

        public RightPanel(Grid grid) { gridCurrent = grid; }

        public void ShowHidePanel()
        {
            gridCurrent.ColumnDefinitions[4].Width = 
                new GridLength(nextStatus ? 1 : 0, GridUnitType.Star);

            nextStatus = !nextStatus;
        }
    }
}