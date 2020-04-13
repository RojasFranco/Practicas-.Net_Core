using Curso.Model.Context;
using Curso.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Services.Services.FolderAutorizacion
{
    public class ValidacionTiempoEnLinea : IValidacionTiempoEnLinea
    {
        private readonly CursoContext _cursoContext;
        public ValidacionTiempoEnLinea(CursoContext cursoContext)
        {
            this._cursoContext = cursoContext;
        }


        public async Task<bool> VerificarTiempo(Guid? token)
        {
            var dbUser = await _cursoContext.Users.Where(x => x.Token == token).FirstOrDefaultAsync();      

            if(dbUser==null)
            {
                return false;
            }
            else
            {                
                
                DateTime dateTimeUser = dbUser.LastLoginDate.Value;

                return this.EstaDentroDeDiezMin(dateTimeUser);
            }            

        }

        public bool EstaDentroDeDiezMin(DateTime dateTimeUser)
        {
            DateTime dateTimeNow = DateTime.Now;
            int horaUser = dateTimeUser.Hour;
            int minUser = dateTimeUser.Minute;



            if (dateTimeUser.Day == dateTimeNow.Day && horaUser == dateTimeNow.Hour)
            {
                if (dateTimeNow.Minute - minUser < 10)
                {
                    return true;
                }
            }
            else if ((dateTimeUser.Day == dateTimeNow.Day && dateTimeNow.Hour - horaUser == 1) ||
                dateTimeNow.Day - dateTimeUser.Day == 1 && dateTimeNow.Hour == 0 && horaUser == 23)
            {
                if (minUser >= 50 && dateTimeNow.Minute < 10)
                {
                    if (dateTimeNow.Minute + 50 - minUser < 10)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
