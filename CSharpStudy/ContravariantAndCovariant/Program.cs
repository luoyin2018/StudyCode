using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContravariantAndCovariant
{
    //注：只有接口或委托的泛型参数才能指定in和out关键字
    class Program
    {
        static void Main(string[] args)
        {
            //普通协变和逆变,普通类型父类引用可以直接引用子类实例(协变),反过来(逆变)不行
            Dog      dog     = new Dog();
            Animal   animal  = dog;
            //BlueDog  bluedog = (BlueDog)dog;       //编译时报错,提示不能进行类型转换

            //Case 1:对于普通泛型接口(不变)
            //下面两条VS直接报错，原因是无法进行类型转换,说明普通泛型接口不支持任何类型参数的转换（这句话准确性有待考虑)
            //NormalInterface<Animal>  normInterfaceForAnimal =  new NormalConcretClassForDog();
            //NormalInterface<BlueDog> normInterfaceForBlueDog = new NormalConcretClassForDog();

            //Case 2:用in修饰泛型类型的接口（支持泛型类型逆变)
            //ContravariantInterface<Animal> contravarInterfaceForAnimal = new ContraConcretClassForDog();   //这一条通不过,不支持泛型类型的协变
            ContravariantInterface<BlueDog> contravarInterfaceForBlueDog = new ContraConcretClassForDog();   
            //   要注意下面两种情况也是通不过的!!!
            //      这相当于A、B、C都是从O派生来的，A、B、C间不能互等。这与上面的情况是不同的。
            //      ContraConcretClassForAnimal conAnimal  = new ContraConcretClassForDog();
            //      ContraConcretClassForAnimal conBlueDog = new ContraConcretClassForDog();

            //Case 3:用out修饰泛型类型的接口（支持泛型类型协变)
            CovariantInterface<Animal>  covarInterfaceForAnimal  = new CovariantConcretClassForDog();
            //CovariantInterface<BlueDog> covarInterfaceForBlueDog = new CovariantConcretClassForDog();    //这一条报错，不支持泛型类型参数的逆变

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
