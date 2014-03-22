// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactRepository.cs" company="Jeremy Likness">
//   Copyright (c) 2014 Jeremy Likness.
// </copyright>
// <summary>
//   The contact repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AngularWebservices.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The contact repository.
    /// </summary>
    public class ContactRepository : IContactRepository
    {
        /// <summary>
        /// The contacts key for the cache.
        /// </summary>
        private const string ContactsKey = "Contacts";

        /// <summary>
        /// Gets the contacts.
        /// </summary>
        private static List<Contact> Contacts
        {
            get
            {
                if (HttpContext.Current.Cache[ContactsKey] == null)
                {
                    HttpContext.Current.Cache[ContactsKey] = new List<Contact>();
                }

                return (List<Contact>)HttpContext.Current.Cache[ContactsKey];
            }
        }

        /// <summary>
        /// Get all contacts.
        /// </summary>
        /// <returns>
        /// The list of contacts.
        /// </returns>
        public IEnumerable<Contact> GetContacts()
        {
            return Contacts;
        }

        /// <summary>
        /// Get a single contact.
        /// </summary>
        /// <param name="id">
        /// The unique id of the contact.
        /// </param>
        /// <returns>
        /// The <see cref="Contact"/>.
        /// </returns>
        public Contact Get(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException("id");
            }

            return Contacts.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Insert a new contact.
        /// </summary>
        /// <param name="contact">
        /// The contact to insert.
        /// </param>
        /// <returns>
        /// The inserted <see cref="Contact"/>.
        /// </returns>
        public Contact Insert(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException("contact");
            }

            if (contact.Id > 0)
            {
                throw new DataException("Cannot insert existing contact.");
            }

            contact.Modified = contact.Created = DateTime.Now;

            contact.Id = Contacts.Any() ? Contacts.Max(c => c.Id) + 1 : 1;
            Contacts.Add(contact);
            return contact;
        }

        /// <summary>
        /// Update and existing contact.
        /// </summary>
        /// <param name="contact">
        /// The contact to update.
        /// </param>
        /// <returns>
        /// The updated <see cref="Contact"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The contact was null 
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The contact did not have a valid id 
        /// </exception>
        /// <exception cref="DataException">
        /// A contact with that id does not exist
        /// </exception>
        public Contact Update(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException("contact");
            }

            if (contact.Id < 1)
            {
                throw new ArgumentOutOfRangeException("contact");
            }

            var existingContact = this.Get(contact.Id);

            if (existingContact == null)
            {
                throw new DataException("Contact does not exist.");
            }

            existingContact.FirstName = contact.FirstName;
            existingContact.LastName = contact.LastName;
            existingContact.Modified = DateTime.Now;
            return existingContact;
        }

        /// <summary>
        /// Delete a contact
        /// </summary>
        /// <param name="id">The contact id</param>
        /// <returns>True if the contact existed and was deleted</returns>
        public bool Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException("id");
            }

            var contact = this.Get(id);

            if (contact == null)
            {
                return false;
            }

            Contacts.Remove(contact);
            return true;
        }
    }
}