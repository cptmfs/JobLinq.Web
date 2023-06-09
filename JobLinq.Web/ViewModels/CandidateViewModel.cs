﻿using JobLinq.Web.Models;
using System.ComponentModel;

namespace JobLinq.Web.ViewModels
{
    public class CandidateViewModel
    {
        public int CandidateId { get; set; }
        [DisplayName("Kullanıcı ID")]
        public int? UserId { get; set; }
        [DisplayName("Ad")]
        public string? Fname { get; set; }
        [DisplayName("Soyad")]
        public string? Lname { get; set; }
        [DisplayName("Doğum Tarihi")]
        public DateTime? BirthDate { get; set; }
        [DisplayName("Şehir ID")]
        public byte? CityId { get; set; }
        [DisplayName("Tel No")]
        public string? Gsmno { get; set; }
        public City City { get; set; }
    }
}
