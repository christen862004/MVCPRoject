namespace MVCPRoject.Models
{


    public class Parant<T>
    {
       public  T[] x;
    }

    public class Child : Parant<int>
    {

    }
    public class Child2<T> : Parant<T>
    {

    }
    public class TestClass
    {
        public void Add(int x,int y)
        {

            


            int a = 10;
            string b = "ahmed";
            Student c = new Student();
            c.Name = "ajhfjd";//exception
           // a.ID = 33;//exception
           // a = c + b;//compilation = runtime exception

            x = y;
        }
        public void callAdd()
        {
            int a = 10;
            int b=20;
            Add(a, b);
            
        }
    }
}
