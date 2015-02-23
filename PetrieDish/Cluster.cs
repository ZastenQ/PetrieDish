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
        public Double ClusterDimension { get; protected set; }
        public Int32 CntCluster { get; protected set; }

        public int this[int i, int j]
        {
            get
            {
                return Storage[i, j] == null ? 0 : Storage[i, j].Count();
            }
        }

        public Cluster(Double dishDimension)
        {
            ClusterDimension = Math.Truncate(Math.Sqrt(dishDimension));
            CntCluster = (Int32)Math.Ceiling(dishDimension / ClusterDimension);
            Storage = new Bacterium[CntCluster, CntCluster][];
        }

        public void Distribute(Bacterium b)
        {
            Int32 i = (Int32)Math.Truncate(b.CurrentPoint.X / ClusterDimension);
            Int32 j = (Int32)Math.Truncate(b.CurrentPoint.Y / ClusterDimension);
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
            Int32 i = (Int32)Math.Truncate(p.X / ClusterDimension);
            Int32 j = (Int32)Math.Truncate(p.Y / ClusterDimension);
            Int32 mFrom = i - 1 < 0 ? 0 : i - 1;
            Int32 mTo = i + 1 >= CntCluster ? CntCluster - 1 : i + 1;
            Int32 nFrom = j - 1 < 0 ? 0 : j - 1;
            Int32 nTo = j + 1 >= CntCluster ? CntCluster - 1 : j + 1;

            Bacterium[] output = new Bacterium[0];
            for (Int32 m = mFrom; m <= mTo; m++)
                for (Int32 n = nFrom; n <= nTo; n++)
                {
                    if (Storage[m, n] == null)
                        continue;

                    Int32 c = output.Length;
                    Array.Resize(ref output, output.Length + Storage[m, n].Length);

                    for (Int32 k = 0; k <= Storage[m, n].Length - 1; k++)
                    {
                        output[c + k] = Storage[m, n][k];
                    }
                }

            return output;
        }

        public void RemoveDeadBacteria()
        {
            for (Int32 m = 0; m <= CntCluster - 1; m++)
                for (Int32 n = 0; n <= CntCluster - 1; n++)
                {
                    if (Storage[m, n] == null)
                        continue;

                    Storage[m, n] = Storage[m, n].Where(x => x.IsDead == false).ToArray();
                }
        }

        public void MoveCluster(Bacterium b, Point p)
        {
            Int32 i1 = (Int32)Math.Truncate(b.CurrentPoint.X / ClusterDimension);
            Int32 j1 = (Int32)Math.Truncate(b.CurrentPoint.Y / ClusterDimension);
            Int32 i2 = (Int32)Math.Truncate(p.X / ClusterDimension);
            Int32 j2 = (Int32)Math.Truncate(p.Y / ClusterDimension);

            if ((i1 == i2) && (j1 == j2))
            {
                return;
            }
            else
            {
                Storage[i1, j1] = Storage[i1, j1].Where(x => x != b).ToArray();
                if (Storage[i2, j2] == null)
                {
                    Array.Resize(ref Storage[i2, j2], 1);
                }
                else
                {
                    Array.Resize(ref Storage[i2, j2], Storage[i2, j2].Length + 1);
                }
                Storage[i2, j2][Storage[i2, j2].Length - 1] = b;
            }

        }
    }
}
