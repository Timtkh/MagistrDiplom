namespace WfDbApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext()) {
                //db.Cars.Add(new Car() { Company = "Tesla", Model = "Y",  Count = 10, Contry = "USA", Year = "2020", Money =  100000});

                //db.SaveChanges();
            }
        }
    }
}