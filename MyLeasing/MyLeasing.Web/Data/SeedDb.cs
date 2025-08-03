using MyLeasing.Common.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{

    public class SeedDb
    {

        private readonly DataContext _context;
        private readonly Random _random;

        // Sample data for seeding
        private readonly string[] _firstNames = { "João", "Maria", "Carlos", "Ana", "Pedro", "Sofia", "Bruno", "Paula", "Tiago", "Luísa" };
        private readonly string[] _lastNames = { "Silva", "Santos", "Ferreira", "Costa", "Oliveira", "Martins", "Rocha", "Ribeiro", "Almeida", "Sousa" };
        private readonly string[] _streets = { "Rua das Flores", "Avenida Brasil", "Rua do Comércio", "Travessa Central", "Rua Nova", "Alameda dos Anjos", "Rua das Palmeiras", "Rua do Sol", "Avenida Atlântica", "Travessa da Esperança" };

        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        // <summary>
        public async Task SeedAsync()
        {
            // Ensures that the database is created and seeded with initial data
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Owners.Any())
            {
                // If there are no owners, seed the database with sample data
                for (int i = 1; i <= 10; i++)
                {
                    // Generate random data for each owner
                    string firstName = _firstNames[_random.Next(_firstNames.Length)];
                    string lastName = _lastNames[_random.Next(_lastNames.Length)];
                    string street = _streets[_random.Next(_streets.Length)];
                    int houseNumber = _random.Next(1, 200);

                    // Create a new owner with random data
                    _context.Owners.Add(new Owner
                    {
                        
                        Document = $"DOC-{_random.Next(10000, 99999)}",
                        FirstName = firstName,
                        LastName = lastName,
                        FixedPhone = $"555-01{i}0-{_random.Next(1000, 9999)}",
                        CellPhone = $"555-02{i}0-{_random.Next(1000, 9999)}",
                        Address = $"{street}, Nº {houseNumber}"
                    });
                }

                await _context.SaveChangesAsync();
            }
        }



    }
}
