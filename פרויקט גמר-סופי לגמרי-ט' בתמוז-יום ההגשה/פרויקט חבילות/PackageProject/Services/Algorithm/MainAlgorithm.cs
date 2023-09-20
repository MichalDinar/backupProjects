

using Common.DTOs;
using Services.Interface;

namespace Services.Algoritm
{
    public class MainAlgorithm
    {
        private readonly float RADIOUS = 3f;//מרחק הרדיוס של כל עובד
        private readonly int NUMOFOPTION = 2000;//מס' האופציות האפשריות שמגרילים
        public WeightedGraph<CollectingPointDto> Graph { get; set; }//הגרף
        public List<CollectingPointDto> LstCollectingPoints { get; set; }//רשימת הקודקודים
        public List<EmployeeDto> LstEmployees { get; set; }//רשימת העובדים
        public List<PackageDto> LstPackages { get; set; }//רשימת החבילות
        public BusinessDayDto CurrentBusinessDay { get; set; }

        public  IService<CollectingPointDto> _collectingPoints;
        public  IService<BusinessDayDto> _businessDays;

        //רשימה של כל האופציות האפשריות של עובדים
        //כל איבר ברשימה -מראה לכל עובד מה המסלול שהוא עושה 
        public List<Dictionary<EmployeeDto,OptionToEmployee>> ListInterations { get; set; }
        public static DistanceType [,] DistansesCol { get; set; }//מטריצת מרחקים בין נקודות איסוף
        public MainAlgorithm(List<CollectingPointDto> lstCollectingPoints, List<EmployeeDto> lstEmployees
            , List<PackageDto> lstPackages, IService<CollectingPointDto> collectingPoints)//פעולה בונה של האלגוריתם
        {
            _collectingPoints = collectingPoints;
            Graph = new WeightedGraph<CollectingPointDto>();//בונה גרף
            this.LstCollectingPoints =lstCollectingPoints.Where(x => x.State==1).ToList();
            this.LstEmployees = lstEmployees.Where(e=>e.UserLevel==1).ToList();
            this.LstPackages = lstPackages.Where(p => p.State != (int?)PackageStatusEnum.Delivered).ToList();
             
           

            
            //TODO 2:
            //OpenBusinessDayAsync();


           
            initializationOfVertices();// אתחול הקודקודים בגרף-נקודות איסוף, נקודות של חבילות-יעד ומקור וכן אתחול כל חבילה היכן היא יושבת, ועדכון הנקודת איסוף שם היא נמצאת

            inintCollectingPointAndPackages();

            initEmployees();
            //TODO 1:
            saveDistance(); //שמירת המרחקים בק''מ מכל נקודה לכל נקודה
            // m*m
            
            BuildDenseGraph();//בנית גרף- החיבור הקשתות
            //n*n

            GetPointsWithinRadius();//פונקציה שקובעת לכל עובד מי הנקודות שלו לפי מיקומים
            //n*m
            LstEmployees=lstEmployees.Where(p=>p.colectingPointsOfEmployees!=null &&
            p.colectingPointsOfEmployees.Count>0).ToList();
        }

       

        //שמירה במערך את כל המרחקים בין נקודות
        private void saveDistance()//שומרת מרחק -ע''י נוסחה חשבונית
        {
            for (int i=0;i<LstCollectingPoints.Count;i++)
            {
                LstCollectingPoints[i].indexDistance = i;
            }
            int max = LstCollectingPoints.Count;
            DistansesCol =new DistanceType[max, max];

            var t = CalculationTimeBetweenCollectingPoints();
            Task.WaitAll(t);
            TimeSpan[,] times = t.Result;
            

            for (int i = 0; i < LstCollectingPoints.Count; i++)
            {
                for (int j = 0; j < LstCollectingPoints.Count; j++)
                {
                    if (i != j)
                    {
                        DistansesCol[LstCollectingPoints[i].indexDistance, LstCollectingPoints[j].indexDistance] =
                            new DistanceType()
                            {
                                kilometer =
                           DistanceBetweenPoints((double)LstCollectingPoints[i].LocationX, (double)LstCollectingPoints[i].LocationY,
                           (double)LstCollectingPoints[j].LocationX, (double)LstCollectingPoints[j].LocationY)
                            ,
                                time = times[i, j]
                            };
                    }
                    else
                        DistansesCol[LstCollectingPoints[i].indexDistance, LstCollectingPoints[j].indexDistance] =
                             new DistanceType() { kilometer = 0, time = new TimeSpan(0,0,0) };
                }
            }
        }

