using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMini.src.terrain
{
    public struct TileVoxel
    {
        public byte v_tileID;
        public int x;
        public int y;

        public TileVoxel[] GetNey(int x, int y)
        {
            return null;
        }

        public static TileVoxel Empty { get { return new TileVoxel() { v_tileID = 50 }; } }
    }
}
