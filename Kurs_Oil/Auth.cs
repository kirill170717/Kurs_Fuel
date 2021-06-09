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
    class Idd
    {
        public static int Id = 0;
    }
    public class Auth
    {
        public bool Button_Auth(string Login, string Password)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.BodyColor = Color.LightPink;

            gr691_tkpEntities db = new gr691_tkpEntities();
            K_Users k_Users = db.K_Users.FirstOrDefault(i => i.Login == Login);
            K_Role k_Role = new K_Role();
            
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
            {
                popup.ContentText = "Ключевые поля не заполнены";
                popup.Popup();
                return false;
            }
            else if (k_Users != null)
            {
                if (k_Users.Login == Login && k_Users.Password == Password)
                {
                    if (k_Users.FK_Role_Id == 1)
                    {
                        Administrator adm = new Administrator();
                        adm.Show();
                        return true;

                    }
                    else if (k_Users.FK_Role_Id == 2)
                    {
                        Idd.Id = k_Users.User_Id;
                        Main main = new Main();
                        main.Show();
                        return true;
                    }
                }
                else
                {
                    popup.ContentText = "Неверный логин или пароль";
                    popup.Popup();
                    return false;
                }
            }
            else
            {
                popup.ContentText = "Пользователя с таким логином не существует";
                popup.Popup();
                return false;
            }
            return true;
        }
    }
}