        private async Task<TimeSpan[,]> CalculationTimeBetweenCollectingPoints()
        {
            TimeSpan[,] times = new TimeSpan[LstCollectingPoints.Count, LstCollectingPoints.Count];

            List<string> destinations=LstCollectingPoints.Select(x => x.Address).ToList();

            for (int i = 0; i < LstCollectingPoints.Count; i++)
            {
                int batchSize = 25;
                for (int k = 0; k < LstCollectingPoints.Count; k +=batchSize)
                {
                    int remaining = LstCollectingPoints.Count - k;
                    int currentBatchSize = remaining < batchSize ? remaining : batchSize;
                    List<string> batch = LstCollectingPoints.Select(x => x.Address).ToList().Skip(k).Take(currentBatchSize).ToList();
                    
                    var task = MyGoogleMapsApi.GetDrivingDistanceTimeMatrix(LstCollectingPoints[i].Address, batch);
                    Task.WaitAll(task);
                    List<TimeSpan> travelTimes = task.Result;
                    for (int j = 0; j < batch.Count; j++)
                    {
                        if (i != j)
                        {
                            times[i, j] = travelTimes[j];
                        }
                    }
                }
                
            }
            return times;
            
            
        }

        //מחשב מרחק בין נקודות ע''י זמן של מפות גוגל ומרחק ע''י המטריצה ששמרה מרחק
        public static DistanceType googleMapsDistance(CollectingPointDto c1, CollectingPointDto c2)
        {
            if (c1 == c2)
                return new DistanceType() { kilometer = 0, time = new TimeSpan() };
            return DistansesCol[c1.indexDistance, c2.indexDistance];
            //new DistanceType() { kilometer = DistansesCol[c1.indexDistance, c2.indexDistance].kilometer;
            //    , time =MyGoogleMapsApi.GetDrivingDistanceTime(c1.Address,c2.Address)};
           
        }
       
        //לקבוע לכל עובד באיזה נקודה הוא יושב בתחילת האינטרציה- אם זה באמצע יום עבודה-אז איפה שישב בסוף האינטרציה הקודמת
        public void employeeInInitialCollectionPoint()
        {
           
            Random random = new Random();
            int i = 0;
            List<GraphNode<CollectingPointDto>> lstCollectingPointWithPackages;
            foreach (var employee in LstEmployees)
            //לכל עובד מרנדמים בתוך הנקודות שבאזורו שיש שם חבילות נקודה כל שהיא
            {
                //תביא לי נקודה שיש שם חבילה
                lstCollectingPointWithPackages = employee.colectingPointsOfEmployees.Where(c => c.Value.PackagesInCollectingPoint.Count > 0).ToList();
                if (lstCollectingPointWithPackages.Count > 0)
                {
                    i = random.Next(lstCollectingPointWithPackages.Count - 1);
                    employee.CurrentLocation = lstCollectingPointWithPackages[i];
                }   
                else
                {
                    i = random.Next(employee.colectingPointsOfEmployees.Count-1);
                    employee.CurrentLocation = employee.colectingPointsOfEmployees[i];
                }
            }
        }
        //TODO buildOptions:
        //פונקציה שבונה הרבה אופציות אפשריות ומחזירה את הטובה מבניהם
        public OptionMax buildManyOptions(DateTime open, DateTime close)
        {
            int count= 1;


            employeeInInitialCollectionPoint();//קביעה מחדש איפה העובדים יושבים בתחילת היום
            Interation interation =new Interation(open, close,LstEmployees,Graph,DistansesCol);
            double max = markOfInteration(/*interation.Options*/);

            OptionMax option = new OptionMax();
            option.TheBestOption = interation.Options;
            keepStatusOfPackages(option);
            double mark;
            ListInterations = new List<Dictionary<EmployeeDto, OptionToEmployee>>();
            for (int i = 0; i < NUMOFOPTION; i++)
            {
                initInteration(open);//איתחול כללי של אופציה חדשה (איפוס נתונים מאופציות קודמות
                employeeInInitialCollectionPoint();//קביעה מחדש איפה העובדים יושבים בתחילת היום
                interation = new Interation(open, close,LstEmployees,Graph,DistansesCol);
                ListInterations.Add(interation.Options);//לא צריך
                mark = markOfInteration();
                if (mark == max)
                    count++;
                if(mark>max)
                {
                    max=mark;
                    option.TheBestOption = interation.Options;
                    keepStatusOfPackages(option);
                    count = 1;
                }
            }
            option.Count = count;
            option.Mark = max;
            return option;
        }

