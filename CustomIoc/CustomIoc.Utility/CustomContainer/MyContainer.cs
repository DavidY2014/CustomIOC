using System;
using System.Collections.Generic;
using System.Text;

namespace CustomIoc.Utility.CustomContainer
{
    /// <summary>
    /// 用来生成对象,对象管理容器,IOC最简单版本
    /// </summary>
    public class MyContainer
    {
        private Dictionary<string, Type> myContainerDictionary = new Dictionary<string, Type>();

        public void Register<TFrom, TTo>() where TTo:TFrom
        {
            this.myContainerDictionary.Add(typeof(TFrom).FullName, typeof(TTo));
        }


        public TFrom Resolve<TFrom>()
        {
            string key = typeof(TFrom).FullName;
            Type type = this.myContainerDictionary[key];
            //通过类型，类来生成对象，反射
            object oInstance = Activator.CreateInstance(type);
            return (TFrom)oInstance;
        }
    }
}
