using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawioToolsLib
{
    internal class IdManager
    {
        public IdManager()
        {

        }
        public void SetIds(List<MxCell> MxCells)
        {
            for (int i = 0; i < MxCells.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (MxCells[i].Id == MxCells[j].ParentId)
                        MxCells[i].Parent = MxCells[j];
                }
                for (int j = i + 1; j < MxCells.Count; j++)
                {
                    if (MxCells[i].Id == MxCells[j].ParentId)
                        MxCells[i].Parent = MxCells[j];
                }
            }
        }
    }

}
