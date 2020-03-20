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

            #region 准备构造函数参数 ，实现对象之间关联

            var ctor = type.GetConstructors()[0];
            List<object> paraList = new List<object>();
            foreach (var para in ctor.GetParameters())
            {
                Type paraType = para.ParameterType; // 获取参数的类型，比如IUserDAL
                //创建这个类型
                string paraKey = paraType.FullName;//IUserDAL的完整名称
                Type paraTargetType = this.myContainerDictionary[paraKey];
                paraList.Add(Activator.CreateInstance(paraTargetType));
            }
            #endregion
            object oInstance = Activator.CreateInstance(type, paraList.ToArray());

            //通过类型，类来生成对象，反射
            //object oInstance = Activator.CreateInstance(type);
            return (TFrom)oInstance;
        }
    }
}
