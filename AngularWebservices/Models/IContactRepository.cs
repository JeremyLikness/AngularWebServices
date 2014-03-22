// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContactRepository.cs" company="Jeremy Likness">
//   Copyright (c) 2014 Jeremy Likness.
// </copyright>
// <summary>
//   The ContactRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AngularWebservices.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The ContactRepository interface.
    /// </summary>
    public interface IContactRepository
    {
        /// <summary>
        /// Get all contacts.
        /// </summary>
        /// <returns>
        /// The list of contacts.
        /// </returns>
        IEnumerable<Contact> GetContacts();

        /// <summary>
        /// Get a single contact.
        /// </summary>
        /// <param name="id">
        /// The unique contact id.
        /// </param>
        /// <returns>
        /// The <see cref="Contact"/>.
        /// </returns>
        Contact Get(int id);

        /// <summary>
        /// Insert a new contact.
        /// </summary>
        /// <param name="contact">
        /// The contact top insert.
        /// </param>
        /// <returns>
        /// The inserted <see cref="Contact"/>.
        /// </returns>
        Contact Insert(Contact contact);

        /// <summary>
        /// Update an existing contact.
        /// </summary>
        /// <param name="contact">
        /// The contact to update.
        /// </param>
        /// <returns>
        /// The updated <see cref="Contact"/>.
        /// </returns>
        Contact Update(Contact contact);

        /// <summary>
        /// Delete a contact.
        /// </summary>
        /// <param name="id">
        /// The unique id for the contact.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/> result of the delete.
        /// </returns>
        bool Delete(int id);
    }
}