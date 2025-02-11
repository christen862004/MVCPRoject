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
        public void testViewData()
        {
            TestClass c = new TestClass();
            c.ViewData["name"] = "asd";
            c.ViewData["re"] = 11;
            string str = c.ViewData["name"].ToString();
            string str2 = c.ViewBag.name;
        }
    }
    public class TestClass
    {
        int x;//memeory
        public int X//Special type of function
        {
            get { return x; }
            set { x = value; }
        }
                    
        public Dictionary<string, object> ViewData;


        public dynamic ViewBag
        {
            get { return ViewData; }
        }




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
