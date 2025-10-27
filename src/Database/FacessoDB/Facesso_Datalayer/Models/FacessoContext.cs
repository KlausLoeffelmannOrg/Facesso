using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Facesso_DatamodelImporter
{
    public partial class FacessoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-R86DOUR\SQL_SERVER_2014;Database=Facesso;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressDetails>(entity =>
            {
                entity.HasKey(e => new { e.Idsubsidiary, e.IdaddressDetail })
                    .HasName("PK_AddressDetails");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.IdaddressDetail)
                    .HasColumnName("IDAddressDetail")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.CompanyEmail).HasMaxLength(255);

                entity.Property(e => e.CompanyMobile).HasMaxLength(100);

                entity.Property(e => e.CompanyPhone).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.CountryCode).HasMaxLength(10);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastEdited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MiddleName).HasMaxLength(100);

                entity.Property(e => e.PrivateEmail).HasMaxLength(255);

                entity.Property(e => e.PrivateMobile).HasMaxLength(100);

                entity.Property(e => e.PrivatePhone).HasMaxLength(100);

                entity.Property(e => e.Street).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(255);

                entity.Property(e => e.Zip).HasMaxLength(10);

                entity.HasOne(d => d.IdsubsidiaryNavigation)
                    .WithMany(p => p.AddressDetails)
                    .HasForeignKey(d => d.Idsubsidiary)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_AddressDetails_Subsidiaries");
            });

            modelBuilder.Entity<ApplicationSettings>(entity =>
            {
                entity.HasKey(e => new { e.IdapplicationSettings, e.Idsubsidiary })
                    .HasName("PK_ApplicationSettings");

                entity.Property(e => e.IdapplicationSettings)
                    .HasColumnName("IDApplicationSettings")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Settings)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.ApplicationSettings)
                    .HasForeignKey(d => new { d.Idsubsidiary, d.Iduser })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ApplicationSettings_Users");
            });

            modelBuilder.Entity<Articles>(entity =>
            {
                entity.HasKey(e => new { e.Idarticle, e.Idsubsidiary })
                    .HasName("PK_Articles");

                entity.Property(e => e.Idarticle)
                    .HasColumnName("IDArticle")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.IdcostCenter).HasColumnName("IDCostCenter");

                entity.Property(e => e.IdlabourValue).HasColumnName("IDLabourValue");

                entity.Property(e => e.Idmachine).HasColumnName("IDMachine");

                entity.Property(e => e.ItemDescription).IsRequired();

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ItemNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastEdited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.WasCurrentFrom).HasColumnType("datetime");

                entity.Property(e => e.WasCurrentTo).HasColumnType("datetime");

                entity.HasOne(d => d.IdsubsidiaryNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.Idsubsidiary)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Articles_Subsidiaries");
            });

            modelBuilder.Entity<BonusList>(entity =>
            {
                entity.HasKey(e => new { e.IdbonusList, e.Idsubsidiary })
                    .HasName("PK_BonusList");

                entity.Property(e => e.IdbonusList)
                    .HasColumnName("IDBonusList")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.AbsoluteValue).HasColumnType("money");

                entity.Property(e => e.DegreeOfTime).HasColumnType("money");

                entity.Property(e => e.IdbonusLists).HasColumnName("IDBonusLists");

                entity.Property(e => e.LastEdited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Percentage).HasColumnType("money");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.BonusList)
                    .HasForeignKey(d => new { d.IdbonusLists, d.Idsubsidiary })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BonusList_BonusLists");
            });

            modelBuilder.Entity<BonusLists>(entity =>
            {
                entity.HasKey(e => new { e.IdbonusLists, e.Idsubsidiary })
                    .HasName("PK_BonusLists");

                entity.Property(e => e.IdbonusLists)
                    .HasColumnName("IDBonusLists")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.IdcostCenter).HasColumnName("IDCostCenter");

                entity.Property(e => e.LastEdited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.WasCurrentFrom).HasColumnType("datetime");

                entity.Property(e => e.WasCurrentTo).HasColumnType("datetime");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.BonusLists)
                    .HasForeignKey(d => new { d.Idsubsidiary, d.IdcostCenter })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BonusLists_CostCenter");
            });

            modelBuilder.Entity<CostCenters>(entity =>
            {
                entity.HasKey(e => new { e.Idsubsidiary, e.IdcostCenter })
                    .HasName("PK_CostCenters");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.IdcostCenter)
                    .HasColumnName("IDCostCenter")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.BaseValuePrecision).HasDefaultValueSql("2");

                entity.Property(e => e.BaseValueSynonym)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("N'te in h/min'");

                entity.Property(e => e.CostCenterName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IdcostCenterInternal).HasColumnName("IDCostCenterInternal");

                entity.Property(e => e.Idcurrency).HasColumnName("IDCurrency");

                entity.Property(e => e.IncentiveIndicatorDimension)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.IncentiveIndicatorPrecision).HasDefaultValueSql("0");

                entity.Property(e => e.IncentiveIndicatorSynonym)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IncentiveWageSynonym)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastEdited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.WasCurrentFrom).HasColumnType("datetime");

                entity.Property(e => e.WasCurrentTo).HasColumnType("datetime");

                entity.HasOne(d => d.IdcurrencyNavigation)
                    .WithMany(p => p.CostCenters)
                    .HasForeignKey(d => d.Idcurrency)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CostCenters_Currencies");
            });

            modelBuilder.Entity<Currencies>(entity =>
            {
                entity.HasKey(e => e.Idcurrency)
                    .HasName("PK_Currencies");

                entity.HasIndex(e => e.CurrencyToken)
                    .HasName("IX_CurrencyToken")
                    .IsUnique();

                entity.Property(e => e.Idcurrency)
                    .HasColumnName("IDCurrency")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasColumnType("nchar(3)");

                entity.Property(e => e.CurrencyPlainText)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CurrencyToken)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FactorToEuroAverage).HasColumnType("money");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => new { e.Idsubsidiary, e.Idemployee })
                    .HasName("PK_Employees");

                entity.HasIndex(e => e.LastName)
                    .HasName("IX_Employees_LastName");

                entity.HasIndex(e => e.PersonnelNumber)
                    .HasName("IX_Employees_PersonnelNumber")
                    .IsUnique();

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.Idemployee)
                    .HasColumnName("IDEmployee")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.DateOfJoining).HasColumnType("datetime");

                entity.Property(e => e.DateOfSeparation).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FixedWage).HasColumnType("money");

                entity.Property(e => e.IdaddressDetails).HasColumnName("IDAddressDetails");

                entity.Property(e => e.IdcostCenter).HasColumnName("IDCostCenter");

                entity.Property(e => e.IdemployeeInternal).HasColumnName("IDEmployeeInternal");

                entity.Property(e => e.IdwageGroup).HasColumnName("IDWageGroup");

                entity.Property(e => e.LastEdited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Matchcode).HasMaxLength(50);

                entity.Property(e => e.TimeCardNo).HasMaxLength(50);

                entity.Property(e => e.WasCurrentFrom).HasColumnType("datetime");

                entity.Property(e => e.WasCurrentTo).HasColumnType("datetime");

                entity.HasOne(d => d.IdsubsidiaryNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Idsubsidiary)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Employees_Subsidiaries");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => new { d.Idsubsidiary, d.IdaddressDetails })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Employees_AddressDetails");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => new { d.Idsubsidiary, d.IdcostCenter })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Employees_CostCenter");

                entity.HasOne(d => d.Id1)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => new { d.Idsubsidiary, d.IdwageGroup })
                    .HasConstraintName("FK_Employees_WageGroups");
            });

            modelBuilder.Entity<FunctionLog>(entity =>
            {
                entity.HasKey(e => new { e.IdfunctionLog, e.Idsubsidiary })
                    .HasName("PK_FunctionLog");

                entity.Property(e => e.IdfunctionLog)
                    .HasColumnName("IDFunctionLog")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.CalledByIduser).HasColumnName("CalledByIDUser");

                entity.Property(e => e.DateCalled).HasColumnType("datetime");

                entity.Property(e => e.FunctionText).IsRequired();

                entity.Property(e => e.OnComputer).HasMaxLength(255);

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.FunctionLog)
                    .HasForeignKey(d => new { d.Idsubsidiary, d.CalledByIduser })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FunctionLog_Users");
            });

            modelBuilder.Entity<LabourValues>(entity =>
            {
                entity.HasKey(e => new { e.Idsubsidiary, e.IdlabourValue })
                    .HasName("PK_LabourValues");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.IdlabourValue)
                    .HasColumnName("IDLabourValue")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Dimension)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IdcostCenter).HasColumnName("IDCostCenter");

                entity.Property(e => e.IdlabourValueInternal).HasColumnName("IDLabourValueInternal");

                entity.Property(e => e.LabourValueName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastEdited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.TeHmin).HasColumnName("TeHMin");

                entity.Property(e => e.WasCurrentFrom).HasColumnType("datetime");

                entity.Property(e => e.WasCurrentTo).HasColumnType("datetime");

                entity.HasOne(d => d.IdsubsidiaryNavigation)
                    .WithMany(p => p.LabourValues)
                    .HasForeignKey(d => d.Idsubsidiary)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_LabourValues_Subsidiaries");
            });

            modelBuilder.Entity<NotificationRecipients>(entity =>
            {
                entity.HasKey(e => new { e.Idsubsidiary, e.IdnotificationRecipient })
                    .HasName("PK_NotificationRecepients");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.IdnotificationRecipient)
                    .HasColumnName("IDNotificationRecipient")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastEdited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Smtpaddress)
                    .IsRequired()
                    .HasColumnName("SMTPAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.SmtpaddressFallOver)
                    .HasColumnName("SMTPAddressFallOver")
                    .HasMaxLength(255);

                entity.Property(e => e.Tag).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.IdsubsidiaryNavigation)
                    .WithMany(p => p.NotificationRecipients)
                    .HasForeignKey(d => d.Idsubsidiary)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_NotificationRecepients_Subsidiaries");
            });

            modelBuilder.Entity<ParamsEmployees>(entity =>
            {
                entity.HasKey(e => new { e.Idsubsidiary, e.IdparamsEmployees, e.Iduser, e.Ticket })
                    .HasName("PK_ParamsEmployees");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.IdparamsEmployees)
                    .HasColumnName("IDParamsEmployees")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Ticket).HasColumnType("datetime");

                entity.Property(e => e.Idemployee).HasColumnName("IDEmployee");

                entity.HasOne(d => d.IdsubsidiaryNavigation)
                    .WithMany(p => p.ParamsEmployees)
                    .HasForeignKey(d => d.Idsubsidiary)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ParamsEmployees_Subsidiaries");
            });

            modelBuilder.Entity<ParamsProductionDates>(entity =>
            {
                entity.HasKey(e => new { e.Idsubsidiary, e.IdparamsProductionDates, e.Iduser, e.Ticket })
                    .HasName("PK_ParamsProductionDates");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.IdparamsProductionDates)
                    .HasColumnName("IDParamsProductionDates")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Ticket).HasColumnType("datetime");

                entity.Property(e => e.ProductionDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdsubsidiaryNavigation)
                    .WithMany(p => p.ParamsProductionDates)
                    .HasForeignKey(d => d.Idsubsidiary)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ParamsProductionDates_Subsidiaries");
            });

            modelBuilder.Entity<ParamsWorkGroups>(entity =>
            {
                entity.HasKey(e => new { e.Idsubsidiary, e.IdparamsWorkGroups, e.Iduser, e.Ticket })
                    .HasName("PK_ParamsWorkGroups");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.IdparamsWorkGroups)
                    .HasColumnName("IDParamsWorkGroups")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Ticket).HasColumnType("datetime");

                entity.Property(e => e.IdworkGroup).HasColumnName("IDWorkGroup");

                entity.HasOne(d => d.IdsubsidiaryNavigation)
                    .WithMany(p => p.ParamsWorkGroups)
                    .HasForeignKey(d => d.Idsubsidiary)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ParamsWorkGroups_Subsidiaries");
            });

            modelBuilder.Entity<ProductionData>(entity =>
            {
                entity.HasKey(e => new { e.Idsubsidiary, e.IdproductionData })
                    .HasName("PK_ProductionData");

                entity.HasIndex(e => new { e.Idsubsidiary, e.ProductionDate, e.Shift, e.IdworkGroup })
                    .HasName("IX_AccessData");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.IdproductionData)
                    .HasColumnName("IDProductionData")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.DegreeOfTime).HasDefaultValueSql("-1");

                entity.Property(e => e.DegreeOfTimeAdj).HasDefaultValueSql("-1");

                entity.Property(e => e.Idemployee)
                    .HasColumnName("IDEmployee")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.IdworkGroup).HasColumnName("IDWorkGroup");

                entity.Property(e => e.IdworkGroupInternal).HasColumnName("IDWorkGroupInternal");

                entity.Property(e => e.LastEdited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.LastEditedByIduser).HasColumnName("LastEditedByIDUser");

                entity.Property(e => e.ProductionDate).HasColumnType("datetime");

                entity.Property(e => e.TotalDownTime).HasDefaultValueSql("-1");

                entity.Property(e => e.TotalEffectiveIwt)
                    .HasColumnName("TotalEffectiveIWT")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.TotalEffectiveIwtadj)
                    .HasColumnName("TotalEffectiveIWTAdj")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.TotalReferenceIwt)
                    .HasColumnName("TotalReferenceIWT")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.TotalWorkBreakTime).HasDefaultValueSql("-1");

                entity.HasOne(d => d.IdsubsidiaryNavigation)
                    .WithMany(p => p.ProductionData)
                    .HasForeignKey(d => d.Idsubsidiary)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductionData_Subsidiaries");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.ProductionData)
                    .HasForeignKey(d => new { d.Idsubsidiary, d.IdworkGroup })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductionData_WorkGroups");
            });

            modelBuilder.Entity<ProductionDataItems>(entity =>
            {
                entity.HasKey(e => new { e.Idsubsidiary, e.IdproductionDataItem })
                    .HasName("PK_ProductionDataItems");

                entity.HasIndex(e => new { e.Idsubsidiary, e.IdproductionData })
                    .HasName("IX_ProductionData");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.IdproductionDataItem)
                    .HasColumnName("IDProductionDataItem")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.AmountViaInterface).HasDefaultValueSql("-1");

                entity.Property(e => e.Idarticle).HasColumnName("IDArticle");

                entity.Property(e => e.IdlabourValue).HasColumnName("IDLabourValue");

                entity.Property(e => e.IdproductionData).HasColumnName("IDProductionData");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.ProductionDataItems)
                    .HasForeignKey(d => new { d.Idsubsidiary, d.IdproductionData })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductionDataItems_ProductionData");
            });

            modelBuilder.Entity<ProductionDataItemsForInsert>(entity =>
            {
                entity.HasKey(e => new { e.Idsubsidiary, e.IdproductionDataItemForInsert })
                    .HasName("PK_ProductionDataItemForInsert");

                entity.HasIndex(e => new { e.Idsubsidiary, e.Iduser, e.IdproductionData })
                    .HasName("IX_ForFastFinding");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.IdproductionDataItemForInsert)
                    .HasColumnName("IDProductionDataItemForInsert")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Idarticle).HasColumnName("IDArticle");

                entity.Property(e => e.IdlabourValue).HasColumnName("IDLabourValue");

                entity.Property(e => e.IdproductionData).HasColumnName("IDProductionData");

                entity.Property(e => e.IdproductionDataItem).HasColumnName("IDProductionDataItem");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Ticket).HasColumnType("datetime");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.ProductionDataItemsForInsert)
                    .HasForeignKey(d => new { d.Idsubsidiary, d.IdproductionData })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ProductionDataItemsForInsert_ProductionData");
            });

            modelBuilder.Entity<SkillNeeded>(entity =>
            {
                entity.HasKey(e => new { e.IdskillNeeded, e.Idsubsidiary })
                    .HasName("PK_SkillNeeded");

                entity.Property(e => e.IdskillNeeded)
                    .HasColumnName("IDSkillNeeded")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.Idskill).HasColumnName("IDSkill");

                entity.Property(e => e.IdworkGroup).HasColumnName("IDWorkGroup");

                entity.Property(e => e.LastEdited).HasColumnType("datetime");

                entity.HasOne(d => d.Ids)
                    .WithMany(p => p.SkillNeeded)
                    .HasForeignKey(d => new { d.Idskill, d.Idsubsidiary })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SkillNeeded_Skill");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.SkillNeeded)
                    .HasForeignKey(d => new { d.Idsubsidiary, d.IdworkGroup })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SkillNeeded_WorkGroups");
            });

            modelBuilder.Entity<SkillProvided>(entity =>
            {
                entity.HasKey(e => new { e.IdskillProvided, e.Idsubsidiary })
                    .HasName("PK_SkillProvided");

                entity.Property(e => e.IdskillProvided)
                    .HasColumnName("IDSkillProvided")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.Idemployee).HasColumnName("IDEmployee");

                entity.Property(e => e.Idskill).HasColumnName("IDSkill");

                entity.Property(e => e.LastEdited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(d => d.Ids)
                    .WithMany(p => p.SkillProvided)
                    .HasForeignKey(d => new { d.Idskill, d.Idsubsidiary })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SkillProvided_Skill");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.SkillProvided)
                    .HasForeignKey(d => new { d.Idsubsidiary, d.Idemployee })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SkillProvided_Employees");
            });

            modelBuilder.Entity<Skills>(entity =>
            {
                entity.HasKey(e => new { e.Idskill, e.Idsubsidiary })
                    .HasName("PK_Skills");

                entity.Property(e => e.Idskill)
                    .HasColumnName("IDSkill")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.LastEdited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.SkillDescription).IsRequired();

                entity.HasOne(d => d.IdsubsidiaryNavigation)
                    .WithMany(p => p.Skills)
                    .HasForeignKey(d => d.Idsubsidiary)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Skills_Subsidiaries");
            });

            modelBuilder.Entity<Subsidiaries>(entity =>
            {
                entity.HasKey(e => e.Idsubsidiary)
                    .HasName("PK_Subsidiaries");

                entity.Property(e => e.Idsubsidiary)
                    .HasColumnName("IDSubsidiary")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.LastEdited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.PrimaryPhone)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SubsidiaryName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TimeLog>(entity =>
            {
                entity.HasKey(e => new { e.Idsubsidiary, e.IdtimeLog })
                    .HasName("PK_TimeLog");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.IdtimeLog)
                    .HasColumnName("IDTimeLog")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.AttendanceTime).HasDefaultValueSql("-1");

                entity.Property(e => e.DegreeOfTime).HasDefaultValueSql("-1");

                entity.Property(e => e.DegreeOfTimeAdj).HasDefaultValueSql("-1");

                entity.Property(e => e.DownTime).HasDefaultValueSql("-1");

                entity.Property(e => e.EditedByIduser).HasColumnName("EditedByIDUser");

                entity.Property(e => e.IdbonusLists).HasColumnName("IDBonusLists");

                entity.Property(e => e.Idemployee).HasColumnName("IDEmployee");

                entity.Property(e => e.IdemployeeInternal).HasColumnName("IDEmployeeInternal");

                entity.Property(e => e.IdwageGroup).HasColumnName("IDWageGroup");

                entity.Property(e => e.IdworkGroup).HasColumnName("IDWorkGroup");

                entity.Property(e => e.IdworkGroupInternal).HasColumnName("IDWorkGroupInternal");

                entity.Property(e => e.IncentiveWageTime).HasDefaultValueSql("-1");

                entity.Property(e => e.IncentiveWageTimeAdj).HasDefaultValueSql("-1");

                entity.Property(e => e.LastEdited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ProductionDate).HasColumnType("datetime");

                entity.Property(e => e.ReferenceWageTimeProRata).HasDefaultValueSql("-1");

                entity.Property(e => e.ShiftEnd).HasColumnType("datetime");

                entity.Property(e => e.ShiftEndViaInterface).HasColumnType("datetime");

                entity.Property(e => e.ShiftStart).HasColumnType("datetime");

                entity.Property(e => e.ShiftStartViaInterface).HasColumnType("datetime");

                entity.Property(e => e.WorkBreak).HasDefaultValueSql("-1");

                entity.Property(e => e.WorkingTime).HasDefaultValueSql("-1");

                entity.HasOne(d => d.IdsubsidiaryNavigation)
                    .WithMany(p => p.TimeLog)
                    .HasForeignKey(d => d.Idsubsidiary)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TimeLog_Subsidiaries");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.TimeLog)
                    .HasForeignKey(d => new { d.Idsubsidiary, d.Idemployee })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TimeLog_Employee");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.TimeLog)
                    .HasForeignKey(d => new { d.Idsubsidiary, d.IdworkGroup })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TimeLog_WorkGroup");
            });

            modelBuilder.Entity<TimeLogForInsert>(entity =>
            {
                entity.HasKey(e => new { e.IdtimeLogForInsert, e.Idsubsidiary })
                    .HasName("PK_TimeLogForInsert");

                entity.Property(e => e.IdtimeLogForInsert)
                    .HasColumnName("IDTimeLogForInsert")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.EditedByIduser).HasColumnName("EditedByIDUser");

                entity.Property(e => e.Idemployee).HasColumnName("IDEmployee");

                entity.Property(e => e.IdtimeLog).HasColumnName("IDTimeLog");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.IdworkGroup).HasColumnName("IDWorkGroup");

                entity.Property(e => e.ProductionDate).HasColumnType("datetime");

                entity.Property(e => e.ShiftEnd).HasColumnType("datetime");

                entity.Property(e => e.ShiftStart).HasColumnType("datetime");

                entity.Property(e => e.Ticket).HasColumnType("datetime");

                entity.HasOne(d => d.IdsubsidiaryNavigation)
                    .WithMany(p => p.TimeLogForInsert)
                    .HasForeignKey(d => d.Idsubsidiary)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TimeLogForInsert_Subsidiaries");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => new { e.Idsubsidiary, e.Iduser })
                    .HasName("PK_Users");

                entity.HasIndex(e => e.IdaddressDetails)
                    .HasName("IX_Users_IDAddressDetails");

                entity.HasIndex(e => e.IduserInternal)
                    .HasName("IX_IDUserInternal");

                entity.HasIndex(e => e.Username)
                    .HasName("IX_Username");

                entity.HasIndex(e => new { e.LastName, e.FirstName })
                    .HasName("IX_UsersLastNameFirstName");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.Iduser)
                    .HasColumnName("IDUser")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.Comment).HasColumnType("ntext");

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IdaddressDetails).HasColumnName("IDAddressDetails");

                entity.Property(e => e.IdcostCenter).HasColumnName("IDCostCenter");

                entity.Property(e => e.IduserInternal).HasColumnName("IDUserInternal");

                entity.Property(e => e.LastEdited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WasCurrentFrom).HasColumnType("datetime");

                entity.Property(e => e.WasCurrentTo).HasColumnType("datetime");

                entity.HasOne(d => d.IdsubsidiaryNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Idsubsidiary)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Users_Subsidiaries");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => new { d.Idsubsidiary, d.IdaddressDetails })
                    .HasConstraintName("FK_Users_AddressDetails");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => new { d.Idsubsidiary, d.IdcostCenter })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Users_CostCenters");
            });

            modelBuilder.Entity<WageGroups>(entity =>
            {
                entity.HasKey(e => new { e.Idsubsidiary, e.IdwageGroup })
                    .HasName("PK_WageGroups");

                entity.HasIndex(e => e.WageGroupToken)
                    .HasName("IX_WageGroups_WageGroupToken")
                    .IsUnique();

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.IdwageGroup)
                    .HasColumnName("IDWageGroup")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.HourlyRate).HasColumnType("money");

                entity.Property(e => e.Idcurrency).HasColumnName("IDCurrency");

                entity.Property(e => e.IdwageGroupInternal).HasColumnName("IDWageGroupInternal");

                entity.Property(e => e.LastEdited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.WageGroupToken)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.WasCurrentFrom).HasColumnType("datetime");

                entity.Property(e => e.WasCurrentTo).HasColumnType("datetime");

                entity.HasOne(d => d.IdcurrencyNavigation)
                    .WithMany(p => p.WageGroups)
                    .HasForeignKey(d => d.Idcurrency)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_WageGroups_Currencies");

                entity.HasOne(d => d.IdsubsidiaryNavigation)
                    .WithMany(p => p.WageGroups)
                    .HasForeignKey(d => d.Idsubsidiary)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_WageGroups_Subsidiaries");
            });

            modelBuilder.Entity<WorkGroupAssignments>(entity =>
            {
                entity.HasKey(e => new { e.Idsubsidiary, e.IdworkGroupAssignment })
                    .HasName("PK_WorkGroupAssignments");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.IdworkGroupAssignment)
                    .HasColumnName("IDWorkGroupAssignment")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.IdlabourValueInternal).HasColumnName("IDLabourValueInternal");

                entity.Property(e => e.IdworkGroupInternal).HasColumnName("IDWorkGroupInternal");

                entity.Property(e => e.LastEdited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(d => d.IdsubsidiaryNavigation)
                    .WithMany(p => p.WorkGroupAssignments)
                    .HasForeignKey(d => d.Idsubsidiary)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_WorkGroupAssignments_Subsidiaries");
            });

            modelBuilder.Entity<WorkGroups>(entity =>
            {
                entity.HasKey(e => new { e.Idsubsidiary, e.IdworkGroup })
                    .HasName("PK_WorkGroups");

                entity.Property(e => e.Idsubsidiary).HasColumnName("IDSubsidiary");

                entity.Property(e => e.IdworkGroup)
                    .HasColumnName("IDWorkGroup")
                    .HasDefaultValueSql("newsequentialid()");

                entity.Property(e => e.IdcostCenter).HasColumnName("IDCostCenter");

                entity.Property(e => e.IdworkGroupInternal).HasColumnName("IDWorkGroupInternal");

                entity.Property(e => e.IsConceptional).HasDefaultValueSql("'false'");

                entity.Property(e => e.LastEdited)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.TimeSettingDetails)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.WasCurrentFrom).HasColumnType("datetime");

                entity.Property(e => e.WasCurrentTo).HasColumnType("datetime");

                entity.Property(e => e.WorkgroupName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WorkloadIwt)
                    .HasColumnName("WorkloadIWT")
                    .HasDefaultValueSql("480");

                entity.HasOne(d => d.IdsubsidiaryNavigation)
                    .WithMany(p => p.WorkGroups)
                    .HasForeignKey(d => d.Idsubsidiary)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_WorkGroups_Subsidiaries");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.WorkGroups)
                    .HasForeignKey(d => new { d.Idsubsidiary, d.IdcostCenter })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_WorkGroups_CostCenter");
            });
        }

        public virtual DbSet<AddressDetails> AddressDetails { get; set; }
        public virtual DbSet<ApplicationSettings> ApplicationSettings { get; set; }
        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<BonusList> BonusList { get; set; }
        public virtual DbSet<BonusLists> BonusLists { get; set; }
        public virtual DbSet<CostCenters> CostCenters { get; set; }
        public virtual DbSet<Currencies> Currencies { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<FunctionLog> FunctionLog { get; set; }
        public virtual DbSet<LabourValues> LabourValues { get; set; }
        public virtual DbSet<NotificationRecipients> NotificationRecipients { get; set; }
        public virtual DbSet<ParamsEmployees> ParamsEmployees { get; set; }
        public virtual DbSet<ParamsProductionDates> ParamsProductionDates { get; set; }
        public virtual DbSet<ParamsWorkGroups> ParamsWorkGroups { get; set; }
        public virtual DbSet<ProductionData> ProductionData { get; set; }
        public virtual DbSet<ProductionDataItems> ProductionDataItems { get; set; }
        public virtual DbSet<ProductionDataItemsForInsert> ProductionDataItemsForInsert { get; set; }
        public virtual DbSet<SkillNeeded> SkillNeeded { get; set; }
        public virtual DbSet<SkillProvided> SkillProvided { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<Subsidiaries> Subsidiaries { get; set; }
        public virtual DbSet<TimeLog> TimeLog { get; set; }
        public virtual DbSet<TimeLogForInsert> TimeLogForInsert { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WageGroups> WageGroups { get; set; }
        public virtual DbSet<WorkGroupAssignments> WorkGroupAssignments { get; set; }
        public virtual DbSet<WorkGroups> WorkGroups { get; set; }

        // Unable to generate entity type for table 'dbo.EmployeeHandicaps'. Please see the warning messages.
    }
}