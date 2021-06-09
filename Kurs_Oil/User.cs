using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulpep.NotificationWindow;

namespace Kurs_Oil
{
    class Result
    {
        public static double RAVG = 0;
        public static double RCost = 0;
        public static double RL = 0;
        public static double RDist = 0;
    }
    public class User
    {
        public bool Button_EnterAVG(string Filled, string Passed)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.BodyColor = Color.LightPink;

            gr691_tkpEntities db = new gr691_tkpEntities();
            if (string.IsNullOrWhiteSpace(Filled) || string.IsNullOrWhiteSpace(Passed))
            {
                popup.ContentText = "Ключевые поля не заполнены";
                popup.Popup();
                return false;
            }
            else
            {
                K_AVGCalculations avg = new K_AVGCalculations();
                Result.RAVG = Convert.ToDouble(Filled) / Convert.ToDouble(Passed) * 100; 
                
                avg.FK_User_Id = Idd.Id;
                avg.Filled = Convert.ToDouble(Filled);
                avg.Passed = Convert.ToDouble(Passed);
                avg.Results = Result.RAVG;

                db.K_AVGCalculations.Add(avg);
                db.SaveChanges();
            }
            return true;
        }
        public bool Button_EnterCost(string Distance, string Consuption, string typef)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.BodyColor = Color.LightPink;

            gr691_tkpEntities db = new gr691_tkpEntities();
            if (string.IsNullOrWhiteSpace(Distance) || string.IsNullOrWhiteSpace(Consuption) || string.IsNullOrWhiteSpace(typef))
            {
                popup.ContentText = "Ключевые поля не заполнены";
                popup.Popup();
                return false;
            }
            else
            {
                int tf = Convert.ToInt32(typef);
                K_CostCalculations cost = new K_CostCalculations();
                K_TypeFuel type = db.K_TypeFuel.FirstOrDefault(i => i.Type_Id == tf);
                Result.RL = Convert.ToDouble(Distance) / 100 * Convert.ToDouble(Consuption);
                Result.RCost = Result.RL * Convert.ToDouble(type.Price);

                cost.FK_User_Id = Idd.Id;
                cost.Distance = Convert.ToDouble(Distance);
                cost.Consuption = Convert.ToDouble(Consuption);
                cost.FK_Type_Id = tf;
                cost.ResultsL = Result.RL;
                cost.ResultsC = Result.RCost;

                db.K_CostCalculations.Add(cost);
                db.SaveChanges();
            }
            return true;
        }
        public bool Button_EnterDist(string ConsuptionDist, string FilledDist)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.BodyColor = Color.LightPink;

            gr691_tkpEntities db = new gr691_tkpEntities();
            if (string.IsNullOrWhiteSpace(ConsuptionDist) || string.IsNullOrWhiteSpace(FilledDist))
            {
                popup.ContentText = "Ключевые поля не заполнены";
                popup.Popup();
                return false;
            }
            else
            {
                K_DistanceCalculations dist = new K_DistanceCalculations();
                Result.RDist = Convert.ToDouble(FilledDist) / Convert.ToDouble(ConsuptionDist) * 100;

                dist.FK_User_Id = Idd.Id;
                dist.Consuption = Convert.ToDouble(ConsuptionDist);
                dist.Filled = Convert.ToDouble(FilledDist);
                dist.Results = Result.RDist;

                db.K_DistanceCalculations.Add(dist);
                db.SaveChanges();
            }
            return true;
        }
    }
}