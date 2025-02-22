using Wpm.Management.Api;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;
using Wpm.Shared.Kernel;

namespace Wpm.Management.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Pet_should_be_equal()
    {
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet1 = new Pet(id, "Karabaş", 2, "Beyaz", SexOfPet.Male, breedId);
        var pet2 = new Pet(id, "Beyazkaş", 3, "Sarı", SexOfPet.Female, breedId);
        Assert.Equal(pet1, pet2);
    }

    [Fact]
    public void Pet_should_be_equal_using_operators()
    {
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet1 = new Pet(id, "Karabaş", 2, "Beyaz", SexOfPet.Male, breedId);
        var pet2 = new Pet(id, "Beyazkaş", 3, "Sarı", SexOfPet.Female, breedId);
        Assert.True(pet1 == pet2);
    }

    [Fact]
    public void Pet_should_be_not_equal_using_operators()
    {
        var id = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet1 = new Pet(id, "Karabaş", 2, "Beyaz", SexOfPet.Male, breedId);
        var pet2 = new Pet(id2, "Beyazkaş", 3, "Sarı", SexOfPet.Female, breedId);
        Assert.True(pet1 != pet2);
    }

    [Fact]
    public void Weight_should_be_equal()
    {
        var w1 = new Weight(20.5m);
        var w2 = new Weight(20.5m);
        Assert.True(w1 == w2);
    }

    [Fact]
    public void WeightRange_should_be_equal()
    {
        var w1 = new WeightRange(10, 20.5m);
        var w2 = new WeightRange(10, 20.5m);
        Assert.True(w1 == w2);
    }

    [Fact]
    public void BreedId_should_be_valid()
    {
        var breedService = new FakeBreedService();
        var id = breedService.breeds[0].Id;
        var breedId = new BreedId(id, breedService);
        Assert.NotNull(breedId);
    }

    [Fact]
    public void BreedId_should_not_be_valid()
    {
        var breedService = new FakeBreedService();
        var id = Guid.NewGuid();
        Assert.Throws<ArgumentException>(() =>
        {
            var breedId = new BreedId(id, breedService);
        });
    }

    [Fact]
    public void WeightClass_should_be_ideal()
    {
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet1 = new Pet(Guid.NewGuid(), "Karabaş", 2, "Beyaz", SexOfPet.Male, breedId);
        //pet1.SetWeight(new Weight(11), breedService);
        pet1.SetWeight(11, breedService);//implicit operator
        Assert.True(pet1.WeightClass == WeightClass.Ideal);
    }

    [Fact]
    public void WeightClass_should_be_overweight()
    {
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet1 = new Pet(Guid.NewGuid(), "Karabaş", 2, "Beyaz", SexOfPet.Male, breedId);
        pet1.SetWeight(110, breedService);
        Assert.True(pet1.WeightClass == WeightClass.Overweight);
    }

    [Fact]
    public void WeightClass_should_be_underweight()
    {
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet1 = new Pet(Guid.NewGuid(), "Karabaş", 2, "Beyaz", SexOfPet.Male, breedId);
        pet1.SetWeight(5, breedService);
        Assert.True(pet1.WeightClass == WeightClass.UnderWeight);
    }
}
