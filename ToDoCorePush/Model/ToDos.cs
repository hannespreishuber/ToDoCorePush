using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoCorePush.Model
{
    public class ToDos
    {
        public Boolean Erledigt { get; set; }
        public string Aufgabe { get; set; }
    }


    public class ToDosListe
    {
        public List<ToDos> Items { get; set; }
        public ToDosListe()
        {
            Items = new List<ToDos>();
        }
        
    }
 
}
