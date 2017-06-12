using System.Linq;
using System.Net;
using System.Web.Mvc;
using Blog.DataProviders;
using Blog.Models;
using System;

namespace Blog.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostDataProvider _postDataProvider;

        public PostsController(IPostDataProvider PostDataProvider)
        {
            _postDataProvider = PostDataProvider;
        }

        public ActionResult Index()
        {
            return View(_postDataProvider.GetAllPosts().ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var post = _postDataProvider.GetPostById(id);
            if (post == null)
                return HttpNotFound();
            return View(post);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.Time = DateTime.Now;
                _postDataProvider.SavePost(post);
                return RedirectToAction("Index");
            }

            return View(post);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var post = _postDataProvider.GetPostById(id);
            if (post == null)
                return HttpNotFound();
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                post.Time = DateTime.Now;
                _postDataProvider.SavePost(post);
                return RedirectToAction("Index");
            }
            return View(post);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var post = _postDataProvider.GetPostById(id);
            if (post == null)
                return HttpNotFound();
            return View(post);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _postDataProvider.DeletePost(id);
            return RedirectToAction("Index");
        }
    }
}