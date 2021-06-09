using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulpep.NotificationWindow;
using System.Drawing;

namespace Kurs_Oil
{
    public class Reg
    {
        public bool Button_Reg(string Login, string Password, string SName, string FName, string MName)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.BodyColor = Color.LightPink;

            gr691_tkpEntities db = new gr691_tkpEntities();
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(SName) || string.IsNullOrWhiteSpace(FName))
            {
                popup.ContentText = "Ключевые поля не заполнены";
                popup.Popup();
                return false;
            }
            else
            {
                if (db.K_Users.Select(item => item.Login).Contains(Login))
                {
                    popup.ContentText = "Логин уже существует в системе";
                    popup.Popup();
                    return false;
                }
                else
                {
                    K_Users k_Users = new K_Users();
                    K_Role k_Role = new K_Role();
                    k_Users.Login = Login;
                    k_Users.Password = Password;
                    k_Users.LastName = SName;
                    k_Users.FirstName = FName;
                    k_Users.MiddleName = MName;
                    k_Users.FK_Role_Id = 2;

                    db.K_Users.Add(k_Users);
                    db.SaveChanges();

                    popup.ContentText = "Вы успешно зарегистрировались";
                    popup.Popup();
                }
            }
            return true;
        }
    }
}