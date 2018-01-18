using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContravariantAndCovariant
{
    interface NormalInterface<T> { }

    interface ContravariantInterface<in T> { }
   
    interface CovariantInterface<out T> { }
}
