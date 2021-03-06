﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeros.Data;
using SuperHeros.Models;

namespace SuperHeros.Controllers
{
    public class SuperHeroController : Controller
    {   
        private readonly ApplicationDbContext _context;

        public SuperHeroController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: SuperHero
        public ActionResult Index()
        {
            return View(_context.SuperHeros.ToList());
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.SuperHeros.Find(id));
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            SuperHero superhero = new SuperHero();
            return View(superhero);
        }

        // POST: SuperHero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero superhero)
        {
            if(ModelState.IsValid)
            {
                _context.SuperHeros.Add(superhero);
                _context.SaveChanges();
                return View();
            }
            else
            {
                return Create(superhero);
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)           
        {
            return View(_context.SuperHeros.Find(id));
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuperHero superhero)
        {
            if(ModelState.IsValid)
            {
                _context.SuperHeros.Update(superhero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Edit(id, superhero);
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.SuperHeros.Find(id));
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SuperHero superhero)
        {
            if(ModelState.IsValid)
            {
                _context.SuperHeros.Remove(superhero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Delete(id, superhero);
            }
        }
    }
}