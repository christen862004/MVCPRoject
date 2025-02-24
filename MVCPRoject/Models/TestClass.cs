namespace MVCPRoject.Models
{
    //DIP
    interface ISort
    {
        void Sort(int[] arr);
    }
    class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {
            //........
        }
    }
    class SelectionSort:ISort
    {
        public void Sort(int[] arr)
        {
            //........
        }
    }
    class ChrisSort : ISort
    {
        public void Sort(int[] arr)
        {
            throw new NotImplementedException();
        }
    }
    //DIP
    //DInject
    class MyList //high level
    {
        int[] myArr;
        ISort sortAlg;  //abstartcion interface
        public MyList(ISort isort)  //send object from class implement construction (injection)
        {
            sortAlg = isort;
        }
        public void SortArr()//inject mehothi
        {
            sortAlg.Sort(myArr);
        }
    }

    class testList
    {
        public void test()
        {
            //main
            //container  ==>interf ==>class
            MyList list = new MyList(new BubbleSort());
            MyList list2 = new MyList(new SelectionSort());
            MyList list3 = new MyList(new ChrisSort());
        }
    }












    interface IREpository
    {
        void GetAll();
        void GEtByID();
        void add();
    }
    class DeptREpo : IREpository
    {
        public void GetAll()
        {
            //throw new NotImplementedException();
        }

        public void GEtByID()
        {
            //throw new NotImplementedException();
        }
        public void add()
        {

        }
    }

    class contoller
    {
        public void TestRepo(IREpository dept)
        {
            dept.add();
        }
    }
















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
