using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContravariantAndCovariant
{
    //普通泛型接口实现
    class NormalConcretClassForDog:NormalInterface<Dog> { }


    //逆变接口实现
    class ContraConcretClassForAnimal:ContravariantInterface<Animal> { }
    class ContraConcretClassForDog:ContravariantInterface<Dog> { }
    class ContraConcretClassForBlueDog:ContravariantInterface<BlueDog> { }


    //协变接口实现
    class CovariantConcretClassForDog:CovariantInterface<Dog> { }

}
