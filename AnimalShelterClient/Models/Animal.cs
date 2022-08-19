using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AnimalShelterClient.Models
{
   public class Animal
  {
    public int AnimalId { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Breed { get; set; }

    public static List<Animal> GetAnimals()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Animal> animalList = JsonConvert.DeserializeObject<List<Animal>>(jsonResponse.ToString());

      return animalList;
    }

    public static List<Animal> GetSpecies(string species)
    {
      var apiCallTask = ApiHelper.GetSpecies(species);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Animal> animalList = JsonConvert.DeserializeObject<List<Animal>>(jsonResponse.ToString());

      return animalList;
    }

    public static List<Animal> GetGender(string gender)
    {
      var apiCallTask = ApiHelper.GetGender(gender);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Animal> animalList = JsonConvert.DeserializeObject<List<Animal>>(jsonResponse.ToString());

      return animalList;
    }


    public static Animal GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Animal animal = JsonConvert.DeserializeObject<Animal>(jsonResponse.ToString());

      return animal;
    }

    public static void Post(Animal animal)
    {
      string jsonAnimal = JsonConvert.SerializeObject(animal);
      var apiCallTask = ApiHelper.Post(jsonAnimal);
    }

    public static void Put(Animal animal)
    {
      string jsonAnimal = JsonConvert.SerializeObject(animal);
      var apiCallTask = ApiHelper.Put(animal.AnimalId, jsonAnimal);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}