        private void keepStatusOfPackages(OptionMax option)
        {
            option.StatePackageAfterDay = new Dictionary<int, PackageStatus>();
            foreach (PackageDto package in LstPackages)
            {
                //אם החבילה הגיעה ליעדה
                if (package.Destination == package.CurrentLocation)
                    option.StatePackageAfterDay.Add(package.PackageId, new PackageStatus(PackageStatusEnum.Delivered, 0));
                else
                {
                    //אם החבילה באמצע הדרך
                    if (package.Source != package.CurrentLocation)
                        option.StatePackageAfterDay.Add(package.PackageId, new PackageStatus(PackageStatusEnum.InTransit, package.CurrentLocation.Value.CollectingPointId));
                }
            }
        }

        public void initInteration(DateTime open)
        {
            //מה צריך בכל אינטרציה חדשה לעדכן
            //כל החבילות יושבות בהקודת המקור שלהן
            //כל העובדים יושבים בנקודה הראשונה של המסלול שלהם (אמור להיות כבר פונקציה כזאת
            //איתחול של כל העובדים-אין חבילות
            //איתחול נקודות האיסוף - אין חבילות
            foreach (var colPoint in LstCollectingPoints)
            {
                colPoint.PackagesInCollectingPoint = new List<PackageInCollectingPoint>();
            }
            foreach (var package in LstPackages)
            {
                package.CurrentLocation = package.Source;
                package.Source.Value.PackagesInCollectingPoint.Add(new PackageInCollectingPoint( package,true));
                package.whereToGetOff = null;
            }
            foreach (var employee in LstEmployees)
            {
                employee.Packages = new List<PackageInEmployee>();
                employee.clock = open;
                employee.VerticesToVisit = new List<GraphNode<CollectingPointDto>>();
                
            }
        }
        public double markOfInteration(/*Dictionary<EmployeeDto, OptionToEmployee> option*/)
        {
            //ניקוד לאופציה אפשרית
            //אם קודם עושה את כל האופציות ורק אז מחשב ציון אז ברשימת החבילות מעודכן רק האופציה האחרונה
            double mark = 0;
            foreach (var package in LstPackages)
            {
                double totalTime = DistansesCol[package.Source.Value.indexDistance, package.Destination.Value.indexDistance].kilometer;                  //googleMapsDistance(package.Source.Value, package.Destination.Value);
                double timeRemainWay;
                if (package.Source.Value == package.CurrentLocation.Value)
                    timeRemainWay = totalTime;
                else
                    timeRemainWay = DistansesCol[package.CurrentLocation.Value.indexDistance, package.Destination.Value.indexDistance].kilometer;      //googleMapsDistance(package.CurrentLocation.Value, package.Destination.Value);
                if (totalTime == 0)//כדי שלא יהיה חילוק ב-0
                    totalTime = 1;
                mark += (totalTime - timeRemainWay) / totalTime;

            }
            return mark;
        }

        public void initEmployees()
        {
            foreach (var employee in LstEmployees)
            {
                employee.Packages = new List<PackageInEmployee>();
                employee.colectingPointsOfEmployees = new List<GraphNode<CollectingPointDto>>();
                employee.VerticesToVisit=new List<GraphNode<CollectingPointDto>>();
                employee.clock = new DateTime();
            }
        }


