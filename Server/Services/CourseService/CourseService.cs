using FERITOrganizator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FERITOrganizator.Server.Services.CourseService
{
    public class CourseService : ICourseService
    {
        public async Task<List<CourseData>> GetCourses()
        {
            List<CourseData> Courses = new List<CourseData>
            {
                new CourseData(){ CourseId = "Elektrotehnika, izb. blok EE", Category = "Preddiplomski studij", 
                    Name = "Sveučilišni preddiplomski studij elektrotehnike, izb. blok EE"}, //1

                new CourseData(){ CourseId = "Elektrotehnika, izb. blok KI", Category = "Preddiplomski studij", 
                    Name = "Sveučilišni preddiplomski studij elektrotehnike, izb. blok KI"}, //21

                new CourseData(){ CourseId = "Računarstvo", Category = "Preddiplomski studij", 
                    Name = "Sveučilišni preddiplomski studij računarstva"}, //2

                new CourseData(){ CourseId = "Računarstvo, smjer PI", Category = "Preddiplomski studij", 
                    Name = "Sveučilišni preddiplomski studij računarstva, Programsko inženjerstvo"}, //59

                new CourseData(){ CourseId = "Računarstvo, smjer RI", Category = "Preddiplomski studij", 
                    Name = "Sveučilišni preddiplomski studij računarstva, Računalno inženjerstvo"}, //60

                new CourseData(){ CourseId = "Komunikacije i informatika, izb. blok KT", Category = "Diplomski studij Elektrotehnika", 
                    Name = "Sveučilišni diplomski studij Elektrotehnika, smjer Komunikacije i informatika, izborni blok Komunikacijske tehnologije"}, //34 DKA

                new CourseData(){ CourseId = "Komunikacije i informatika, izb. blok MT", Category = "Diplomski studij Elektrotehnika", 
                    Name = "Sveučilišni diplomski studij Elektrotehnika, smjer Komunikacije i informatika, izborni blok Mrežne tehnologije"}, //35 DKB

                new CourseData(){ CourseId = "Elektroenergetika, izb. blok ES", Category = "Diplomski studij Elektrotehnika", 
                    Name = "Sveučilišni diplomski studij Elektrotehnika, smjer Elektroenergetika, izborni blok Elektroenergetski sustavi"}, //31 DEA

                new CourseData(){ CourseId = "Elektroenergetika, izb. blok OE", Category = "Diplomski studij Elektrotehnika", 
                    Name = "Sveučilišni diplomski studij Elektrotehnika, smjer Elektroenergetika, izborni blok Održiva elektroenergetika"}, //32 DEB

                new CourseData(){ CourseId = "Elektroenergetika, izb. blok IE", Category = "Diplomski studij Elektrotehnika", 
                    Name = "Sveučilišni diplomski studij Elektrotehnika, smjer Elektroenergetika, izborni blok Industrijska elektroenergetika"}, //33 DEC

                new CourseData(){ CourseId = "izb. blok Računalno inženjerstvo", Category = "Diplomski studij Računarstvo", 
                    Name = "Sveučilišni diplomski studij Računarstvo, izborni blok Računalno inženjerstvo"}, //36 DRA

                new CourseData(){ CourseId = "izb. blok Robotika i umjetna inteligencija", Category = "Diplomski studij Računarstvo", 
                    Name = "Sveučilišni diplomski studij Računarstvo, izborni blok Robotika i umjetna inteligencija"}, //54 DRB2

                new CourseData(){ CourseId = "izb. blok Programsko inženjerstvo", Category = "Diplomski studij Računarstvo", 
                    Name = "Sveučilišni diplomski studij Računarstvo, izborni blok Programsko inženjerstvo"}, //38 DRC

                new CourseData(){ CourseId = "izb. blok Informacijske i podatkovne znanosti", Category = "Diplomski studij Računarstvo", 
                    Name = "Sveučilišni diplomski studij Računarstvo, izborni blok Informacijske i podatkovne znanosti"}, //39 DRD

                new CourseData(){ CourseId = "na hrvatskom jeziku", Category = "Diplomski studij Automobilsko rač. i kom.", 
                    Name = "Sveučilišni diplomski studij Automobilsko računarstvo i komunikacije"}, //52 DA hrv

                new CourseData(){ CourseId = "na engleskom jeziku", Category = "Diplomski studij Automobilsko rač. i kom.", 
                    Name = "Sveučilišni diplomski studij Automobilsko računarstvo i komunikacije"}, //58 DA ENG

                new CourseData(){ CourseId = "Računarstvo", Category = "Stručni studij", Name = "Stručni studij računarstva"}, //53

                new CourseData(){ CourseId = "Elektrotehnika, smjer A", Category = "Stručni studij", 
                    Name = "Stručni studij elektrotehnike, smjer Automatika"}, //8

                new CourseData(){ CourseId = "Elektrotehnika, smjer E", Category = "Stručni studij", 
                    Name = "Stručni studij elektrotehnike, smjer Elektroenergetika"}, //9

                new CourseData(){ CourseId = "Računarstvo (izb. blok I)", Category = "Razlikovne obveze", 
                    Name = "Razlikovne obveze, smjer Računarstvo (izb. blok I)"}, //42

                new CourseData(){ CourseId = "Računarstvo (izb. blok A)", Category = "Razlikovne obveze", 
                    Name = "Razlikovne obveze, smjer Računarstvo (izb. blok A)"}, //24

                new CourseData(){ CourseId = "Elektroenergetika (izb. blok E)", Category = "Razlikovne obveze", 
                    Name = "Razlikovne obveze, Elektroenergetika (izb. blok E)"}, //41

                new CourseData(){ CourseId = "Elektroenergetika (izb. blok A)", Category = "Razlikovne obveze", 
                    Name = "Razlikovne obveze, Elektroenergetika (izb. blok A)"}, //23

                new CourseData(){ CourseId = "Komunikacije i informatika (izb. blok I)", Category = "Razlikovne obveze", 
                    Name = "Razlikovne obveze, smjer Komunikacije i informatika (izb. blok I)"}, //40

                new CourseData(){ CourseId = "Komunikacije i informatika (izb. blok A)", Category = "Razlikovne obveze", 
                    Name = "Razlikovne obveze, smjer Komunikacije i informatika (izb. blok A)"}, //22
            };
            return Courses;
        }
    }
}
