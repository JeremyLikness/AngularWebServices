// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactsController.cs" company="Jeremy Likness">
//   Copyright (c) Jeremy Likness
// </copyright>
// <summary>
//   The contacts controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AngularWebservices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using AngularWebservices.Models;

    /// <summary>
    /// The contacts controller.
    /// </summary>
    public class ContactsController : ApiController
    {
        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IContactRepository Repository { get; set; }

        /// <summary>
        /// Gets the list of contacts.
        /// </summary>
        /// <returns>
        /// The list of contacts.
        /// </returns>
        public IEnumerable<Contact> Get()
        {
            return this.Repository.GetContacts();
        }

        /// <summary>
        /// Gets the contact
        /// </summary>
        /// <param name="id">
        /// The id for the contact
        /// </param>
        /// <returns>        
        /// The contact with the matching id
        /// </returns>
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var contact = this.Repository.Get(id);

                return contact == null ? 
                    this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Contact not found.") 
                    : this.Request.CreateResponse(HttpStatusCode.OK, contact);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);                    
            }
        }

        /// <summary>
        /// The post/insert for a contact.
        /// </summary>
        /// <param name="contact">
        /// The contact to insert.
        /// </param>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/>.
        /// </returns>
        /// <exception cref="HttpResponseException">
        /// An exception occurred attempting to insert
        /// </exception>
        public HttpResponseMessage Post(Contact contact)
        {
            try
            {
                var newContact = this.Repository.Insert(contact);

                var response = Request.CreateResponse(HttpStatusCode.Created, contact);

                var resource = this.Url.Route(null, new { id = newContact.Id }) ?? string.Empty;
                response.Headers.Location = new Uri(Request.RequestUri, resource);
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);                    
            }
        }

        /// <summary>
        /// Update a contact.
        /// </summary>
        /// <param name="id">
        /// The id of the contact.
        /// </param>
        /// <param name="contact">
        /// The contact information to update.
        /// </param>
        public void Put(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var existing = this.Get(id);
            if (existing == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);   
            }

            this.Repository.Update(contact);            
        }

        /// <summary>
        /// The delete method.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            if (id < 1)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            if (!this.Repository.Delete(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
