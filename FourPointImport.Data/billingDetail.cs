﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FourPointImport.Data
{
    [Table("BillingDetail", Schema = "dbo")]
    public class billingDetail : Import
    {
        public  int BDSEQ { get; set; }
        public  string BXAGNT { get; set; }
        public  string BXBRCH { get; set; }
        public  string BXCERT { get; set; }
        public  string BXNAME { get; set; }
        public  string BXCOVC { get; set; }
        public  DateTime BXEFFT { get; set; }
        public  DateTime BXFROM { get; set; }
        public  DateTime BXTHRU { get; set; }
        public  DateTime BXEXPR { get; set; }
        public  DateTime BXPAID { get; set; }
        public  DateTime BXNEXT { get; set; }
        public  string BXNEG01 { get; set; }
        public  decimal BXBAMT { get; set; }
        public  string BXNEG02 { get; set; }
        public  decimal BXCOMM { get; set; }
        public  string BXNEG03 { get; set; }
        public  decimal BXBGRS { get; set; }
        public  string BXNEG04 { get; set; }
        public  decimal BXPAMT { get; set; }            //BFAMT
        public  string BXNEG05 { get; set; }
        public  decimal BXCOMP { get; set; }
        public  string BXNEG06 { get; set; }
        public  decimal BXPGRS { get; set; }
        public  string BXNEG07 { get; set; }
        public  decimal BXMOB { get; set; }
        public  decimal BXINTR { get; set; }
        public  decimal BXINT { get; set; }
        public  decimal BXPRIN { get; set; }
        public  decimal BXSCHD { get; set; }
        public  string BXMSGC { get; set; }
        public  string BXMSGD { get; set; }
        public  string BXCODE { get; set; }
        public  string BXDESC { get; set; }
        public  DateTime BXCAND { get; set; }
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<billingDetail>().Property(x => x.Archive);
            modelBuilder.Entity<billingDetail>().Property(x => x.CreateOn);
            modelBuilder.Entity<billingDetail>().Property(x => x.LastUpdated);
            modelBuilder.Entity<billingDetail>().Property(x => x.BDSEQ);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXAGNT).HasMaxLength(10);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXBRCH).HasMaxLength(10);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXCERT).HasMaxLength(20);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNAME).HasMaxLength(25);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXCOVC).HasMaxLength(30);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXEFFT);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXFROM);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXTHRU);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXEXPR);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXPAID);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNEXT);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNEG01).HasMaxLength(1);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXBAMT).HasPrecision(10, 2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNEG02).HasMaxLength(1);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXCOMM).HasPrecision(10, 2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNEG03).HasMaxLength(1);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXBGRS).HasPrecision(10, 2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNEG04).HasMaxLength(1);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXPAMT).HasPrecision(10, 2);           //BFAMT
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNEG05).HasMaxLength(1);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXCOMP).HasPrecision(10, 2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNEG06).HasMaxLength(1);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXPGRS).HasPrecision(10, 2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXNEG07).HasMaxLength(1);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXMOB).HasPrecision(10, 2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXINTR).HasPrecision(7, 5);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXINT).HasPrecision(7, 5);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXPRIN).HasPrecision(11, 2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXSCHD).HasPrecision(11, 2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXMSGC).HasMaxLength(2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXMSGD).HasMaxLength(25);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXCODE).HasMaxLength(2);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXDESC).HasMaxLength(25);
            modelBuilder.Entity<billingDetail>().Property(x => x.BXCAND);
        }
    }
}
