namespace VCMS.Tests.VCMS.EF.Tests.Repositories
{
    public class BaseRepositoryTests
    {
        public static IEnumerable<object[]> AddAsyncData
        {
            get
            {
                yield return new object[]
                {
                    (Expression<Func<Species, bool>>)(s => s.Name == "Dog"), true
                };
                yield return new object[]
                {
                    (Expression<Func<Species, bool>>)(s => s.Name == "Cat"), false
                };
                yield return new object[]
                {
                    (Expression<Func<Species, bool>>)(s => s.Id == 1), true,
                };
                yield return new object[]
                {
                    (Expression<Func<Species, bool>>)(s => s.Id == 2), false
                };
            }
        }

        [Fact]
        public async Task GetByIdAsync_WhenIdIsGreaterThanZeroAndExist_ReturnsEntity()
        {
            // Arrange
            var sut = new Species { Id = 1, Name = "Dog" };

            using (var context = new InMemoryVCMSDbContext())
            {
                await context.Species.AddAsync(sut);
                await context.SaveChangesAsync();

                var repository = new BaseRepository<Species>(context);

                // Act
                var actualResult = await repository.GetByIdAsync(1);

                // Assert
                Assert.NotNull(actualResult);
                Assert.Equal(sut.Id, actualResult.Id);
                Assert.Equal(sut.Name, actualResult.Name);
                Assert.IsType<Species>(actualResult);
            }
        }

        [Fact]
        public async Task GetByIdAsync_WhenIdEqualZero_ReturnsEntity()
        {
            using (var context = new InMemoryVCMSDbContext())
            {
                // Arrange
                var sut = new Species { Id = 1, Name = "Dog" };
                await context.Species.AddAsync(sut);
                await context.SaveChangesAsync();

                var repository = new BaseRepository<Species>(context);

                // Act
                var actualResult = await repository.GetByIdAsync(0);

                // Assert
                Assert.Null(actualResult);
            }
        }

        [Fact]
        public async Task GetByIdAsync_WhenIdIsNotExist_ReturnsEntity()
        {
            using (var context = new InMemoryVCMSDbContext())
            {
                var sut = new Species { Id = 1, Name = "Dog" };
                await context.Species.AddAsync(sut);
                await context.SaveChangesAsync();

                var repository = new BaseRepository<Species>(context);

                // Act
                var actual = await repository.GetByIdAsync(2);

                // Assert
                Assert.Null(actual);
            }
        }

        [Fact]
        public async Task GetAllAsync_NoParameters_ReturnListOfEntities()
        {
            using (var context = new InMemoryVCMSDbContext())
            {
                // Arrange
                var sut = new List<Species>
                {
                    new Species { Id = 1, Name = "Dog" },
                    new Species { Id = 2, Name = "Cat" }
                };

                await context.AddRangeAsync(sut);
                await context.SaveChangesAsync();

                var repository = new BaseRepository<Species>(context);
                var actual = await repository.GetAllAsync();

                Assert.NotNull(actual);
                Assert.True(sut.Count == actual.Count());
                Assert.IsType<List<Species>>(actual);
                Assert.Equal(sut[0].Id, actual.ToList()[0].Id);
                Assert.Equal(sut[1].Name, actual.ToList()[1].Name);
            }
        }

        [Fact]
        public async Task GetAllAsync_WhenIncludesIsNotNull_ReturnListOfEntities()
        {
            using (var context = new InMemoryVCMSDbContext())
            {
                // Arrange
                var sut = new List<Species>
                {
                    new Species { Id = 1, Name = "Dog", Patients = new List<Patient>
                    {
                        new Patient { Id = 1, ClientId = 1, SpeciesId = 1, Age = "month", Count = 20 , Sex = ESex.Female }
                    }},
                    new Species { Id = 2, Name = "Cat" , Patients = new List<Patient> 
                    {
                        new Patient { Id = 2, ClientId = 2, SpeciesId = 2, Age = "week", Count = 10 , Sex = ESex.Male }
                    }}
                };

                await context.AddRangeAsync(sut);
                await context.SaveChangesAsync();

                var repository = new BaseRepository<Species>(context);
                string[] includes = [ "Patients" ];

                // Act
                var actual = await repository.GetAllAsync(includes);

                // Assert
                Assert.NotNull(actual);
                Assert.True(sut.Count == actual.Count());
                Assert.IsType<List<Species>>(actual);
                Assert.Equal(sut[0].Id, actual.ToList()[0].Id);
                Assert.Equal(sut[1].Name, actual.ToList()[1].Name);
                Assert.True(actual.ToList()[0].Patients[0].Count > 0);
                Assert.True(actual.ToList()[1].Patients[0].Count > 0);
            }
        }

        [Fact]
        public async Task GetAllAsync_WhenIncludesExpressionIsNotNull_ReturnListOfEntities()
        {
            using (var context = new InMemoryVCMSDbContext())
            {
                // Arrange
                var sut = new List<Species>
                {
                    new Species { Id = 1, Name = "Dog", Patients = new List<Patient>
                    {
                        new Patient { Id = 1, ClientId = 1, SpeciesId = 1, Age = "month", Count = 20 , Sex = ESex.Female }
                    }},
                    new Species { Id = 2, Name = "Cat" , Patients = new List<Patient>
                    {
                        new Patient { Id = 2, ClientId = 2, SpeciesId = 2, Age = "week", Count = 10 , Sex = ESex.Male }
                    }}
                };

                await context.AddRangeAsync(sut);
                await context.SaveChangesAsync();

                var repository = new BaseRepository<Species>(context);                

                // Act
                var actual = await repository.GetAllAsync(s => s.Patients);

                // Assert
                Assert.NotNull(actual);
                Assert.True(sut.Count == actual.Count());
                Assert.IsType<List<Species>>(actual);
                Assert.Equal(sut[0].Id, actual.ToList()[0].Id);
                Assert.Equal(sut[1].Name, actual.ToList()[1].Name);
                Assert.True(actual.ToList()[0].Patients[0].Count > 0);
                Assert.True(actual.ToList()[1].Patients[0].Count > 0);
            }
        }

