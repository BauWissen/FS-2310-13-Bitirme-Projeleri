using IsKapisi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsKapisi.Data.Config
{
    public class JobConfig : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(j => j.Id);
            builder.Property(j => j.Id).ValueGeneratedOnAdd();
            builder.Property(j => j.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(j=>j.Properties)
                .IsRequired()
                .HasMaxLength(100);
           builder.Property(j => j.ImageUrl)
                .IsRequired();
            builder.ToTable("Jobs");

            builder.HasData(
                new Job
                {
                    Id = 1,
                    Name = "Kimya Öğretmeni",
                    Properties = "Deneyimli Öğretmen",
                    Url = "kimya-ogretmen",
                    ImageUrl = "1.png",
                    IsHome = true,
                },
              new Job
              {
                  Id = 2,
                  Name = "İnsan Kaynakları Uzmanı",
                  Properties = " En az 3 yıl tecrübeli",
                  Url = "insan-kaynaklari-uzmani",
                  ImageUrl = "2.png",
                  IsHome = false,
              },
              new Job
              {
                  Id = 3,
                  Name = "Kıdemli Avukat",
                  Properties = "Deneyimi 5 - 10 yıl arası",
                  Url = "avukat",
                  ImageUrl = "3.png",
                  IsHome = true,
              },
              new Job
              {
                  Id = 4,
                  Name = "Yazılım Destek Elemanı",
                  Properties = "Tecrübeli/Tecrübesiz",
                  Url = "yazilim-destek-uzmani",
                  ImageUrl = "4.png",
                  IsHome = true,
              },
              new Job
              {
                  Id = 5,
                  Name = "Backend Developer (İstanbul-Ankara-İzmir)",
                  Properties = "  En az 3 yıl deneyimli,",
                  Url = "back-end-gelistirici",
                  ImageUrl = "5.png",
                  IsHome = true,
              },
              new Job
              {
                  Id = 6,
                  Name = "React Front-End Geliştirici",
                  Properties = "2 - 6 yıl arası",
                  Url = "react-front-end",
                  ImageUrl = "6.png",
                  IsHome = false,
              },
              new Job
              {
                  Id = 7,
                  Name = "React Native Developer",
                  Properties = "En az 3 yıl deneyimli",
                  Url = "react-native",
                  ImageUrl = "7.png",
                  IsHome = true,
              },
              new Job
              {
                  Id = 8,
                  Name = "Data Science Professionals - Discovery (İstanbul, Ankara, İzmir)",
                  Properties = "Uzman",
                  Url = "data-science",
                  ImageUrl = "8.png",
                  IsHome = false,
              },
              new Job
              {
                  Id = 9,
                  Name = "İdari İşler Profesyonelleri ",
                  Properties = "Minimum 7 yıl idari işler alanında deneyimli",
                  Url = "idari-isler",
                  ImageUrl = "9.png",
                  IsHome = true,
              },
            new Job
            {
                Id = 10,
                Name = "Front-end Developer ",
                Properties = "Minimum 7 yıl react üzerinde çalışmış",
                Url = "idari-isler",
                ImageUrl = "10.png",
                IsHome = true,
            },
            new Job
            {
                Id = 11,
                Name = "Müzik Öğretmeni",

                Properties = "En az 10 yıl tecrübeli",
                Url = "muzik-ogretmen",
                ImageUrl = "11.png",
                IsHome = true
            }
            );

            
        }
    }
}