        //בניית גרף של מצב התחלתי---------
        //עובד-להתחל שנמצא בנקודת איסוף הקרובה ביותר אליו
        //חבילה- איפה היא יושבת בתחילה
        //נקודה בגרף- בכל נקודה איזה חבילות יש-לפי הקודם
        public async void initializationOfVertices()//אתחול נקודות איסוף וחבילות-יעד ומקור
        {
            Console.WriteLine("--------------lstCollectingPoint.count1: "+LstCollectingPoints.Count+'\n');
            List<Task<List<CollectingPointDto>>> tasks = new List<Task<List<CollectingPointDto>>>();
            int i = 0;
            CollectingPointDto collectingPointS;
            CollectingPointDto collectingPointD;
            List<PackageDto> packages = LstPackages.Where(p=>p.State== (int?)PackageStatusEnum.Awaiting).ToList();
            foreach (PackageDto package in packages)//הוספה לכל חבילה שבמצב המתנה 2 נקודות 
            {
                collectingPointS = new CollectingPointDto();
                collectingPointD = new CollectingPointDto();
                collectingPointS.LocationX = (decimal)package.SourceLocationX;//  ההמרה בגלל שנקודת איסוף- דצימל וחבילה דצימל ללא סימן שאלה
                collectingPointS.LocationY = (decimal)package.SourceLocationY;
                collectingPointS.Address = package.AddressSource;
                collectingPointS.ColPointType = CollctingPointType.source;//קביעת סוג הנקודה כ- מקור
                collectingPointS.collectingPointIndex = i;
                collectingPointS.State = 1;
                collectingPointS.PackagesInCollectingPoint = new List<PackageInCollectingPoint>();
                collectingPointS.PackageId= package.PackageId;//כיוון שזה לא נקודת איסוף צריך לדעת לאיזה חבילה זה שייך
                i++;
                collectingPointD.LocationX = (decimal)package.DestinationLocationX;
                collectingPointD.LocationY = (decimal)package.DestinationLocationY;
                collectingPointD.Address= package.AddressDestination;
                collectingPointD.ColPointType = CollctingPointType.destination;//קביעת סוג הנקודה כ- יעד
                collectingPointD.collectingPointIndex = i;
                collectingPointD.State = 1;
                collectingPointD.PackageId = package.PackageId;
                collectingPointD.PackagesInCollectingPoint = new List<PackageInCollectingPoint>();
                 i++;

                //הוספת הנקודות איסוף החדשות למסד נתונים
                tasks.Add(  _collectingPoints.AddAsync(collectingPointS));
                Task.WaitAll(tasks.Last());

               tasks.Add(  _collectingPoints.AddAsync(collectingPointD));
                Task.WaitAll(tasks.Last());

                

            }
           
            Console.WriteLine("--------------lstCollectingPoint.count3: " + LstCollectingPoints.Count + '\n');
            List<Task<List<CollectingPointDto>>> tasks1 = new List<Task<List<CollectingPointDto>>>();
            var t=  _collectingPoints.GetAllAsync();
            tasks1.Add(t);
            Task.WaitAll(tasks1.ToArray());
            LstCollectingPoints = await t;
            LstCollectingPoints=LstCollectingPoints.Where(x=>x.State==1).ToList();
           
            
            
        }

        public void inintCollectingPointAndPackages()
        {
            foreach (CollectingPointDto point in LstCollectingPoints)//מכניסה את כל הנקודות איסוף לגרף כקודקודים בגרף
            {
                if (point.ColPointType == CollctingPointType.collectingPoint)
                {
                    point.ColPointType = CollctingPointType.collectingPoint;//קביעת סוג הנקודה כ- נקודת איסוף
                }
                point.PackagesInCollectingPoint = new List<PackageInCollectingPoint>();//איתחול החבילות שיש בנקודה לריק
                Graph.AddNode(point);
                //Graph.Nodes[i].Value.collectingPointIndex = i;
                //i++;
            }
            foreach (PackageDto package in LstPackages)
            {
                GraphNode<CollectingPointDto> s; 
                if (package.State==(int)PackageStatusEnum.InTransit)
                {
                     s =Graph.Nodes.Where(c=>c.Value.CollectingPointId== package.CollectingPointId).First();
                }
                else
                {
                    s = Graph.Nodes.Where(n => n.Value.PackageId == package.PackageId && n.Value.Address == package.AddressSource).First();//לא יודעת אם בטוח-אבל אני צריכה רק אחרי ששמים בגרף את הנקודות המעודכנות-רק אז לשים את החבילות במקומן
                }
                GraphNode<CollectingPointDto> d = Graph.Nodes.Where(n => n.Value.PackageId == package.PackageId && n.Value.Address==package.AddressDestination).First();//לא יודעת אם בטוח-אבל אני צריכה רק אחרי ששמים בגרף את הנקודות המעודכנות-רק אז לשים את החבילות במקומן
                package.CurrentLocation = s;//מעדכנת את החבלה שהיא יושבת כרגע בנקודת איסוף שהרגע נוספה לגרף-נקודת המקור
                package.Source = s; //עידכון הנקודת איסוף שהיא נקודת המקור
                package.Destination = d;//עידכון הנקודת איסוף שהיא נקודת היעד
                s.Value.PackagesInCollectingPoint.Add(new PackageInCollectingPoint(package, true));//הוספה לחבילות שנמצאות בנקודה מקור את החבילה הנוכחית


            }
            
        }
        //פונצקיה שבונה את הגרף ההתחלתי: מקבלת רשימה של עובדים ונקודות איסוף-
        //הפונקציה מעדכנת את הגרף כך ש: כל הנקודות שבאותו אזור מחוברות עם קשתות בינהם-רבים לרבים

