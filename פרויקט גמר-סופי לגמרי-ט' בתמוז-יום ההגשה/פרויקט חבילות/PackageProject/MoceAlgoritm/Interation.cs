using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repositories.Entities;
using AutoMapper.Configuration.Conventions;

namespace Algoritm
{
    public class Interation
    {

        public WeightedGraph<CollectingPointDto> Graph { get; set; }
        public List<CollectingPointDto> LstCollectingPoints { get; set; }
        public List<EmployeeDto> LstEmployees { get; set; }
        public List<PackageDto> LstPackages { get; set; }
        public Dictionary<EmployeeDto,OptionToEmployee> Options { get; set; }
        public  double[,] DistansesCol { get; set; }//מטריצת מרחקים בין נקודות איסוף

      

        public Interation(DateTime open,DateTime close,List<EmployeeDto> lste, WeightedGraph<CollectingPointDto> graph, double[,] distancesCol)
        {
            DistansesCol = distancesCol;
            Graph = graph;
            LstEmployees = lste;
            Options = new Dictionary<EmployeeDto, OptionToEmployee>();
            initOptions(open);
            //TODO interation:
            //n- עובדים
            //m- נקודות איסוף
            //p -חבילותע
            CalculateVerticesToVisitToEmployee(open, close);//O(n*m*   mlog(m) אולי-  )
            moves();//O(n*m) אולי  גם *P של החבילות, אבל לא בטוח כי בדר''כ כלל מספר קטן , ורק כל החבילות ביחד יהיו שוות יחדיו לפי
            
           
        }

        


        //לאתחל אופציה אפשרית לעובדים
        public void initOptions(DateTime open)
        {
            foreach (EmployeeDto employee in LstEmployees)
            {
                Options.Add(employee, new OptionToEmployee());
            }
        }
        //אינטרציה
        
