using Common.DTOs;
//using DBContext.Context;
using Repositories.Repositories;

using Services.Interface;
using Services.Services;
using DBContext;

using Repositories.Entities;
//using Algoritm;
using GoogleMapsApi;

namespace Helper
{
    

    public partial class Form1 : Form
    {
        private readonly IService<PartialDeliveryToPackageDto> _areas;
        private readonly IService<BusinessDayDto> _businessDays;
        private readonly IService<ClientDto> _clients;
        private readonly IService<CollectingPointDto> _collectingPoints;
 
        private readonly IService<EmployeeDto> _employees;
        private readonly IService<OrderDto> _orders;
        private readonly IService<PackageDto> _packages;
        private readonly IService<PartialDeliveryDto> _partialDeliveris;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //CollectingPointRepository repository = new CollectingPointRepository(new PackageProject3Context());
            //CollectingPointService l =new CollectingPointService(repository,null);

            //algorithm algorithm = new algorithm(null,null,null,l,null,null,null,null,null);
           // int q = await algorithm.ezer();
            //MessageBox.Show(q.ToString());
         //var q= await  algorithm.RouteRequestBetween2Points();
          //  dataGridView1.DataSource = q.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int
            //var result = Algorithms<int>.Dijkstra(new GraphInt(), 0);
            //MessageBox.Show(result[6 - 1].ToString());
            //Console.WriteLine(result[6 - 1]);
            //collecting point
            //var result = Algorithms<CollectingPointDto>.Dijkstra(new GraphInt(), 0);
            //MessageBox.Show(result[6 - 1].ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Moce moce=new Moce();
            //GraphListCollectingPoint g = new GraphListCollectingPoint(moce.collectingPoints);
            //ictionary<Vertice, double> result = Algorithms<Vertice>.Dijkstra(g, g.GetVertices()[0]);
            //Dictionary<CollectingPointDto, double> result1 = algorithmVertice.Dijkstra(g, g.GetVertices()[0]);
            //string s="";
            //foreach (var item in result1)
            //{
            //    s += item.Value.ToString()+" ";
            //}
            //MessageBox.Show(s);
            //MessageBox.Show(result.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Moce moce = new Moce();
            //algorithmDijkstra a = new algorithmDijkstra(moce.collectingPoints,moce.employees,moce.packages);
            //Dictionary<GraphNode<CollectingPointDto>, int> result = null;// a.Dijkstra( a.Graph.Nodes[0]);
            //string s = "";
            //foreach (var item in result)
            //{
            //    s += '\n' + " collectingPointId: "+item.Key.Value.CollectingPointId + " weight: " + item.Value;
            //}
            //MessageBox.Show(s);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Moce moce = new Moce();
            //algorithmDijkstra a = new algorithmDijkstra(moce.collectingPoints,moce.employees,moce.packages);
            //List<GraphNode<CollectingPointDto>> result = null;// a.Dijkstra( a.Graph.Nodes[0], a.Graph.Nodes[3]);
            //string s = "";
            //foreach (var item in result)
            //{
            //    s += '\n' + " collectingPointId: " + item.Value.collectingPointIndex;
            //}
            //MessageBox.Show(s);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Moce moce = new Moce();
            //algorithmDijkstra a = new algorithmDijkstra(moce.collectingPoints, moce.employees, moce.packages);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //button7.Enabled = false;
            //Moce moce = new Moce();
            //algorithmDijkstra a = new algorithmDijkstra(moce.collectingPoints, moce.employees, moce.packages);
            //OptionMax o = a.buildManyOptions(new TimeOnly(8, 0, 0), new TimeOnly(10, 30, 0));
            //MessageBox.Show(o.ToString());
            //saveResult(o);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            
            //var result=MyGoogleMapsApi.GetLocation("רחוב רוזובסקי 8, פתח תקווה, ישראל");
            //MessageBox.Show(result.ToString());
        }

        //private void saveResult(OptionMax o)
        //{
        //    foreach (var employee in o.TheBestOption.Keys)
        //    {

        //        for (int i = 0; i < o.TheBestOption[employee].Route.Count; i++)
        //        {
        //            var col = o.TheBestOption[employee].Route[i];

        //            PartialDeliveryDto partialDelivery = new PartialDeliveryDto();
        //            partialDelivery.EmployeeId = employee.EmployeeId;
        //            partialDelivery.CollectingPointId = col.Value.CollectingPointId;
        //            partialDelivery.IndexOfDelivery = i;
        //            //partialDelivery.DeliveryId =;
        //            //partialDelivery
        //        }
        //    }
        //}

        //private void button8_Click(object sender, EventArgs e)
        //{
        //    string result = MyGoogleMapsApi.main();
        //    MessageBox.Show(result);
        //}

        ////    private void button9_Click(object sender, EventArgs e)
        //    {
        //        string result = MyGoogleMapsApi.main1();
        //        MessageBox.Show(result);
        //    }

        //    private void button10_Click(object sender, EventArgs e)
        //    {
        //        var result = MyGoogleMapsApi.GetDrivingDistance("Bney Brak,Israel","Elad");
        //        MessageBox.Show(result.kilometer.ToString());
        //    }

        //    private void button11_Click(object sender, EventArgs e)
        //    {
        //        var result1 = MyGoogleMapsApi.GetLocation("Arye Ben Eli'ezer Street, Petach Tikva,Israel");
        //        var result2 = MyGoogleMapsApi.GetLocation("Yosef Rozovski Street, Petach Tikva,Israel");
        //        //MessageBox.Show("x:"+result.Item1.ToString()+" y:"+result.Item2.ToString());
        //        MessageBox.Show(algorithmDijkstra.DistanceBetweenPoints(
        //          result1.Item1,
        //           result1.Item2,
        //           result2.Item1,
        //          result2.Item2).ToString());
        //    }
    }
}