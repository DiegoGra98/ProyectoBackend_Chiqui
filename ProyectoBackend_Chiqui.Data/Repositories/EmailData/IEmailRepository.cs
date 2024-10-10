using ProyectoBackend_Chiqui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Data.Repositories.EmailData
{
    public interface IEmailRepository
    {
        void SendEmail(EmailModel email);
    }
}
