using System;
using CustomIoc.DAL;
using CustomIoc.IDAL;
using CustomIoc.Utility.CustomContainer;

namespace CustomIocConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MyContainer container = new MyContainer();
            container.Register<IUserDAL, UserDAL>();
            IUserDAL userDal = container.Resolve<IUserDAL>();



        }
    }
}
