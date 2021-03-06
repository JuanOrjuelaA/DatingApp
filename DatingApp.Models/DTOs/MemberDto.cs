﻿namespace DatingApp.Models.DTOs
{
    using Entities;
    using System;
    using System.Collections.Generic;

    public class MemberDto
    {
        /// <summary>
        ///
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string PhotUrl { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string KnownAs { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime Created { get; set; } = DateTime.Now;

        /// <summary>
        ///
        /// </summary>
        public DateTime LastActive { get; set; } = DateTime.Now;

        /// <summary>
        ///
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Introduction { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string LookingFor { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Interests { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ICollection<Photo> Photos { get; set; }
    }
}