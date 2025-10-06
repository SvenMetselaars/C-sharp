using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPR_ArduinoConnect_Worksheet_Template1
{
    internal class Location
    {
        private int horizontal = 0;
        private int vertical = 0;
        private int rotation = 0;
        private string locationtype = "";

        public Location(int c_horizontal, int c_vertical, int c_rotation, string c_locationtype)
        {
            horizontal = c_horizontal;
            vertical = c_vertical;
            rotation = c_rotation;
            locationtype = c_locationtype;
        }

        public int GetHorizontal() { return horizontal; }
        public int GetVertical() { return vertical; }
        public int GetRotation() { return rotation; }
        public string GetLocationtype() { return locationtype; }
    }
}