        //להגריל לכל עובד את הנקודות שהוא יעבור בהם
        //צריך לדאוג שלמקור לא יוכל לבוא יותר מפעם אחת-כי לא מתווספות שם חבילות שלא היו קודם
        public void CalculateVerticesToVisitToEmployee(DateTime beginTime, DateTime endTime)
        {
            EmployeeDto employee;
            for (int i=0;i<LstEmployees.Count;i++) //עובר על כל העובדים
            {
               employee= LstEmployees[i];
                employee.clock = beginTime;//אןלי צריך//////////////////////////
                DateTime currentTime = (DateTime)employee.clock;//הזמן הנוכחי של העובד
                var currentLocation = employee.CurrentLocation;//המיקום הנוכחי של העובד
                employee.VerticesToVisit.Add(employee.CurrentLocation);//הוספת הקודקוד לרשימת הקודקודים שהעובד יבקר בהם
                Options[employee].StartTime[employee.VerticesToVisit.Count - 1] = beginTime;//בתחילת יום הולך לנקודה הראשונה
                //הנקודה הראשונה שהעובד צריך לבקר בה זה הנקודה שהוא נמצא בה כרגע
                //אולי הוספתי במקום אחר-לבדוק
                int countColOfEmployee = employee.colectingPointsOfEmployees.Count;//מספר הנקודות איסוף
                var collectingPoints = employee.colectingPointsOfEmployees;//הרישמה של הקודקודים ששיכים לעובד
                if (employee.CurrentLocation.Value.ColPointType==CollctingPointType.source)//אם אתה במקור תוציא אותו מהרשימה (כאילו
                {
                    int indx = collectingPoints.IndexOf(currentLocation);
                    ExchangeWithLast<GraphNode<CollectingPointDto>>(collectingPoints, indx);
                    countColOfEmployee--;
                }

                //כל עוד ישנם נקודות איסוף שלא נבדקו וגם הזמן של העובד עדיין לא הגיע לזמן סיום
                
                while (currentTime< endTime && countColOfEmployee > 0)
                {
                    var randomIndex = new Random().Next(countColOfEmployee);//מרנדמים נקודה איסוף
                    var collectingPoint = collectingPoints[randomIndex];
                    if (collectingPoint == currentLocation)
                    {
                        if (countColOfEmployee == 1)
                            break;
                        continue;
                    }
                        
                    var travelTime = currentLocation.Neighbors[collectingPoint].time;//הזמן שצריך כדי ללכת לנקודה הבאה
                    //מוסיפים לזמן העכשוי של העובד את הזמן החדש כדי להגיע לנקודה המרונדמת
                    var arrivalTime = currentTime.Add(travelTime);

                    //אם אפשר להוסיף ועדיין לא יעבוד זמן הסיום- אז מוסיפים את הנקודה לרשימת הנקודות שבהם העובד צריך לבקר
                    //וגם מעדכנים את הזמן של העובד, מעדכנים את הנקודה הנוכחית שבה העובד נמצא, ומסירים את נקודה מהרשימה
                    if (arrivalTime.CompareTo(endTime) < 0)
                    {
                        //אם החלטת ללכת למקור, או שלקחת חבילה או שלא -אין מה לנסות פעם נוספת כי לא יגיעו עוד חבילות
                        //צריך לעשות את זה גם בנקודה הראשונה אם זה מקור
                        if(collectingPoint.Value.ColPointType==CollctingPointType.source)
                        {
                            ExchangeWithLast<GraphNode<CollectingPointDto>>(collectingPoints, randomIndex);
                            countColOfEmployee--;
                        }
                        //מוסיפה לעובד נקודהה שבא יבקר
                        employee.VerticesToVisit.Add(collectingPoint);
                        //מעדכנת את השעון של העובד
                        //צריך שהשעון של העובד יהיה timeonly
                        //והזמן שמחזיר מהמפות גוגל יהיה time span
                        currentLocation = collectingPoint;//צריך להשתנות באמת--------------------------------------------------
                        Options[employee].StartTime[employee.VerticesToVisit.Count-1] = arrivalTime;
                        currentTime = arrivalTime;
                        //employee.weights.Add(new TimeOnly(0, travelTime));//שומרת את המרחקים כל פעם מהנקודה הנוכחית להבאה
                       

                    }
                    else
                    {
                        ExchangeWithLast<GraphNode<CollectingPointDto>>(collectingPoints, randomIndex);
                        countColOfEmployee--;
                    }
                }
                //מעדכנים בחזרה שהעובד יושב עכשיו בנקודה הראשונה
                //והזמן הוא הזמן ההתחלתי
                employee.CurrentLocation = employee.VerticesToVisit.First();
                employee.clock = beginTime;
            }
        }
        public void ExchangeWithLast<T>(List<T> list, int index)
        {
            if (list == null || index < 0 || index >= list.Count)
            {
                throw new ArgumentException("Invalid argument");
            }

            int lastIndex = list.Count - 1;
            T temp = list[index];
            list[index] = list[lastIndex];
            list[lastIndex] = temp;
        }
       

