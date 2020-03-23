using System;
using System.Collections.Generic;
using System.Text;

namespace Curso.Model.Model
{
    public class TablaJSON
    {
        private List<string> listaHeaders = new List<string>();
        private List<Person> rows = new List<Person>();


        public List<string> Headers { get => listaHeaders; set => listaHeaders = value; }
        public List<Person> Rows { get => rows; set => rows = value; }


    }
}
