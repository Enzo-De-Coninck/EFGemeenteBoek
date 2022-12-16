﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.Repositories;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(EFGemeenteBoekContext))]
    partial class EFGemeenteBoekContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Model.Entities.Adres", b =>
                {
                    b.Property<int>("AdresId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdresId"));

                    b.Property<string>("BusNr")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("HuisNr")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("StraatId")
                        .HasColumnType("int");

                    b.HasKey("AdresId");

                    b.HasIndex("StraatId", "HuisNr", "BusNr")
                        .IsUnique()
                        .HasFilter("[BusNr] IS NOT NULL");

                    b.ToTable("Adressen", (string)null);
                });

            modelBuilder.Entity("Model.Entities.Afdeling", b =>
                {
                    b.Property<int>("AfdelingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AfdelingId"));

                    b.Property<string>("AfdelingCode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("AfdelingNaam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AfdelingTekst")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AfdelingId");

                    b.HasIndex("AfdelingCode")
                        .IsUnique();

                    b.HasIndex("AfdelingNaam")
                        .IsUnique();

                    b.ToTable("Afdelingen", (string)null);
                });

            modelBuilder.Entity("Model.Entities.Bericht", b =>
                {
                    b.Property<int>("BerichtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BerichtId"));

                    b.Property<string>("BerichtTekst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BerichtTijdstip")
                        .HasColumnType("datetime2");

                    b.Property<string>("BerichtTitel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("BerichtTypeId")
                        .HasColumnType("int");

                    b.Property<int>("GemeenteId")
                        .HasColumnType("int");

                    b.Property<int?>("HoofdBerichtId")
                        .HasColumnType("int");

                    b.Property<int>("PersoonId")
                        .HasColumnType("int");

                    b.HasKey("BerichtId");

                    b.HasIndex("BerichtTypeId");

                    b.HasIndex("GemeenteId");

                    b.HasIndex("HoofdBerichtId");

                    b.HasIndex("PersoonId");

                    b.ToTable("Berichten", (string)null);
                });

            modelBuilder.Entity("Model.Entities.BerichtType", b =>
                {
                    b.Property<int>("BerichtTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BerichtTypeId"));

                    b.Property<string>("BerichtTypeCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("BerichtTypeNaam")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("BerichtTypeTekst")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BerichtTypeId");

                    b.HasIndex("BerichtTypeCode")
                        .IsUnique();

                    b.ToTable("BerichtTypes", (string)null);
                });

            modelBuilder.Entity("Model.Entities.Gemeente", b =>
                {
                    b.Property<int>("GemeenteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GemeenteId"));

                    b.Property<string>("GemeenteNaam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("HoofdGemeenteId")
                        .HasColumnType("int");

                    b.Property<int>("PostCode")
                        .HasColumnType("int");

                    b.Property<int>("ProvincieId")
                        .HasColumnType("int");

                    b.Property<int>("TaalId")
                        .HasColumnType("int");

                    b.HasKey("GemeenteId");

                    b.HasIndex("GemeenteNaam")
                        .IsUnique();

                    b.HasIndex("HoofdGemeenteId");

                    b.HasIndex("ProvincieId");

                    b.HasIndex("TaalId");

                    b.ToTable("Gemeenten", (string)null);
                });

            modelBuilder.Entity("Model.Entities.InteresseSoort", b =>
                {
                    b.Property<int>("InteresseSoortId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InteresseSoortId"));

                    b.Property<string>("InteresseSoortNaam")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("InteresseSoortId");

                    b.HasIndex("InteresseSoortNaam")
                        .IsUnique();

                    b.ToTable("InteresseSoorten", (string)null);
                });

            modelBuilder.Entity("Model.Entities.Persoon", b =>
                {
                    b.Property<int>("PersoonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersoonId"));

                    b.Property<int>("AdresId")
                        .HasColumnType("int");

                    b.Property<string>("FamilieNaam")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("Geblokkeerd")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("GeboorteDatum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GeboorteplaatsId")
                        .HasColumnType("int");

                    b.Property<int>("Geslacht")
                        .HasColumnType("int");

                    b.Property<int>("LoginAantal")
                        .HasColumnType("int");

                    b.Property<string>("LoginNaam")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LoginPaswoord")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PersoonType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaalId")
                        .HasColumnType("int");

                    b.Property<string>("TelefoonNr")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("VerkeerdeLoginsAantal")
                        .HasColumnType("int");

                    b.Property<string>("VoorNaam")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PersoonId");

                    b.HasIndex("AdresId");

                    b.HasIndex("GeboorteplaatsId");

                    b.HasIndex("LoginNaam")
                        .IsUnique();

                    b.HasIndex("TaalId");

                    b.ToTable("Personen", (string)null);

                    b.HasDiscriminator<string>("PersoonType").HasValue("Persoon");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Model.Entities.ProfielInteresse", b =>
                {
                    b.Property<int>("PersoonId")
                        .HasColumnType("int");

                    b.Property<int>("InteresseSoortId")
                        .HasColumnType("int");

                    b.Property<string>("ProfielInteresseTekst")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersoonId", "InteresseSoortId");

                    b.HasIndex("InteresseSoortId");

                    b.ToTable("ProfielInteresses", (string)null);
                });

            modelBuilder.Entity("Model.Entities.Provincie", b =>
                {
                    b.Property<int>("ProvincieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProvincieId"));

                    b.Property<string>("ProvincieCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("ProvincieNaam")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ProvincieId");

                    b.HasIndex("ProvincieCode")
                        .IsUnique();

                    b.HasIndex("ProvincieNaam")
                        .IsUnique();

                    b.ToTable("Provincies", (string)null);
                });

            modelBuilder.Entity("Model.Entities.Straat", b =>
                {
                    b.Property<int>("StraatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StraatId"));

                    b.Property<int>("GemeenteId")
                        .HasColumnType("int");

                    b.Property<string>("StraatNaam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StraatId");

                    b.HasIndex("GemeenteId");

                    b.HasIndex("StraatNaam", "GemeenteId")
                        .IsUnique();

                    b.ToTable("Straten", (string)null);
                });

            modelBuilder.Entity("Model.Entities.Taal", b =>
                {
                    b.Property<int>("TaalId")
                        .HasColumnType("int");

                    b.Property<string>("TaalCode")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("TaalNaam")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("TaalId", "TaalCode");

                    b.ToTable("Talen", (string)null);
                });

            modelBuilder.Entity("Model.Entities.Medewerker", b =>
                {
                    b.HasBaseType("Model.Entities.Persoon");

                    b.Property<int>("AfdelingId")
                        .HasColumnType("int");

                    b.HasIndex("AfdelingId");

                    b.HasDiscriminator().HasValue("M");
                });

            modelBuilder.Entity("Model.Entities.Profiel", b =>
                {
                    b.HasBaseType("Model.Entities.Persoon");

                    b.Property<string>("BeroepTekst")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("CreatieTijdstip")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAdres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FacebookNaam")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirmaNaam")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("GoedgekeurdTijdstip")
                        .HasColumnType("datetime2");

                    b.Property<string>("KennismakingTekst")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("LaatsteUpdateTijdstip")
                        .HasColumnType("datetime2");

                    b.Property<string>("WebsiteAdres")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("WoontHierSindsDatum")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("P");
                });

            modelBuilder.Entity("Model.Entities.Adres", b =>
                {
                    b.HasOne("Model.Entities.Straat", "Straat")
                        .WithMany("Adressen")
                        .HasForeignKey("StraatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Straat");
                });

            modelBuilder.Entity("Model.Entities.Bericht", b =>
                {
                    b.HasOne("Model.Entities.BerichtType", "BerichtType")
                        .WithMany("Berichten")
                        .HasForeignKey("BerichtTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Model.Entities.Gemeente", "Gemeente")
                        .WithMany("Berichten")
                        .HasForeignKey("GemeenteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Model.Entities.Bericht", "HoofdBericht")
                        .WithMany("Berichten")
                        .HasForeignKey("HoofdBerichtId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Model.Entities.Profiel", "Profiel")
                        .WithMany("Berichten")
                        .HasForeignKey("PersoonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BerichtType");

                    b.Navigation("Gemeente");

                    b.Navigation("HoofdBericht");

                    b.Navigation("Profiel");
                });

            modelBuilder.Entity("Model.Entities.Gemeente", b =>
                {
                    b.HasOne("Model.Entities.Gemeente", "Hoofdgemeente")
                        .WithMany("Gemeenten")
                        .HasForeignKey("HoofdGemeenteId");

                    b.HasOne("Model.Entities.Provincie", "Provincie")
                        .WithMany("Gemeenten")
                        .HasForeignKey("ProvincieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Taal", "Taal")
                        .WithMany("Gemeenten")
                        .HasForeignKey("TaalId")
                        .HasPrincipalKey("TaalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hoofdgemeente");

                    b.Navigation("Provincie");

                    b.Navigation("Taal");
                });

            modelBuilder.Entity("Model.Entities.Persoon", b =>
                {
                    b.HasOne("Model.Entities.Adres", "Adres")
                        .WithMany("Personen")
                        .HasForeignKey("AdresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Gemeente", "Geboorteplaats")
                        .WithMany("Personen")
                        .HasForeignKey("GeboorteplaatsId");

                    b.HasOne("Model.Entities.Taal", "Taal")
                        .WithMany("Personen")
                        .HasForeignKey("TaalId")
                        .HasPrincipalKey("TaalId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Adres");

                    b.Navigation("Geboorteplaats");

                    b.Navigation("Taal");
                });

            modelBuilder.Entity("Model.Entities.ProfielInteresse", b =>
                {
                    b.HasOne("Model.Entities.InteresseSoort", "InteresseSoort")
                        .WithMany("ProfielInteresses")
                        .HasForeignKey("InteresseSoortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Profiel", "Profiel")
                        .WithMany("ProfielInteresses")
                        .HasForeignKey("PersoonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InteresseSoort");

                    b.Navigation("Profiel");
                });

            modelBuilder.Entity("Model.Entities.Straat", b =>
                {
                    b.HasOne("Model.Entities.Gemeente", "Gemeente")
                        .WithMany()
                        .HasForeignKey("GemeenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gemeente");
                });

            modelBuilder.Entity("Model.Entities.Medewerker", b =>
                {
                    b.HasOne("Model.Entities.Afdeling", "Afdeling")
                        .WithMany("Medewerkers")
                        .HasForeignKey("AfdelingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Afdeling");
                });

            modelBuilder.Entity("Model.Entities.Adres", b =>
                {
                    b.Navigation("Personen");
                });

            modelBuilder.Entity("Model.Entities.Afdeling", b =>
                {
                    b.Navigation("Medewerkers");
                });

            modelBuilder.Entity("Model.Entities.Bericht", b =>
                {
                    b.Navigation("Berichten");
                });

            modelBuilder.Entity("Model.Entities.BerichtType", b =>
                {
                    b.Navigation("Berichten");
                });

            modelBuilder.Entity("Model.Entities.Gemeente", b =>
                {
                    b.Navigation("Berichten");

                    b.Navigation("Gemeenten");

                    b.Navigation("Personen");
                });

            modelBuilder.Entity("Model.Entities.InteresseSoort", b =>
                {
                    b.Navigation("ProfielInteresses");
                });

            modelBuilder.Entity("Model.Entities.Provincie", b =>
                {
                    b.Navigation("Gemeenten");
                });

            modelBuilder.Entity("Model.Entities.Straat", b =>
                {
                    b.Navigation("Adressen");
                });

            modelBuilder.Entity("Model.Entities.Taal", b =>
                {
                    b.Navigation("Gemeenten");

                    b.Navigation("Personen");
                });

            modelBuilder.Entity("Model.Entities.Profiel", b =>
                {
                    b.Navigation("Berichten");

                    b.Navigation("ProfielInteresses");
                });
#pragma warning restore 612, 618
        }
    }
}
