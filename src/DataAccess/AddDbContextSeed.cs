using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace DataAccess
{
    public class AddDbContextSeed
    {
        private readonly AppDbContext _ctx;

        public AddDbContextSeed(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task SeedAsync()
        {
            if (_ctx.SensorKinds.FirstOrDefault() == null)
            {
                _ctx.SensorKinds.AddRange(
                    GetPreconfiguredSensorKinds());

                await _ctx.SaveChangesAsync();
            }
        }

        private IEnumerable<SensorKind> GetPreconfiguredSensorKinds()
        {
            return new List<SensorKind>()
            {
                new SensorKind()
                {
                    Name = "DHT22",
                    ShortDescription = "Czujnik temp.",
                    Description =
                        "Czujnik do pomiaru temperatury z interfejsem cyfrowym, jednoprzewodowym. Zakres pomiarowy: wilgotność 0-100 %RH.",
                    Type = SensorTypeEnum.Input
                },
                new SensorKind()
                {
                    Name = "DHT22",
                    ShortDescription = "Czujnik wilgotności.",
                    Description =
                        "Czujnik do wilgotności powietrza z interfejsem cyfrowym, jednoprzewodowym. Zakres pomiarowy: wilgotność 0-100 %RH.",
                    Type = SensorTypeEnum.Input
                },
                new SensorKind()
                {
                    Name = "DHT11",
                    ShortDescription = "Czujnik wilgotności.",
                    Description =
                        "Czujnik do wilgotności powietrza z interfejsem cyfrowym, jednoprzewodowym. Zakres pomiarowy: wilgotność od 5 % do 95 % RH. ",
                    Type = SensorTypeEnum.Input
                },
                new SensorKind()
                {
                    Name = "DHT11",
                    ShortDescription = "Czujnik temp.",
                    Description =
                        "Czujnik do pomiaru temperatury z interfejsem cyfrowym, jednoprzewodowym. Zakres pomiarowy: wilgotność od 5 % do 95 % RH. ",
                    Type = SensorTypeEnum.Input
                },
                new SensorKind()
                {
                    Name = "BMP280",
                    ShortDescription = "Czujnik temp.",
                    Description =
                        "Czujnik do pomiaru temperatury. Zakres pomiarowy: temperatura -40 do 85°C",
                    Type = SensorTypeEnum.Input
                },
                new SensorKind()
                {
                    Name = "BMP280",
                    ShortDescription = "Czujnik ciśnienia.",
                    Description =
                        "Czujnik do pomiaru ciśnienia. Zakres pomiarowy: ciśnienia: 300 do 1100hPa",
                    Type = SensorTypeEnum.Input
                },
                new SensorKind()
                {
                    Name = "LM35",
                    ShortDescription = "Czujnik temperatury.",
                    Description = "Czujnik temperatury działający w zakresie od -40°C do 150°C",
                    Type = SensorTypeEnum.Input
                },
                new SensorKind()
                {
                    Name = "Oświetlenie cyfrowe",
                    ShortDescription = "Oświetlenie terrarium. Włącz/wyłącz.",
                    Description = "Oświetlenie terrarium. Włącz/wyłącz",
                    Type = SensorTypeEnum.Output,
                    OutputType = OutputTypeEnum.Digital
                },
                new SensorKind()
                {
                    Name = "Oświetlenie analogowe",
                    ShortDescription = "Oświetlenie terrarium RGB.",
                    Description = "Oświetlenie terrarium RGB.",
                    Type = SensorTypeEnum.Output,
                    OutputType = OutputTypeEnum.Analog
                },
                new SensorKind()
                {
                    Name = "Grzałka",
                    ShortDescription = "Ogrzewanie terrarium. Włącz/Wyłącz.",
                    Description = "Ogrzewanie terrarium, lampy/maty/przewody. Włącz/Wyłącz",
                    Type = SensorTypeEnum.Output,
                    OutputType = OutputTypeEnum.Analog
                },
            };
        }
    }
}