// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contact.cs" company="Jeremy Likness">
//   Copyright (c) 2014 Jeremy Likness
// </copyright>
// <summary>
//   The contact class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AngularWebservices.Models
{
    using System;

    /// <summary>
    /// The contact.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Gets or sets the unique id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        public DateTime Modified { get; set; }        
    }
}