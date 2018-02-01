using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    /// <summary>
    /// Event和delegate的区别有点像 属性 和 字段 的区别   !!!!!!!!!!!!!!!!
    /// 事件 对 委托 进行了一层封装
    /// </summary>
    
    public delegate void MyEventHandler(string name);
    class TestEvent
    {
        //实现事件的第一种方法： 直接类似属性的方式
        public event EventHandler MyEvent1;


        //实现事件的第二种方法
        private EventHandler _myEvent2;
        public event EventHandler MyEvent2
        {
            add
            {
                lock(this)
                {
                    _myEvent2 += value;
                }
            }
            remove
            {
                lock(this)
                {
                    _myEvent2 -= value;
                }
            }
        }

        //实现自定义事件 
        public event MyEventHandler SelfDefineEvent;

        public void RaiseEvent()
        {
             if(MyEvent1!=null) {MyEvent1(this,new EventArgs()); }

             //if(MyEvent2!=null) {MyEvent2(this,new EventArgs()); }  第二种定义方式这样激发事件是不行的，只能用下面的方式
             if(_myEvent2!=null) {_myEvent2(this,new EventArgs()); }  

             if(SelfDefineEvent!=null) {SelfDefineEvent("Hello"); }   //  自定义事件的激发
        }
    }

}
