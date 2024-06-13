using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;

namespace addressbook_web_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSquare()
        {
            //создал переменную и в эту переменную  присвоил в качестве значения
            //cсылку на новый объект типа square или класса square
            Square s1 = new Square(5);
            Square s2 = new Square(10);   // два разных объeкта одного и того же класса
            Square s3 = s1;                 // новый объект не создается просто у меня есть две переменные 
                                                    // s1 и s3 которые указывают на один и тот же объект, а s2 указывает на другой объект
                                            //каждый вызов конструктора создает объект, а потом уже дальше на него можно
                                                //ссылаться из нескольких мест, передавать в его в качестве параметров какие-то другие методы
                                            //присваивать какието переменные. Когда на него нет никакой ссылки, у него автоматически вызывается
                                                //конструктор, память исчезает объект исчезает
            Assert.AreEqual(s1.Size, 5);
            Assert.AreEqual(s2.Size, 10);
            Assert.AreEqual(s3.Size, 5);
            s3.Size = 15;
            Assert.AreEqual(s1.Size, 15);
            s2.Coloured = true;
        }
        [TestMethod]
        public void TestMethodCircle()
        {  
            Circle s1 = new Circle(5);
            Circle s2 = new Circle(10);
            Circle s3 = s1;
            Assert.AreEqual(s1.Radius, 5);
            Assert.AreEqual(s2.Radius, 10);
            Assert.AreEqual(s3.Radius, 5);
            s3.Radius = 15;
            Assert.AreEqual(s1.Radius, 15);
            s2.Coloured = true;
        }
    }
}