        public  void BuildDenseGraph()
        {
            foreach (var employee in LstEmployees)//בדקתי גם אם ברדיוס של העובד- אולי לא צריך את זה
            {
                for (int i = 0; i < this.Graph.Nodes.Count; i++)
                {
                    if (inRadiousLocation(employee, Graph.Nodes[i].Value) == true)
                    {
                        for (int j = i + 1; j < this.Graph.Nodes.Count; j++)
                        {
                            if (inRadiousLocation(employee, Graph.Nodes[j].Value) == true)
                            {
                                //חיבור הגרף -קשת כפולה-קביעת זמן ומרחק
                                Graph.AddEdge(Graph.Nodes[i], Graph.Nodes[j], googleMapsDistance(LstCollectingPoints[i], LstCollectingPoints[j])
                                    , googleMapsDistance(LstCollectingPoints[j], LstCollectingPoints[i]));

                            }
                        }
                    }
                }
            }
        }
       

        //בודק רדיוס לפי מיקום בכדור הארך
        private bool inRadiousLocation(EmployeeDto employee, CollectingPointDto collectingPoint)
        {
            //או להשתמש במערך ששומרים
            double distance = DistanceBetweenPoints((double)employee.LocationX, (double)employee.LocationY
                , (double)collectingPoint.LocationX, (double)collectingPoint.LocationY);

            // אם הנקודה נמצאת ברדיוס של מספר מסוים של ק"מ מהעובד, הוסף אותה לרשימת הנקודות ברדיוס של העובד
            if (distance <= RADIOUS)
                return true;
            return false;
        }
        
        //פונקציה שמחשבת לכל עובד אלו נקודות נמצאות ברדיוס שלו-לפי מיקומים על כדור הארץ
        public  void GetPointsWithinRadius()
        {
            
            // בדוק אילו נקודות נמצאות ברדיוס של מספר ק"מ מכל עובד
            foreach (EmployeeDto employee in LstEmployees)
            {
                // קבל את המיקום של העובד
                Tuple<double, double> workerLocation = new Tuple<double, double>((double)employee.LocationX, (double)employee.LocationY);          //workerLocations[worker];

                foreach (GraphNode<CollectingPointDto> point in Graph.Nodes)
                {
                    // קבל את המיקום של הנקודה
                    Tuple<double, double> pointLocation = new Tuple<double, double>((double)point.Value.LocationX, (double)point.Value.LocationY);  //pointLocations[point];

                    // חשב את המרחק בין העובד לנקודה בק"מ
                    double distance = DistanceBetweenPoints(workerLocation.Item1, workerLocation.Item2, pointLocation.Item1, pointLocation.Item2);

                    // אם הנקודה נמצאת ברדיוס של 3 ק"מ מהעובד, הוסף אותה לרשימת הנקודות ברדיוס של העובד
                    if (distance <= RADIOUS)
                    {
                        employee.colectingPointsOfEmployees.Add(point);
                        
                    }
                }
               
            }


        }

        // פונקציית עזר לחישוב המרחק בין שתי נקודות בק"מ
        public static double DistanceBetweenPoints(double lat1, double lng1, double lat2, double lng2)
        {
            double R = 6371; // רדיוס הארץ בק"מ
            double dLat = deg2rad(lat2 - lat1);
            double dLng = deg2rad(lng2 - lng1);
            double a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) *
                Math.Sin(dLng / 2) * Math.Sin(dLng / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = R * c; // המרחק בק"מ
            return d;
        }

        // פונקציית עזר להמרת מעלות לרדיאנים
        public static double deg2rad(double deg)
        {
            return deg * (Math.PI / 180);
        }


       
        //מכאן קוד ישן-------------------------------------------------------------------------------------------------------------------------------------------------------------
        //מכאן קוד ישן-------------------------------------------------------------------------------------------------------------------------------------------------------------
        //מכאן קוד ישן-------------------------------------------------------------------------------------------------------------------------------------------------------------
        //מכאן קוד ישן-------------------------------------------------------------------------------------------------------------------------------------------------------------

        //הפונקציה מריצה דאקסטרה לכל חבילה וקובעת מה המסלול של החבילה כדי להגיע מהמקור ליעד
        public Dictionary<PackageDto, List<GraphNode<CollectingPointDto>>> FindRoutesToPackages()
        {
            var routes = new Dictionary<PackageDto, List<GraphNode<CollectingPointDto>>>();
            foreach (var package in LstPackages)
            {
                List<GraphNode<CollectingPointDto>> route = null;// Dijkstra(package.Source, package.Destination);
                routes[package] = route;
            }
            return routes;
        }

