﻿using Model.Dao;
using Model.EF;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page=1,int pageSize=10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString,page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
            {
            return View();
            } 
        [HttpPost]
        public ActionResult Create(User user)
        {
            var dao = new UserDao();
            var encrytedMd5Pas = Encryptor.MD5Hash(user.Password);
            user.Password = encrytedMd5Pas;
            long id = dao.Insert(user);
            if( id>0)
            {
                SetAlert("Them thanh cong", "success");
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Thêm User thất bại");
            }
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            var dao = new UserDao();
            if(!string.IsNullOrEmpty(user.Password))
            {
                var encrytedMd5Pas = Encryptor.MD5Hash(user.Password);
                user.Password = encrytedMd5Pas;
            }
            
            var result = dao.Update(user);
            if (result)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật User thất bại");
            }
            return View("Index");
        }
        //delete
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result 
            });
        }
    }
}