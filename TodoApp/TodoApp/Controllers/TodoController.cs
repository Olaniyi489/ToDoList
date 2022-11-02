using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoApp.DAL;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        ToDoDAL todoDal = new ToDoDAL();
        // GET: Todo
        public ActionResult Index()
        {
            var listTodo = todoDal.GetAllTodo();
            return View(listTodo);
        }

        // GET: Todo/Details/5
        public ActionResult Details(int id)
        {
            var listTodo = todoDal.GetTask(id);
            return View(listTodo[0]);
        }

        // GET: Todo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todo/Create
        [HttpPost]
        public ActionResult Create(TodoModel todoModel)
        {
            bool isCreated = false;
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    isCreated = todoDal.CreateTask(todoModel);
                    if(isCreated)
                    {
                        TempData["success"] = "Successfully Added Task";   
                    }else
                    {
                        TempData["error"] = "Unable to add Task";
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Todo/Edit/5
        public ActionResult Edit(int id)
        {
            var todoModel = todoDal.GetTask(id);
            return View(todoModel[0]);
        }

        // POST: Todo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TodoModel todo)
        {
            bool isUpdated = false;
            try
            {
                isUpdated = todoDal.UpdateTask(id, todo);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Todo/Delete/5
        public ActionResult Delete(int? id)
        {
            var listTodo = todoDal.DeleteTask(id);
            return View();
            
        }

        // POST: Todo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
