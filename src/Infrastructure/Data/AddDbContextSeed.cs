using AppCore.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Enums;

namespace Infrastructure.Data
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
            if (!_ctx.SensorKinds.Any())
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
                new SensorKind() {Name ="DHT22", Description = "Czujnik do pomiaru temperatury i wilgotności powietrza z interfejsem cyfrowym, jednoprzewodowym. Zakres pomiarowy: temperatura -40 do 80°C, wilgotność 0-100 %RH.", Type = SensorTypeEnum.Input},
                new SensorKind() {Name ="DHT11", Description = "Czujnik do pomiaru temperatury i wilgotności powietrza z interfejsem cyfrowym, jednoprzewodowym. Zakres pomiarowy: temperatura od -20 °C do +60 °C, wilgotność od 5 % do 95 % RH. ", Type = SensorTypeEnum.Input},
                new SensorKind() {Name ="BMP280", Description = "Czujnik do pomiaru temperatury i ciśnienia. Zakres pomiarowy: temperatura -40 do 85°C, ciśnienia: 300 do 1100hPa", Type = SensorTypeEnum.Input},
                new SensorKind() {Name ="LM35", Description = "Czujnik temperatury działający w zakresie od -40°C do 150°C", Type = SensorTypeEnum.Input},
                new SensorKind() {Name ="Oświetlenie cyfrowe", Description = "Oświetlenie terrarium. Włącz/wyłącz", Type = SensorTypeEnum.Output},
                new SensorKind() {Name ="Oświetlenie analogowe", Description = "Oświetlenie terrarium RGB.", Type = SensorTypeEnum.Output},
                new SensorKind() {Name ="Grzałka", Description = "Ogrzewanie terrarium, lampy/maty/przewody. Włącz/Wyłącz", Type = SensorTypeEnum.Output},
            };
        }
    }
}
