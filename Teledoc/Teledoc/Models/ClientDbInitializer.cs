using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Teledoc.Models
{
    public class ClientDbInitializer : DropCreateDatabaseAlways<ClientContext>
    {
        protected override void Seed(ClientContext db)
        {
            db.Database.ExecuteSqlCommand("ALTER TABLE dbo.Founders ADD CONSTRAINT Founders_Clients FOREIGN KEY (ClientId) REFERENCES dbo.Clients (Id) ON DELETE SET NULL");

            db.Clients.Add(new Client { Inn = 123456789012, Name = "ИП Иванов Иван Иванович", Type = "ИП", Date_Add = DateTime.Now, Date_Upd = DateTime.Now, });
            db.Clients.Add(new Client { Inn = 666435189512, Name = "ИП Петров Петр Петрович", Type = "ИП", Date_Add = DateTime.Now, Date_Upd = DateTime.Now });
            db.Clients.Add(new Client { Inn = 8723984710, Name = "ООО СтройДом", Type = "ООО", Date_Add = DateTime.Now, Date_Upd = DateTime.Now });
            db.Clients.Add(new Client { Inn = 9876345760, Name = "ОАО ГазДом", Type = "ОАО", Date_Add = DateTime.Now, Date_Upd = DateTime.Now });

            db.Founders.Add(new Founder { Inn = 712419829892, Fio = "Иванов Иван Иванович", ClientId = 1, Date_Add = DateTime.Now, Date_Upd = DateTime.Now });
            db.Founders.Add(new Founder { Inn = 712665579892, Fio = "Петров Петр Петрович", ClientId = 2, Date_Add = DateTime.Now, Date_Upd = DateTime.Now });
            db.Founders.Add(new Founder { Inn = 823828761017, Fio = "Ленина Елена Андреевна", ClientId = 3, Date_Add = DateTime.Now, Date_Upd = DateTime.Now });
            db.Founders.Add(new Founder { Inn = 772572093748, Fio = "Ленин Сергей Дмитриевич", ClientId = 3, Date_Add = DateTime.Now, Date_Upd = DateTime.Now });
            base.Seed(db);
        }
    }
}