namespace ArhiCRMv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Amplasament",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SuprafataTerenMasurata = c.Decimal(precision: 18, scale: 2),
                        JudetID = c.Int(),
                        LocalitateID = c.Int(),
                        ComunaSat = c.String(maxLength: 255),
                        Strada = c.String(maxLength: 255),
                        Numar = c.String(maxLength: 255),
                        Tarla = c.String(maxLength: 255),
                        Parcela = c.String(maxLength: 255),
                        NumarCadastral = c.String(maxLength: 255),
                        NumarCF = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Judet", t => t.JudetID)
                .ForeignKey("dbo.Localitate", t => t.LocalitateID)
                .Index(t => t.JudetID)
                .Index(t => t.LocalitateID);
            
            CreateTable(
                "dbo.Judet",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nume = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Localitate",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nume = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Proiect",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nume = c.String(maxLength: 255),
                        An = c.DateTime(storeType: "date"),
                        CreateDate = c.DateTime(),
                        NrProiect = c.String(maxLength: 255),
                        NrContract = c.String(maxLength: 255),
                        Valoare = c.Int(),
                        Recomandare = c.String(maxLength: 255),
                        TipProiectID = c.Int(),
                        StatusID = c.Int(),
                        BeneficiarID = c.Int(),
                        AmplasamentID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Amplasament", t => t.AmplasamentID)
                .ForeignKey("dbo.Beneficiar", t => t.BeneficiarID)
                .ForeignKey("dbo.Status", t => t.StatusID)
                .ForeignKey("dbo.TipProiect", t => t.TipProiectID)
                .Index(t => t.TipProiectID)
                .Index(t => t.StatusID)
                .Index(t => t.BeneficiarID)
                .Index(t => t.AmplasamentID);
            
            CreateTable(
                "dbo.AvizToProiectMapping",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProiectID = c.Int(),
                        AvizID = c.Int(),
                        AvizatorID = c.Int(),
                        DataDepunere = c.DateTime(storeType: "date"),
                        DataRidicare = c.DateTime(storeType: "date"),
                        BeneficiarResposabil = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Aviz", t => t.AvizID)
                .ForeignKey("dbo.Avizator", t => t.AvizatorID)
                .ForeignKey("dbo.Proiect", t => t.ProiectID)
                .Index(t => t.ProiectID)
                .Index(t => t.AvizID)
                .Index(t => t.AvizatorID);
            
            CreateTable(
                "dbo.Aviz",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nume = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Avizator",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nume = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Beneficiar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nume = c.String(maxLength: 255),
                        Adresa = c.String(maxLength: 255),
                        CNP = c.Int(),
                        Telefon = c.String(maxLength: 255),
                        SerieCI = c.String(maxLength: 255),
                        NumarCI = c.String(maxLength: 255),
                        PersoanaContact = c.String(maxLength: 255),
                        TelefonPersoanaContact = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Observatie",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProiectID = c.Int(),
                        Descriere = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Proiect", t => t.ProiectID)
                .Index(t => t.ProiectID);
            
            CreateTable(
                "dbo.Plata",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProiectID = c.Int(),
                        Suma = c.Decimal(precision: 18, scale: 2),
                        Data = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Proiect", t => t.ProiectID)
                .Index(t => t.ProiectID);
            
            CreateTable(
                "dbo.ProiectTehnicToProiectMapping",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProiectID = c.Int(),
                        ProiectTehnicID = c.Int(),
                        ColaboratorID = c.Int(),
                        DataDepunere = c.DateTime(storeType: "date"),
                        DataRidicare = c.DateTime(storeType: "date"),
                        SV = c.Boolean(),
                        BeneficiarResposabil = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Colaborator", t => t.ColaboratorID)
                .ForeignKey("dbo.Proiect", t => t.ProiectID)
                .ForeignKey("dbo.ProiectTehnic", t => t.ProiectTehnicID)
                .Index(t => t.ProiectID)
                .Index(t => t.ProiectTehnicID)
                .Index(t => t.ColaboratorID);
            
            CreateTable(
                "dbo.Colaborator",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nume = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudiuToProiectMapping",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProiectID = c.Int(),
                        StudiuID = c.Int(),
                        ColaboratorID = c.Int(),
                        DataDepunere = c.DateTime(storeType: "date"),
                        DataRidicare = c.DateTime(storeType: "date"),
                        SV = c.Boolean(),
                        BeneficiarResposabil = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Colaborator", t => t.ColaboratorID)
                .ForeignKey("dbo.Proiect", t => t.ProiectID)
                .ForeignKey("dbo.Studiu", t => t.StudiuID)
                .Index(t => t.ProiectID)
                .Index(t => t.StudiuID)
                .Index(t => t.ColaboratorID);
            
            CreateTable(
                "dbo.Studiu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nume = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProiectTehnic",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nume = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ResponsabilitateToProiectMapping",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProiectID = c.Int(),
                        ResponsabilitateID = c.Int(),
                        ResponsabilitateBeneficiar_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Proiect", t => t.ProiectID)
                .ForeignKey("dbo.ResponsabilitateBeneficiar", t => t.ResponsabilitateBeneficiar_ID)
                .Index(t => t.ProiectID)
                .Index(t => t.ResponsabilitateBeneficiar_ID);
            
            CreateTable(
                "dbo.ResponsabilitateBeneficiar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nume = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descriere = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TipProiect",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nume = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles1",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers1",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins1",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.__MigrationHistory",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 150),
                        ContextKey = c.String(nullable: false, maxLength: 300),
                        Model = c.Binary(nullable: false),
                        ProductVersion = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
            CreateTable(
                "dbo.AspNetUserAspNetRoles",
                c => new
                    {
                        AspNetUser_Id = c.String(nullable: false, maxLength: 128),
                        AspNetRole_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AspNetUser_Id, t.AspNetRole_Id })
                .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles1", t => t.AspNetRole_Id, cascadeDelete: true)
                .Index(t => t.AspNetUser_Id)
                .Index(t => t.AspNetRole_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserLogins1", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUserClaims1", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUserAspNetRoles", "AspNetRole_Id", "dbo.AspNetRoles1");
            DropForeignKey("dbo.AspNetUserAspNetRoles", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.Proiect", "TipProiectID", "dbo.TipProiect");
            DropForeignKey("dbo.Proiect", "StatusID", "dbo.Status");
            DropForeignKey("dbo.ResponsabilitateToProiectMapping", "ResponsabilitateBeneficiar_ID", "dbo.ResponsabilitateBeneficiar");
            DropForeignKey("dbo.ResponsabilitateToProiectMapping", "ProiectID", "dbo.Proiect");
            DropForeignKey("dbo.ProiectTehnicToProiectMapping", "ProiectTehnicID", "dbo.ProiectTehnic");
            DropForeignKey("dbo.ProiectTehnicToProiectMapping", "ProiectID", "dbo.Proiect");
            DropForeignKey("dbo.StudiuToProiectMapping", "StudiuID", "dbo.Studiu");
            DropForeignKey("dbo.StudiuToProiectMapping", "ProiectID", "dbo.Proiect");
            DropForeignKey("dbo.StudiuToProiectMapping", "ColaboratorID", "dbo.Colaborator");
            DropForeignKey("dbo.ProiectTehnicToProiectMapping", "ColaboratorID", "dbo.Colaborator");
            DropForeignKey("dbo.Plata", "ProiectID", "dbo.Proiect");
            DropForeignKey("dbo.Observatie", "ProiectID", "dbo.Proiect");
            DropForeignKey("dbo.Proiect", "BeneficiarID", "dbo.Beneficiar");
            DropForeignKey("dbo.AvizToProiectMapping", "ProiectID", "dbo.Proiect");
            DropForeignKey("dbo.AvizToProiectMapping", "AvizatorID", "dbo.Avizator");
            DropForeignKey("dbo.AvizToProiectMapping", "AvizID", "dbo.Aviz");
            DropForeignKey("dbo.Proiect", "AmplasamentID", "dbo.Amplasament");
            DropForeignKey("dbo.Amplasament", "LocalitateID", "dbo.Localitate");
            DropForeignKey("dbo.Amplasament", "JudetID", "dbo.Judet");
            DropIndex("dbo.AspNetUserAspNetRoles", new[] { "AspNetRole_Id" });
            DropIndex("dbo.AspNetUserAspNetRoles", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUserLogins1", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUserClaims1", new[] { "AspNetUser_Id" });
            DropIndex("dbo.ResponsabilitateToProiectMapping", new[] { "ResponsabilitateBeneficiar_ID" });
            DropIndex("dbo.ResponsabilitateToProiectMapping", new[] { "ProiectID" });
            DropIndex("dbo.StudiuToProiectMapping", new[] { "ColaboratorID" });
            DropIndex("dbo.StudiuToProiectMapping", new[] { "StudiuID" });
            DropIndex("dbo.StudiuToProiectMapping", new[] { "ProiectID" });
            DropIndex("dbo.ProiectTehnicToProiectMapping", new[] { "ColaboratorID" });
            DropIndex("dbo.ProiectTehnicToProiectMapping", new[] { "ProiectTehnicID" });
            DropIndex("dbo.ProiectTehnicToProiectMapping", new[] { "ProiectID" });
            DropIndex("dbo.Plata", new[] { "ProiectID" });
            DropIndex("dbo.Observatie", new[] { "ProiectID" });
            DropIndex("dbo.AvizToProiectMapping", new[] { "AvizatorID" });
            DropIndex("dbo.AvizToProiectMapping", new[] { "AvizID" });
            DropIndex("dbo.AvizToProiectMapping", new[] { "ProiectID" });
            DropIndex("dbo.Proiect", new[] { "AmplasamentID" });
            DropIndex("dbo.Proiect", new[] { "BeneficiarID" });
            DropIndex("dbo.Proiect", new[] { "StatusID" });
            DropIndex("dbo.Proiect", new[] { "TipProiectID" });
            DropIndex("dbo.Amplasament", new[] { "LocalitateID" });
            DropIndex("dbo.Amplasament", new[] { "JudetID" });
            DropTable("dbo.AspNetUserAspNetRoles");
            DropTable("dbo.__MigrationHistory");
            DropTable("dbo.AspNetUserLogins1");
            DropTable("dbo.AspNetUserClaims1");
            DropTable("dbo.AspNetUsers1");
            DropTable("dbo.AspNetRoles1");
            DropTable("dbo.TipProiect");
            DropTable("dbo.Status");
            DropTable("dbo.ResponsabilitateBeneficiar");
            DropTable("dbo.ResponsabilitateToProiectMapping");
            DropTable("dbo.ProiectTehnic");
            DropTable("dbo.Studiu");
            DropTable("dbo.StudiuToProiectMapping");
            DropTable("dbo.Colaborator");
            DropTable("dbo.ProiectTehnicToProiectMapping");
            DropTable("dbo.Plata");
            DropTable("dbo.Observatie");
            DropTable("dbo.Beneficiar");
            DropTable("dbo.Avizator");
            DropTable("dbo.Aviz");
            DropTable("dbo.AvizToProiectMapping");
            DropTable("dbo.Proiect");
            DropTable("dbo.Localitate");
            DropTable("dbo.Judet");
            DropTable("dbo.Amplasament");
        }
    }
}
