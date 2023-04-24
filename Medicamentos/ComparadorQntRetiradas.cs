using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeMedicamentos.Medicamentos
{
    internal class ComparadorQntRetiradas : IComparer
    {
        int IComparer.Compare(Object A, Object B)
        {
            Medicamento a = (Medicamento)A;
            Medicamento b = (Medicamento)B;
            return a.qntRetiradas.CompareTo(b.qntRetiradas);
        }
    }
}