        //בלולאה כל פעם לקחת עובד שיגיע לנקודה הבאה שלו בזמן הכי קרוב
        public void moves()
        {
            EmployeeDto employee;
            foreach (var emp in LstEmployees)
            {
                Options[emp].Route.Add(emp.VerticesToVisit.First());

                Options[emp].StatusOfPackagesInCollectingPoint.Add(Options[emp].Route.Count - 1, new PackageAssignment());

                //קובעת לכל חבילה האם העובד ייקח או יוריד אותה
                decidingWhichPackagesToDownloadAndWhichNotTo(emp);
            }
            int countEmployees=LstEmployees.Count;
            //כל עובד ישנם עובדים שלא סימו עדיין לבקר בכל הנקודות שהם צריכים לבקר בהם
            while(countEmployees>0)//שוב-אסור באמת למחוק
            {
                //מחזירים מי העובד שהזמן הנוכחי שלו+ הזמן לנקודה הבאה=לזמן הכי קרוב לזמן העכשוי
                int indx= earlyEmployee();
                if (indx == LstEmployees.Count)
                    break;
                employee = LstEmployees[indx];
                
                DateTime clock = (DateTime)employee.clock;
                //להוסיף לזמן את הזמן של הנקודה הבאה
                employee.clock = clock.Add(employee.VerticesToVisit.First().Neighbors[employee.VerticesToVisit[1]].time);

                //מסירים את הנקודה הנ''ל מהרשימה של הנקודות שהעובד צריך לבקר בהם
                employee.VerticesToVisit.Remove(employee.VerticesToVisit.First());

                //לקבוע את הנקודה הנוכחית לנקודה הראשונה מבין הנקודות שהעובד צריך לבקר בהם
                employee.CurrentLocation = employee.VerticesToVisit.First();

                Options[employee].Route.Add(employee.VerticesToVisit.First());

                Options[employee].StatusOfPackagesInCollectingPoint.Add(Options[employee].Route.Count-1, new PackageAssignment());

                //אם עכשיו מחקת את הנקודה האחרונה שהעובד הזה צריך לבקר- אז הסר אותו
                
                if(employee.VerticesToVisit.Count==1)
                {
                    ExchangeWithLast<EmployeeDto>(LstEmployees, indx);
                    countEmployees--;
                }
                  
                //קובעת לכל חבילה האם העובד ייקח או יוריד אותה
                decidingWhichPackagesToDownloadAndWhichNotTo(employee);
            }
        }
        //מוצאת ומחזירה מי העובד הבא שעכשיו צריך להתקדם פיזי
        public int earlyEmployee()
        {
            DateTime min = DateTime.MaxValue;
            int employeeMin = LstEmployees.Count;// LstEmployees.First();

            EmployeeDto employee;
            for (int i = 0; i < LstEmployees.Count; i++)
            {
                 employee = LstEmployees[i];
                if (employee.VerticesToVisit.Count <= 1)//בגלל שלא מוחקים באמת זה מסתבך-צריך לחשוב על פיתרון יותר טוב
                    continue;
                //בדיקה האם הזמן עכשיו ועוד הזמן הגעה עד הנקודה הבאה מוקדם יותר מהמינימלי
                DateTime clock = (DateTime)employee.clock;
                DateTime time = clock.Add(employee.VerticesToVisit.First().Neighbors[employee.VerticesToVisit[1]].time);
                if (time < min)
                {
                    employeeMin = i;
                    min = time;
                }
            }
            return employeeMin;
        }
        //להעביר את העובד לנקודה הבאה-פיזי
        //להחליט איזה חבילות להוריד ואיזה חבילות לקחת
        public void decidingWhichPackagesToDownloadAndWhichNotTo(EmployeeDto employee)
        {
            //בדיקה עבור החבילות שנמצאות אצל העובד-מה להוריד
            foreach (var packageInEmployee in employee.Packages)
            {
                if (packageInEmployee.IsExist == false)
                    continue;
                //לשמור לכל חבילה שהלקוח לוקח איתו-מה הנקודה מבין הנקודות שהוא עתיד להגיע אליהן
                //תקרב את החבילה במקסימום לכיוון היעד-במרחק-וכך הבדיקה הבאה תתבצע בקלות
                if(packageInEmployee.package.whereToGetOff==employee.CurrentLocation)
                {
                    //מוסיפה לנקודה בגרף את החבילה הזאת- החבילה ירדה
                    employee.CurrentLocation.Value.Packages.Add(new PackageInCollectingPoint(packageInEmployee.package,true));
                    //מעדכנת את החבילה -שכעת היא יושבת בנקודה זו
                    packageInEmployee.package.CurrentLocation = employee.CurrentLocation;
                    //מסירה את החבילה מהעובד
                    packageInEmployee.IsExist= false;
                    //מאפסת -איפה החבילה צריכה לרדת-כי היא  ירדה עכשיו
                    packageInEmployee.package.whereToGetOff = null;
                    //מעדכן את האופציה שעובד זה בנקודה זו מוריד את החבילה הזאת
                    Options[employee].StatusOfPackagesInCollectingPoint
                        [Options[employee].Route.Count-1].PackagesDownloaded.Add(packageInEmployee.package);
                }
            }
            double distance;
            //בדיקה עבור חבילות שנמצאות בנקודת איסוף שלשם הגיעה עכשיו העובד-מה לקחת
            foreach (var packageInColPoint in employee.CurrentLocation.Value.Packages)
            {
                if (packageInColPoint.IsExist == false)
                    continue;
                //חיפוש האם יש נקודה שהמרחק שלה יהיה קטן יותר ליעד מאשר
                //המרחק בין איפה שעכשיו החבילה יושבת ליעד

                double min = DistansesCol[employee.CurrentLocation.Value.indexDistance, packageInColPoint.package.Destination.Value.indexDistance];   //MainAlgorithm.googleMapsDistance(employee.CurrentLocation.Value,packageInColPoint.package.Destination.Value).kilometer;
                GraphNode<CollectingPointDto> minColPoint = employee.CurrentLocation;
                //עובד על כל הנקודות ומחפש את הנקודה שתביא  למרחק המינימלי בין החבילה ליעד
                foreach (GraphNode<CollectingPointDto> colPoint in employee.VerticesToVisit)
                {
                    distance = DistansesCol[colPoint.Value.indexDistance, packageInColPoint.package.Destination.Value.indexDistance];                //MainAlgorithm.googleMapsDistance(colPoint.Value, packageInColPoint.package.Destination.Value).kilometer;
                    //רק אם המרחק יותר קטן וגם רק אם זה נקודת איסוף- אחרת אי אפשר להוריד לשם חבילות
                    if (distance<min && (
                        colPoint.Value.ColPointType==CollctingPointType.collectingPoint)||
                         packageInColPoint.package.Destination==colPoint)
                    {
                        minColPoint = colPoint;
                        min = distance;
                    }
                }
                //אם באמת יש חבילה כזאת-שתקדם יותר את החבילה- אז נשלח את החבילה עם העובד-העובד יעלה את החבילה
                if(minColPoint!=employee.CurrentLocation )
                {
                    //מעלה-מוסיפה לעובד את החבילה
                    employee.Packages.Add(new PackageInEmployee( packageInColPoint.package,true));
                    //כעת אין לחבילה מיקום-היא זזה אם העובד
                    packageInColPoint.package.CurrentLocation = null;
                    //מסירה מרשימת החבילות שנמאות בנקודה-את החבילה הזאת
                    packageInColPoint.IsExist= false;
                    //מעדכנת את החבילה איפה היא תצטרך לרדת(לפי הנקודה שהכי מקרבת כפי החיפוש לעיל
                    packageInColPoint.package.whereToGetOff = minColPoint;
                    //מעדכנת את האופציה- שלעובד כאשר הוא בנקודה זו אז- החבילות שהוא לוקח זה גם חבילה זו
                    Options[employee].StatusOfPackagesInCollectingPoint[Options[employee].Route.Count - 1]
                        .PackagesTaken.Add(packageInColPoint.package);
                }
            }
        }
        
