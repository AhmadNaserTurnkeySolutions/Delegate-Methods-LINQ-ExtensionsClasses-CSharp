using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Part2
{
    public class MainClass
{

        public delegate int NumberDelegate(int a, int b);
        public event NumberDelegate NumberEvent;

    public MainClass()
        {

            #region Get Event Call Result

     //   NumberDelegate NumberDelegateHandler = new NumberDelegate(this.AddEventMethod);

     //  this.NumberEvent += NumberDelegateHandler;
  
#endregion

       #region Event Call Many delegeates

       //::Way 1

       //1-A one event with one multi case delegate

       //NumberDelegate NumberDelegateHandler = new NumberDelegate(this.AddEventMethod);
       //NumberDelegateHandler=new NumberDelegate(this.MultEventMethod);


       //1-B one event with two delegates
         NumberDelegate NumberDelegateHandler1 = new NumberDelegate(this.AddEventMethod);
             NumberDelegate NumberDelegateHandler2 = new NumberDelegate(this.MultEventMethod);
             NumberDelegate NumberDelegateHandler3 = new NumberDelegate(this.DivEventMethod);

             this.NumberEvent += NumberDelegateHandler3;
             this.NumberEvent += NumberDelegateHandler1;
             this.NumberEvent += NumberDelegateHandler2;

             this.NumberEvent -= NumberDelegateHandler3;



            //::Way 2
            //AddDelegate AddDelegateHandler = null;
            //AddDelegateHandler = this.AddEventMethod;
            //this.NumberEvent += AddDelegateHandler;

            //// ::Way 3
            // this.NumberEvent += new AddDelegate(this.AddEventMethod);
       #endregion

    }
    public int ReiaseEvent(int x,int y)
    {
        int returnValue = 0;

        if (NumberEvent != null)
        {
            // NumberEvent(x, y);
          NumberEvent.Invoke(x, y);

        }








        //Code For Async and result back
        /*
        if (NumberEvent != null)
        {
            

            // begin execution asynchronously
            IAsyncResult result = NumberEvent.BeginInvoke(x,y, null, null);

            // wait for it to complete
            while (result.IsCompleted == false)
            {
                // do some work
              //  Thread.Sleep(10);
            }
            
            // get the return value
             returnValue = NumberEvent.EndInvoke(result);
        }*/
            return returnValue;
        
    }

    private int AddEventMethod(int a, int b)
    {
        Console.WriteLine((a + b));
        return  (a + b) ;
    }

    private int MultEventMethod(int a, int b)
    {
        Console.WriteLine((a * b));
        return (a * b);
    }

    private int DivEventMethod(int a, int b)
    {
        Console.WriteLine((a / b));
        return (a / b);
    }
}
}
