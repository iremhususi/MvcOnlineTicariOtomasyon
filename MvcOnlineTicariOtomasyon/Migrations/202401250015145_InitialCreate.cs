﻿namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Adminid = c.Int(nullable: false, identity: true),
                        KullaniciAd = c.String(maxLength: 10, unicode: false),
                        Sifre = c.String(maxLength: 30, unicode: false),
                        Yetki = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Adminid);
            
            CreateTable(
                "dbo.Carilers",
                c => new
                    {
                        Cariid = c.Int(nullable: false, identity: true),
                        CariAd = c.String(maxLength: 30, unicode: false),
                        CariSoyad = c.String(nullable: false, maxLength: 30, unicode: false),
                        CariSehir = c.String(maxLength: 13, unicode: false),
                        CariMail = c.String(maxLength: 50, unicode: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Cariid);
            
            CreateTable(
                "dbo.SatisHarekets",
                c => new
                    {
                        Satisid = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        Adet = c.Int(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToplamTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Urunid = c.Int(nullable: false),
                        Cariid = c.Int(nullable: false),
                        Personelid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Satisid)
                .ForeignKey("dbo.Carilers", t => t.Cariid, cascadeDelete: true)
                .ForeignKey("dbo.Personels", t => t.Personelid, cascadeDelete: true)
                .ForeignKey("dbo.Uruns", t => t.Urunid, cascadeDelete: true)
                .Index(t => t.Urunid)
                .Index(t => t.Cariid)
                .Index(t => t.Personelid);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        Personelid = c.Int(nullable: false, identity: true),
                        PersonelAd = c.String(maxLength: 30, unicode: false),
                        PersonelSoyad = c.String(maxLength: 30, unicode: false),
                        PersonelGorsel = c.String(maxLength: 250, unicode: false),
                        Departmanid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Personelid)
                .ForeignKey("dbo.Departmen", t => t.Departmanid, cascadeDelete: true)
                .Index(t => t.Departmanid);
            
            CreateTable(
                "dbo.Departmen",
                c => new
                    {
                        Departmanid = c.Int(nullable: false, identity: true),
                        DepartmanAd = c.String(maxLength: 30, unicode: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Departmanid);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        Urunid = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(maxLength: 30, unicode: false),
                        Marka = c.String(maxLength: 30, unicode: false),
                        Stok = c.Short(nullable: false),
                        AlisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SatisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Durum = c.Boolean(nullable: false),
                        UrunGorsel = c.String(maxLength: 250, unicode: false),
                        Kategoriid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Urunid)
                .ForeignKey("dbo.Kategoris", t => t.Kategoriid, cascadeDelete: true)
                .Index(t => t.Kategoriid);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriID = c.Int(nullable: false, identity: true),
                        KategoriAd = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.KategoriID);
            
            CreateTable(
                "dbo.FaturaKalems",
                c => new
                    {
                        FaturaKalemid = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Miktar = c.Int(nullable: false),
                        BirimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Faturaid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FaturaKalemid)
                .ForeignKey("dbo.Faturalars", t => t.Faturaid, cascadeDelete: true)
                .Index(t => t.Faturaid);
            
            CreateTable(
                "dbo.Faturalars",
                c => new
                    {
                        Faturaid = c.Int(nullable: false, identity: true),
                        FaturaSeriNo = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        FaturaSıraNo = c.String(maxLength: 6, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                        VergiDairesi = c.String(maxLength: 60, unicode: false),
                        Saat = c.String(maxLength: 5, fixedLength: true, unicode: false),
                        TeslimEden = c.String(maxLength: 30, unicode: false),
                        TeslimAlan = c.String(maxLength: 30, unicode: false),
                        Toplam = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Faturaid);
            
            CreateTable(
                "dbo.Giders",
                c => new
                    {
                        Giderid = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Giderid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FaturaKalems", "Faturaid", "dbo.Faturalars");
            DropForeignKey("dbo.SatisHarekets", "Urunid", "dbo.Uruns");
            DropForeignKey("dbo.Uruns", "Kategoriid", "dbo.Kategoris");
            DropForeignKey("dbo.SatisHarekets", "Personelid", "dbo.Personels");
            DropForeignKey("dbo.Personels", "Departmanid", "dbo.Departmen");
            DropForeignKey("dbo.SatisHarekets", "Cariid", "dbo.Carilers");
            DropIndex("dbo.FaturaKalems", new[] { "Faturaid" });
            DropIndex("dbo.Uruns", new[] { "Kategoriid" });
            DropIndex("dbo.Personels", new[] { "Departmanid" });
            DropIndex("dbo.SatisHarekets", new[] { "Personelid" });
            DropIndex("dbo.SatisHarekets", new[] { "Cariid" });
            DropIndex("dbo.SatisHarekets", new[] { "Urunid" });
            DropTable("dbo.Giders");
            DropTable("dbo.Faturalars");
            DropTable("dbo.FaturaKalems");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Uruns");
            DropTable("dbo.Departmen");
            DropTable("dbo.Personels");
            DropTable("dbo.SatisHarekets");
            DropTable("dbo.Carilers");
            DropTable("dbo.Admins");
        }
    }
}