        //לכתוב לכל חבילה בנקודה-באיזה זמן היא נלקחה ועד סוף האופציה לאיזה נקודה היא תגיע   
        //בשביל שאם אחר כך יבוא עובד שיוכל עד סוף האופציה להביא לנקודה שיותר מקרבת ליעד אז עדיף שהוא יקח אותה ולא העובד הקודם
        //במהלך הבנייה של האופציה צריך לשמור את האופציה האפשרית - לשמור לכל עובד רשימה של נקודות איסוף , ולכל נקודה איזה חבילות להוריד, ואיזה לקחת
        //התחברות לגוגל מאפ
        //public int googleMapsDistance(GraphNode<CollectingPointDto> c1, GraphNode<CollectingPointDto> c2)
        //{
        //    //return moce.weights[(int)c1.Value.LocationX, (int)c2.Value.LocationX];
        //    //צריך או להוסיף כתובת לנקודת איסוף או לבדוק אם אפשר לקבל מיקום במקום כתובת
        //    string origin = c1.Value.Address;// LocationX + "," + c1.Value.LocationY;
        //    string destination = c2.Value.Address;// .LocationX + "," + c2.Value.LocationY;
        //    var result = MyGoogleMapsApi.GetDrivingDistance(origin, destination, Type.time);
        //    if (result.Last() == 's')
        //        result = result.Substring(0, result.Length - 5);
        //    else
        //        result = result.Substring(0, result.Length - 4);
        //    return int.Parse(result);
        //}



        //מה עדיף-להגריל מראש את כל הנקודות שהעובד ילך בהם באינטרציה הקורובה -ואז יכול להיות שלא יעשה כלום בנקודה הזאת- 
        //אבל יוכל לקחת חבילה רק אם יקדם אותה באינטרציה הזאת
        //או להגריל בכל פעם את הנקודה הבאה אבל לא ידע אם עדיף לו לקחת חבילה
    }
}
public static class TimeOnlyExtensions
{
    public static TimeSpan ToTimeSpan(this TimeOnly time)
    {
        return new TimeSpan(time.Hour, time.Minute, time.Second);
    }
}