        //private bool inRadious(EmployeeDto employee, CollectingPointDto collectingPoint)//מחזיר האם העובד והנקודת איסוף הם באותו רדיוס- אזור
        //{
        //    decimal locationX = collectingPoint.LocationX;
        //    decimal locationY = collectingPoint.LocationY;
        //    if (Math.Abs(employee.LocationX - locationX) < RADIOUS && Math.Abs(employee.LocationY - locationY) < RADIOUS)
        //        return true;
        //    return false;
        //}

        //private int GetDistance(GraphNodeT<CollectingPointDto> node1, GraphNodeT<CollectingPointDto> node2)
        //{
        //    return node1.Neighbors[node2];
        //}

        //דאקסטרה שמחזיר את המסלול בגרף מנקודת מקור לנקודת יעד
        //public List<GraphNode<CollectingPointDto>> Dijkstra(GraphNode<CollectingPointDto> start, GraphNode<CollectingPointDto> destination)
        //{
        //    Dictionary<GraphNode<CollectingPointDto>, int> distances = new Dictionary<GraphNode<CollectingPointDto>, int>();
        //    Dictionary<GraphNode<CollectingPointDto>, GraphNode<CollectingPointDto>> previous = new Dictionary<GraphNode<CollectingPointDto>, GraphNode<CollectingPointDto>>();
        //    HashSet<GraphNode<CollectingPointDto>> visited = new HashSet<GraphNode<CollectingPointDto>>();
        //    PriorityQueue<GraphNode<CollectingPointDto>, int> priorityQueue = new PriorityQueue<GraphNode<CollectingPointDto>, int>();
        //    foreach (var nod in Graph.Nodes)
        //    {
        //        distances[nod] = int.MaxValue;
        //    }
        //    distances[start] = 0;
        //    priorityQueue.Enqueue(start, 0);
        //    while (priorityQueue.Count > 0)
        //    {
        //        var current = priorityQueue.Dequeue();
        //        if (visited.Contains(current))
        //        {
        //            continue;
        //        }
        //        visited.Add(current);

        //        foreach (var neighbor in current.Neighbors)
        //        {
        //            int distance = distances[current] + neighbor.Value;
        //            if (distance < distances[neighbor.Key])
        //            {
        //                distances[neighbor.Key] = distance;
        //                previous[neighbor.Key] = current;
        //                priorityQueue.Enqueue(neighbor.Key, distance);
        //            }
        //        }
        //    }
        //    List<GraphNode<CollectingPointDto>> path = new List<GraphNode<CollectingPointDto>>();
        //    GraphNode<CollectingPointDto> node = destination;
        //    while (node != null)
        //    {
        //        path.Add(node);
        //        if (node == start)
        //        {
        //            break;
        //        }
        //        node = previous[node];
        //    }
        //    path.Reverse();
        //    return path;
        //}

        //פונצית דאקסטרה רגילה-עובדת עם ערימה
        //public Dictionary<GraphNode<CollectingPointDto>, int> Dijkstra(GraphNode<CollectingPointDto> start)
        //{
        //    Dictionary<GraphNode<CollectingPointDto>, int> distances = new Dictionary<GraphNode<CollectingPointDto>, int>();
        //    HashSet<GraphNode<CollectingPointDto>> visited = new HashSet<GraphNode<CollectingPointDto>>();
        //    PriorityQueue<GraphNode<CollectingPointDto>, int> priorityQueue = new PriorityQueue<GraphNode<CollectingPointDto>, int>();

        //    foreach (var node in Graph.Nodes)
        //    {
        //        distances[node] = int.MaxValue;
        //    }

        //    distances[start] = 0;
        //    priorityQueue.Enqueue(start, 0);

        //    while (priorityQueue.Count > 0)
        //    {
        //        var current = priorityQueue.Dequeue();
        //        if (visited.Contains(current))
        //        {
        //            continue;
        //        }
        //        visited.Add(current);
        //        foreach (var neighbor in current.Neighbors)
        //        {
        //            int distance = distances[current] + neighbor.Value;
        //            if (distance < distances[neighbor.Key])
        //            {
        //                distances[neighbor.Key] = distance;
        //                priorityQueue.Enqueue(neighbor.Key, distance);
        //            }
        //        }
        //    }
        //    return distances;
        //}
    }
}
