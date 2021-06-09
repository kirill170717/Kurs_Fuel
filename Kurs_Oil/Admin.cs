using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulpep.NotificationWindow;
using System.Drawing;

namespace Kurs_Oil
{
    public class Admin
    {
        public bool Button_InsU(string Login, string Password, string SName, string FName, string MName)
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

                    popup.ContentText = "Добавлено";
                    popup.Popup();
                }
            }
            return true;
        }
        public bool Button_UpdU(string UpLogin, string Login, string Password, string SName, string FName, string MName)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.BodyColor = Color.LightPink;

            gr691_tkpEntities db = new gr691_tkpEntities();
            var uRow = db.K_Users.FirstOrDefault(i => i.Login == UpLogin);
            if (uRow == null)
            {
                popup.ContentText = "Запись не найдена";
                popup.Popup();
                return false;
            }
            else
            {
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
                        uRow.Login = Login;
                        uRow.Password = Password;
                        uRow.LastName = SName;
                        uRow.FirstName = FName;
                        uRow.MiddleName = MName;
                        uRow.FK_Role_Id = 2;

                        db.SaveChanges();

                        popup.ContentText = "Изменено";
                        popup.Popup();
                    }
                }
            }
            return true;
        }
        public bool Button_DelU(string UpLogin)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.BodyColor = Color.LightPink;

            gr691_tkpEntities db = new gr691_tkpEntities();
            if (string.IsNullOrWhiteSpace(UpLogin))
            {
                popup.ContentText = "Ключевые поля не заполнены";
                popup.Popup();
                return false;
            }
            else
            {
                var dRow = db.K_Users.FirstOrDefault(i => i.Login == UpLogin);
                if (dRow == null)
                {
                    popup.ContentText = "Запись не найдена";
                    popup.Popup();
                    return false;
                }
                else
                {
                    db.K_Users.Remove(dRow);
                    db.SaveChanges();

                    popup.ContentText = "Удалено";
                    popup.Popup();
                }
            }
            return true;
        }
        public bool Button_InsT(string TypeF, string Price)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.BodyColor = Color.LightPink;

            gr691_tkpEntities db = new gr691_tkpEntities();
            if (string.IsNullOrWhiteSpace(TypeF) || string.IsNullOrWhiteSpace(Price))
            {
                popup.ContentText = "Ключевые поля не заполнены";
                popup.Popup();
                return false;
            }
            else
            {
                K_TypeFuel k_TypeFuel = new K_TypeFuel();
                k_TypeFuel.Type = TypeF;
                k_TypeFuel.Price = Convert.ToDecimal(Price);
                db.K_TypeFuel.Add(k_TypeFuel);
                db.SaveChanges();

                popup.ContentText = "Добавлено";
                popup.Popup();
            }
            return true;
        }
        public bool Button_UpdT(string UpTypeF, string TypeF, string Price)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.BodyColor = Color.LightPink;

            gr691_tkpEntities db = new gr691_tkpEntities();
            var uRow = db.K_TypeFuel.FirstOrDefault(i => i.Type == UpTypeF);
            if (uRow == null)
            {
                popup.ContentText = "Запись не найдена";
                popup.Popup();
                return false;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(TypeF) || string.IsNullOrWhiteSpace(Price))
                {
                    popup.ContentText = "Ключевые поля не заполнены";
                    popup.Popup();
                    return false;
                }
                else
                {
                        uRow.Type = TypeF;
                        uRow.Price = Convert.ToDecimal(Price);
                        db.SaveChanges();

                        popup.ContentText = "Изменено";
                        popup.Popup();
                }
            }
            return true;
        }
        public bool Button_DelT(string UpTypeF)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.BodyColor = Color.LightPink;

            gr691_tkpEntities db = new gr691_tkpEntities();
            if (string.IsNullOrWhiteSpace(UpTypeF))
            {
                popup.ContentText = "Ключевые поля не заполнены";
                popup.Popup();
                return false;
            }
            else
            {
                var dRow = db.K_TypeFuel.FirstOrDefault(i => i.Type == UpTypeF);
                if (dRow == null)
                {
                    popup.ContentText = "Запись не найдена";
                    popup.Popup();
                    return false;
                }
                else
                {
                    db.K_TypeFuel.Remove(dRow);
                    db.SaveChanges();

                    popup.ContentText = "Удалено";
                    popup.Popup();
                }
            }
            return true;
        }
    }
}