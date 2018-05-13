using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSample.Models
{
    /// <summary>
    /// ContactViewModel
    /// </summary>
    public class ContactViewModel
    {
        #region Properties
        /// <summary>
        /// Fisrtname
        /// </summary>
        [Required(ErrorMessage ="FirstName Required")]
        public string FirstName { get; set; }
        /// <summary>
        /// LastName
        /// </summary>
        [Required(ErrorMessage ="LastName Required")]
        public string LastName { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage ="Email Required")]
        [EmailAddress(ErrorMessage ="Please enter valid Email address")]
        public string Email { get; set; }
        /// <summary>
        /// Subject
        /// </summary>
        [Required(ErrorMessage = "Subject Required")]
        public string Subject { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        [Required(ErrorMessage = "Message Required")]
        public string Message { get; set; }
        #endregion



    }
}
