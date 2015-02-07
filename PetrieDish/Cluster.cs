using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PetrieDish
{
    public class Cluster
    {
        private Bacterium[,][] Storage;
        private Double WidthCluster;
        private Int32 CntCluster;
        public Cluster(Double dishDimension)
        {
            WidthCluster = Math.Truncate(Math.Sqrt(dishDimension));
            CntCluster = (Int32)Math.Ceiling(dishDimension / WidthCluster);
            Storage = new Bacterium[CntCluster, CntCluster][];
        }

        public void Distribute(Bacterium b)
        {
            Int32 i = (Int32)Math.Truncate(b.CurrentPoint.X / WidthCluster);
            Int32 j = (Int32)Math.Truncate(b.CurrentPoint.Y / WidthCluster);
            if (Storage[i, j] == null)
            {
                Storage[i, j] = new Bacterium[] { b };
            }
            else
            {
                Array.Resize(ref Storage[i, j], Storage[i, j].Length + 1);
                Storage[i, j][Storage[i, j].Length - 1] = b;
            }
        }

        public Bacterium[] GetNearestBacteria(Point p)
        {
            Int32 i = (Int32)Math.Truncate(p.X / WidthCluster);
            Int32 j = (Int32)Math.Truncate(p.Y / WidthCluster);
            Int32 mFrom = i - 1 < 0 ? 0 : i - 1;
            Int32 mTo = i + 1 > CntCluster ? CntCluster : i + 1;
            Int32 nFrom = j - 1 < 0 ? 0 : j - 1;
            Int32 nTo = j + 1 > CntCluster ? CntCluster : j + 1;

            Bacterium[] output = new Bacterium[0];
            for (Int32 m = mFrom; m <= mTo; m++)
                for (Int32 n = nFrom; n <= nTo; n++)
                {
                    Int32 c = output.Length;
                    Array.Resize(ref output, output.Length + Storage[m, n].Length);

                    for (Int32 k = 0; k <= Storage[m, n].Length - 1; k++)
                    {
                        output[c + k] = Storage[m, n][k];
                    }
                }

            return output;
        }
    }
}
