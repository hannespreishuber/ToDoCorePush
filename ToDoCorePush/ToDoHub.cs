using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.SignalR;
using RazorPartialToString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoCorePush.Model;

namespace ToDoCorePush
{
    public class ToDoHub : Hub
    {
        string tmpmodel;
        private IRazorViewEngine _viewEngine;
        private ITempDataProvider _tempDataProvider;
        private IServiceProvider _serviceProvider;
        IRazorPartialToStringRenderer renderer;
        ToDosListe _toDosListe;
        public ToDoHub(IRazorPartialToStringRenderer rdr, IRazorViewEngine viewEngine,
            ITempDataProvider tempDataProvider,
            IServiceProvider serviceProvider, ToDosListe todos)
        {
            renderer = rdr;
            _viewEngine = viewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
            _toDosListe = todos;
        }
        public void Action(string aufgabe, string action)
        {
            switch (action)
            {
               case "Add":
 _toDosListe.Items.Add(new ToDos { Aufgabe = aufgabe, Erledigt = false });
            break;
                case "Check":
                    var item = _toDosListe.Items.Where(x => x.Aufgabe == aufgabe).FirstOrDefault();
                    item.Erledigt = !item.Erledigt;
              
                    break;
            }
            var msg = renderer.RenderPartialToStringAsync("_ToDoTableTemplate", _toDosListe);

            Clients.All.SendAsync("DoneToDo", msg);
        }
    
    }
}