        [Fact]
        public async Task AddAsync_WhenEntityIsNotNull_TracksEntityAsAddedEntityAndReturnsEntity()
        {
            using (var context = new InMemoryVCMSDbContext())
            {
                // Arrange
                var sut = new Species { Id = 1, Name = "Cat" };
                var repository = new BaseRepository<Species>(context);

                // Act
                var actual = await repository.AddAsync(sut);
                
                // Assert
                Assert.NotNull(actual);
                Assert.Equal(sut.Id, actual.Id);
                Assert.Equal(sut.Name, actual.Name);
                Assert.Equal(EntityState.Added, context.Entry(actual).State);
                Assert.IsType<Species>(actual);
            }
        }

        [Fact]
        public async Task AddAsync_WhenEntityIsNull_ThrowsArgumentNullException()
        {
            using (var context = new InMemoryVCMSDbContext())
            {
                // Arrange
                var repository = new BaseRepository<Species>(context);

                // Act
                Func<Task<Species>> func = async () => await repository.AddAsync(null);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(func);
            }
        }

        [Fact] 
        public async Task Update_WhenEntityIsNotNull_TracksEntityAsModifiedAndReturnsEntity()
        {
            using (var context = new InMemoryVCMSDbContext())
            {
                // Arrange
                var species = new Species { Id = 1, Name = "Dog" };
                await context.Species.AddAsync(species);
                await context.SaveChangesAsync();

                var respository = new BaseRepository<Species>(context);

                // Act 
                species.Name = "Cat";
                var actual = respository.Update(species);

                // Assert
                Assert.NotNull(actual);
                Assert.True(species.Id == actual.Id);
                Assert.True(species.Name == actual.Name);
                Assert.IsType<Species>(actual);
                Assert.True(EntityState.Modified == context.Entry(actual).State);
            }
        }

        [Fact]
        public async Task Update_WhenEntityIsNull_ThrowsArgumentNullException()
        {
            using (var context = new InMemoryVCMSDbContext())
            {
                // Arrange
                var species = new Species { Id = 1, Name = "Cat" };
                await context.AddAsync(species);
                await context.SaveChangesAsync();

                var respository = new BaseRepository<Species>(context);

                // Act 
                Func<Species> func = () => respository.Update(null);

                // Assert
                Assert.Throws<ArgumentNullException>(func);
            }
        }    

        [Theory]
        [MemberData(nameof(AddAsyncData))]
        public async Task AnyAsync_WhenPredicateIsNotNull_ReturnsTrueOrFalse(Expression<Func<Species, bool>> predicate, bool expected)
        {
            using (var context = new InMemoryVCMSDbContext())
            {
                // Arrange
                var species = new Species { Id = 1, Name = "Dog" };
                await context.AddAsync(species);
                await context.SaveChangesAsync();

                var repository = new BaseRepository<Species>(context);

                // Act
                bool actual = await repository.AnyAsync(predicate);

                // Assert
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public async Task AnyAsync_WhenPredicateIsNull_ThrowsArgumentNullException()
        {
            using (var context = new InMemoryVCMSDbContext())
            {
                // Arrange
                var repository = new BaseRepository<Species>(context);

                // Act
                Func<Task<bool>> func = async () => await repository.AnyAsync(null);

                // Assert
                await Assert.ThrowsAsync<ArgumentNullException>(func);
            }
        }

        [Fact]
        public async Task Delete_WhenEntityIsNotNull_TracksEntityAsDeleted()
        {
            using (var context = new InMemoryVCMSDbContext())
            {
                // Arrange
                var sut = new Species { Id = 1, Name = "Cat" };
                await context.Species.AddAsync(sut);
                await context.SaveChangesAsync();

                var repository = new BaseRepository<Species>(context);

                // Act
                repository.Delete(sut);

                // Assert 
                Assert.Equal(EntityState.Deleted, context.Entry(sut).State);
            }
        }

        [Fact]
        public void Delete_WhenEntityIsNull_ThrowsArgumentNullException()
        {
            using (var context = new InMemoryVCMSDbContext())
            {
                // Arrange
                var repository = new BaseRepository<Species>(context);

                // Act
                Action action = () => repository.Delete(null);

                // Assert 
                Assert.Throws<ArgumentNullException>(action);
            }
        }

        [Fact]
        public async Task DeleteRange_WhenEntitiesIsNotNull_TracksEntitiesAsDeleted()
        {
            using (var context = new InMemoryVCMSDbContext())
            {
                // Arrange
                var species = new List<Species>
                {   
                    new Species { Id = 1, Name = "Cat" },
                    new Species { Id = 2, Name = "Dog" }
                };

                await context.AddRangeAsync(species);
                await context.SaveChangesAsync();

                var repository = new BaseRepository<Species>(context);

                // Act
                repository.DeleteRange(species);

                // Assert
                Assert.Equal(EntityState.Deleted, context.Entry(species[0]).State);
                Assert.Equal(EntityState.Deleted, context.Entry(species[1]).State);
            }
        }

        [Fact]
        public void DeleteRange_WhenEntitiesIsNull_ThrowsNullArgumentException()
        {
            using (var context = new InMemoryVCMSDbContext())
            {
                // Arrange
                var repository = new BaseRepository<Species>(context);

                // Act
                Action action = () => repository.DeleteRange(null);

                // Assert
                Assert.Throws<ArgumentNullException>(action);   
            }
        }
    }
}
