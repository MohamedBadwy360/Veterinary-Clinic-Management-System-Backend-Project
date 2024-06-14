namespace VCMS.EF.Data.Seed
{
    public static class SeedData
    {
        /// <summary>
        /// A Method to load some medications to seed database.
        /// </summary>
        /// <returns>List of Medications</returns>
        public static List<Medication> LoadMedications()
        {
            return new List<Medication>
            {
                new Medication { Id = 1, TradeName = "Ivomaac Super", GenericName = "Ivomec",
                    Category = "Semi-Synthetic Antiparasitic", Unit = "50 ml", UnitInStock = 20, 
                    CostPricePerItem = 500m, SalePricePerItem = 550m, ExpirationDate = new DateOnly(2027, 1, 1)},

                new Medication { Id = 2, TradeName = "Ivomaac Normal", GenericName = "Ivermectin",
                    Category = "Semi-Synthetic Antiparasitic", Unit = "50 ml", UnitInStock = 30,
                    CostPricePerItem = 45m, SalePricePerItem = 70m, ExpirationDate = new DateOnly(2026, 1, 1)},

                new Medication { Id = 3, TradeName = "Ivomaac Super", GenericName = "Dictomec",
                    Category = "Semi-Synthetic Antiparasitic, Liver Fluke", Unit = "50 ml", UnitInStock = 30,
                    CostPricePerItem = 80m, SalePricePerItem = 120m, ExpirationDate = new DateOnly(2027, 6, 1)},

                new Medication { Id = 4, TradeName = "Ivomaac Super", GenericName = "Venomectin S",
                    Category = "Semi-Synthetic Antiparasitic, Liver Fluke", Unit = "50 ml", UnitInStock = 15,
                    CostPricePerItem = 45m, SalePricePerItem = 100m, ExpirationDate = new DateOnly(2025, 6, 1)},

                new Medication { Id = 5, TradeName = "Stimulating", GenericName = "Vetazal",
                    Category = "Stimulation of the Metabolism", Unit = "100 ml", UnitInStock = 10,
                    CostPricePerItem = 45m, SalePricePerItem = 80m, ExpirationDate = new DateOnly(2026, 2, 26)},

                new Medication { Id = 6, TradeName = "Antibiotic", GenericName = "Oxytetracycline 20%",
                    Category = "Antibiotic", Unit = "30 ml", UnitInStock = 10,
                    CostPricePerItem = 40m, SalePricePerItem = 60m, ExpirationDate = new DateOnly(2025, 12, 30)},

                new Medication { Id = 7, TradeName = "Penicillin", GenericName = "Vetrocin",
                    Category = "Penicillin", Unit = "8 gm", UnitInStock = 25,
                    CostPricePerItem = 25m, SalePricePerItem = 35m, ExpirationDate = new DateOnly(2026, 5, 1)},

                new Medication { Id = 8, TradeName = "Anticoccidial", GenericName = "Clazox",
                    Category = "Anticoccidial", Unit = "100 ml", UnitInStock = 30,
                    CostPricePerItem = 25m, SalePricePerItem = 50m, ExpirationDate = new DateOnly(2026, 1, 1)},

                new Medication { Id = 9, TradeName = "Antitoxin - Antifungal", GenericName = "Sendex",
                    Category = "Antitoxin - Antifungal", Unit = "100 ml", UnitInStock = 100,
                    CostPricePerItem = 10m, SalePricePerItem = 15m, ExpirationDate = new DateOnly(2028, 1, 1)},

                //new Medication { Id = 10, TradeName = "Antibiotic", GenericName = "Oxytetracycline 20%",
                //    Category = "Antibiotic", Unit = "20 gm", UnitInStock = 30,
                //    CostPricePerItem = 10m, SalePricePerItem = 15m, ExpirationDate = new DateOnly(2028, 3, 1)},

                new Medication { Id = 11, TradeName = "Antibiotic", GenericName = "New Oxy",
                    Category = "Antibiotic", Unit = "8 Tablets in Two Strips", UnitInStock = 100,
                    CostPricePerItem = 20m, SalePricePerItem = 24m, ExpirationDate = new DateOnly(2028, 3, 1)},

                new Medication { Id = 12, TradeName = "Vitamins", GenericName = "Vitamid",
                    Category = "Vitamins", Unit = "20 gm", UnitInStock = 100,
                    CostPricePerItem = 7m, SalePricePerItem = 10m, ExpirationDate = new DateOnly(2028, 3, 1)},

                new Medication { Id = 13, TradeName = "Vitamins", GenericName = "AD3H",
                    Category = "Vitamins", Unit = "100 ml", UnitInStock = 200,
                    CostPricePerItem = 5m, SalePricePerItem = 7.5m, ExpirationDate = new DateOnly(2028, 3, 1)},

                new Medication { Id = 14, TradeName = "Calcium", GenericName = "Pure Phose",
                    Category = "Calcium", Unit = "100 ml", UnitInStock = 300,
                    CostPricePerItem = 5m, SalePricePerItem = 7.5m, ExpirationDate = new DateOnly(2028, 3, 1)},

                new Medication { Id = 15, TradeName = "Antibiotic", GenericName = "Cloromophincol",
                    Category = "Intestinal Diarrhea - Protection", Unit = "100 ml", UnitInStock = 120,
                    CostPricePerItem = 2.1m, SalePricePerItem = 5m, ExpirationDate = new DateOnly(2027, 3, 1)},

                new Medication { Id = 16, TradeName = "Antibiotic", GenericName = "Newvit",
                    Category = "Intestinal Diarrhea - Protection", Unit = "100 ml", UnitInStock = 120,
                    CostPricePerItem = 2.1m, SalePricePerItem = 5m, ExpirationDate = new DateOnly(2027, 3, 1)},

                new Medication { Id = 17, TradeName = "Antibiotic", GenericName = "Oxy 1 2 3",
                    Category = "Protection", Unit = "100 ml", UnitInStock = 120,
                    CostPricePerItem = 2.1m, SalePricePerItem = 5m, ExpirationDate = new DateOnly(2027, 3, 1)},
            };
        }

        /// <summary>
        /// A Method to load some diagnostics to seed database.
        /// </summary>
        /// <returns>List of diagnostics</returns>
        public static List<Diagnosis> LoadDiagnostics()
        {
            return new List<Diagnosis>
            {
                new Diagnosis { Id = 1, Name = "Head Lice" },
                new Diagnosis { Id = 2, Name = "Onchocerciasis" },
                new Diagnosis { Id = 3, Name = "Strongyloidiasis" },
                new Diagnosis { Id = 4, Name = "Ascariasis" },
                new Diagnosis { Id = 5, Name = "Trichuriasis" },
                new Diagnosis { Id = 6, Name = "Enterobiasis" },
                new Diagnosis { Id = 7, Name = "Antiparasitic" },
                new Diagnosis { Id = 8, Name = "Liver Fluke" },
                new Diagnosis { Id = 9, Name = "External Parasites" },
                new Diagnosis { Id = 10, Name = "Lung Worms" },
                new Diagnosis { Id = 11, Name = "Gastrointestinal Roundworms" },
                new Diagnosis { Id = 12, Name = "Coccidiosis" },
                new Diagnosis { Id = 13, Name = "Avian Influenza" },
                new Diagnosis { Id = 14, Name = "Intestinal Diarrhea" },
                new Diagnosis { Id = 15, Name = "Protection" },
                new Diagnosis { Id = 16, Name = "Wounds" }
            };
        }

        /// <summary>
        /// A Method to load some species to seed database.
        /// </summary>
        /// <returns>List of species</returns>
        public static List<Species> LoadSpecies()
        {
            return new List<Species>
            {
                new Species { Id = 1, Name = "Cattle" },
                new Species { Id = 2, Name = "Horse" },
                new Species { Id = 3, Name = "Sheep" },
                new Species { Id = 4, Name = "Goat" },
                new Species { Id = 5, Name = "Pig" },
                new Species { Id = 6, Name = "Geese" },
                new Species { Id = 7, Name = "Chicken" },
                new Species { Id = 8, Name = "Duck" },
                new Species { Id = 9, Name = "Pigeon" },
                new Species { Id = 10, Name = "Dog" },
                new Species { Id = 11, Name = "Cat" }
            };
        }

        /// <summary>
        /// A Method to load some clients to seed database.
        /// </summary>
        /// <returns>List of clients</returns>
        public static List<Client> LoadClients()
        {
            return new List<Client>
            {
                new Client { Id = 1, FirstName = "Mohamed", LastName = "Badwy", 
                    Address = "Tahway - Uomo Street", PhoneNumber = "01553414588" },

                new Client { Id = 2, FirstName = "Elsaid", LastName = "Badwy", 
                    Address = "Tahway - Uomo Street", PhoneNumber = "01063090820" },

                new Client { Id = 3, FirstName = "Mazen", LastName = "Fatouha",
                    Address = "Tahway - Saafna Street", PhoneNumber = "01036547892" },

                new Client { Id = 4, FirstName = "Hazem", LastName = "Fatouha",
                    Address = "Tahway - Saafna Street", PhoneNumber = "01036564892" },

                new Client { Id = 5, FirstName = "Fatouha", LastName = "Ekaref",
                    Address = "Tahway - Saafna Street", PhoneNumber = "01366564892" },
            };
        }

        /// <summary>
        /// A Method to load some patients to seed database.
        /// </summary>
        /// <returns>List of patients</returns>
        public static List<Patient> LoadPatients()
        {
            return new List<Patient>
            {
                new Patient { Id = 1, ClientId = 1, SpeciesId = 6, Count = 10, Sex = ESex.Female, Age = "15 Days" },
                new Patient { Id = 2, ClientId = 2, SpeciesId = 8, Count = 15, Sex = ESex.Female, Age = "20 Days" },
                new Patient { Id = 3, ClientId = 3, SpeciesId = 11, Count = 1, Sex = ESex.Female, Age = "6 Months" },
                new Patient { Id = 4, ClientId = 4, SpeciesId = 2, Count = 1, Sex = ESex.Female, Age = "2 Years and One Month" },
                new Patient { Id = 5, ClientId = 5, SpeciesId = 1, Count = 2, Sex = ESex.Female, Age = "1 Year and Two Months" },
            };
        }

        /// <summary>
        /// A Method to load some doctors to seed database.
        /// </summary>
        /// <returns>List of doctors</returns>
        public static List<Doctor> LoadDoctors()
        {
            return new List<Doctor>
            {
                new Doctor { Id = 1, FirstName = "Badwy", LastName = "Elsaid", Email = "badwyelsaid@gmail.com",
                    PhoneNumber = "01112516588", YearGraduated = 1990 }
            };
        }

        /// <summary>
        /// A Method to load some cases to seed database.
        /// </summary>
        /// <returns>List of cases</returns>
        public static List<Case> LoadCases()
        {
            return new List<Case>
            {
                new Case { Id = 1, PatientId = 1, DoctorId = 1, DiagnosisId = 12, Status = EStatus.NewCase,
                    CaseType = ECaseType.Medical, Date = new DateOnly(2023, 1, 1),
                    Notes = "Take them away from ducks." },

                new Case { Id = 2, PatientId = 2, DoctorId = 1, DiagnosisId = 14, Status = EStatus.NewCase,
                    CaseType = ECaseType.Medical, Date = new DateOnly(2023, 1, 2),
                    Notes = "Take them away from chicken." },
                
                new Case { Id = 3, PatientId = 3, DoctorId = 1, DiagnosisId = 7, Status = EStatus.NewCase,
                    CaseType = ECaseType.Medical, Date = new DateOnly(2023, 1, 3),
                    Notes = "Take them the water with medication before eating." },
                
                new Case { Id = 4, PatientId = 4, DoctorId = 1, DiagnosisId = 16, Status = EStatus.NewCase,
                    CaseType = ECaseType.Surgical, Date = new DateOnly(2023, 1, 4),
                    Notes = "Dont't begin work after one month"},
                
                new Case { Id = 5, PatientId = 5, DoctorId = 1, DiagnosisId = 2, Status = EStatus.NewCase,
                    CaseType = ECaseType.Medical, Date = new DateOnly(2023, 1, 5)},

                new Case { Id = 6, PatientId = 2, DoctorId = 1, DiagnosisId = 15, Status = EStatus.UpdatedCase,
                    CaseType = ECaseType.Medical, Date = new DateOnly(2023, 2, 15)},
            };
        }

        /// <summary>
        /// A Method to load some prescriptions to seed database.
        /// </summary>
        /// <returns>List of prescriptions</returns>
        public static List<Prescription> LoadPrescriptions()
        {
            return new List<Prescription>
            {
                new Prescription { Id = 1, CaseId = 1, Date = new DateOnly(2023, 1, 1) }, 
                new Prescription { Id = 2, CaseId = 2, Date = new DateOnly(2023, 1, 2) }, 
                new Prescription { Id = 3, CaseId = 3, Date = new DateOnly(2023, 1, 3) }, 
                new Prescription { Id = 4, CaseId = 4, Date = new DateOnly(2023, 1, 4) }, 
                new Prescription { Id = 5, CaseId = 5, Date = new DateOnly(2023, 1, 5) }, 
                new Prescription { Id = 6, CaseId = 6, Date = new DateOnly(2023, 1, 15) }
            };
        }

        /// <summary>
        /// A Method to load some prescribed medicines to seed database.
        /// </summary>
        /// <returns>List of prescribed medications</returns>
        public static List<PrescribedMeds> LoadPrescribedMeds()
        {
            return new List<PrescribedMeds>
            {
                new PrescribedMeds { PrescriptionId = 1, MedicationId = 8, Quantity = 2, Price = 50m,
                    Frequency = "1 ml for 1 litre."},

                new PrescribedMeds { PrescriptionId = 1, MedicationId = 11, Quantity = 2, Price = 24m,
                    Frequency = "1 tablet for 4 litre."},

                new PrescribedMeds { PrescriptionId = 2, MedicationId = 15, Quantity = 2, Price = 5m,
                    Frequency = "1 gm for 1 litre."},

                new PrescribedMeds { PrescriptionId = 2, MedicationId = 16, Quantity = 2, Price = 5m,
                    Frequency = "1 gm for 1 litre."},

                new PrescribedMeds { PrescriptionId = 3, MedicationId = 4, Quantity = 1, Price = 100m,
                    Frequency = "1 ml for 50 kg."},

                new PrescribedMeds { PrescriptionId = 4, MedicationId = 7, Quantity = 3, Price = 35m,
                    Frequency = "1 ml for 50 kg."},

                new PrescribedMeds { PrescriptionId = 4, MedicationId = 6, Quantity = 2, Price = 60m,
                    Frequency = "1 ml for 50 kg."},

                new PrescribedMeds { PrescriptionId = 5, MedicationId = 4, Quantity = 1, Price = 100m,
                    Frequency = "1 ml for 50 kg."},

                new PrescribedMeds { PrescriptionId = 6, MedicationId = 17, Quantity = 3, Price = 5m,
                    Frequency = "1 gm for 1 litre."},

                new PrescribedMeds { PrescriptionId = 6, MedicationId = 16, Quantity = 3, Price = 5m,
                    Frequency = "1 gm for 1 litre."},

                new PrescribedMeds { PrescriptionId = 6, MedicationId = 14, Quantity = 3, Price = 7.5m,
                    Frequency = "2 ml for 1 litre."},

                new PrescribedMeds { PrescriptionId = 6, MedicationId = 13, Quantity = 3, Price = 7.5m,
                    Frequency = "2 ml for 1 litre."},

                new PrescribedMeds { PrescriptionId = 6, MedicationId = 12, Quantity = 3, Price = 10m,
                    Frequency = "1 gm for 1 litre."},
            };
        }

        /// <summary>
        /// A Method to load some receipts to seed database.
        /// </summary>
        /// <returns>List of receipts</returns>
        public static List<Receipt> LoadReceipts()
        {
            return new List<Receipt>
            {
                new Receipt { Id = 1, PrescriptionId = 1, TotalPrice = 148m, Date = new DateOnly(2023, 1, 1) }, 
                new Receipt { Id = 2, PrescriptionId = 2, TotalPrice = 20m, Date = new DateOnly(2023, 1, 2) }, 
                new Receipt { Id = 3, PrescriptionId = 3, TotalPrice = 100m, Date = new DateOnly(2023, 1, 3) }, 
                new Receipt { Id = 4, PrescriptionId = 4, TotalPrice = 225m, Date = new DateOnly(2023, 1, 4) }, 
                new Receipt { Id = 5, PrescriptionId = 5, TotalPrice = 100m, Date = new DateOnly(2023, 1, 5) }, 
                new Receipt { Id = 6, PrescriptionId = 6, TotalPrice = 105m, Date = new DateOnly(2023, 1, 15) },
            };
        }
    }
}
