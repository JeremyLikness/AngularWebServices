// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Jeremy Likness">
//   Copyright (c) Jeremy Likness
// </copyright>
// <summary>
//   The home controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AngularWebservices.Controllers
{
    using System;
    using System.Web.Mvc;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// The resource.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Resource()
        {
            return this.View();
        }

        /// <summary>
        /// The new contact.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult NewContact()
        {
            return this.PartialView();
        }

        /// <summary>
        /// The list contacts.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult ListContacts()
        {
            return this.PartialView();
        }

        /// <summary>
        /// The JSON response.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult JsonP()
        {
            var result = new JavaScriptResult
                             {
                                 Script =
                                     string.Format("parseJson({{serverTime: '{0}'}});", DateTime.Now)
                             };
            return result;
        }
    }
}
