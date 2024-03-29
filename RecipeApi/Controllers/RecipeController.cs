﻿using Microsoft.AspNetCore.Mvc;
using RecipeApi.Models;
using RecipeApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecipeController : ControllerBase
	{
		private readonly IRecipeService _recipeService;
		public RecipeController(IRecipeService recipeService)
		{
			_recipeService = recipeService;
		}
		// GET: api/<RecipeController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		//TODO update to be get by id?
		// GET api/<RecipeController>/5
		[HttpGet("{name}")]
		public Recipe Get(string name)
		{
			return _recipeService.GetRecipe(name);
		}

		// GET api/<RecipeController>/Search/name
		[HttpGet("Search/{name}")]
		public List<Recipe> SearchRecipeByName(string name)
		{
			return _recipeService.SearchByName(name);
		}

		// GET api/<RecipeController>/random
		[HttpGet("random")]
		public Recipe GetRandomRecipe()
		{
			return _recipeService.GetRandomRecipe();
		}

		// POST api/<RecipeController>
		[HttpPost]
		public void Post([FromBody] CreateRecipe recipe)
		{
			_recipeService.CreateRecipe(recipe);
		}

		// PUT api/<RecipeController>/5
		[HttpPut("{id}")]
		public void Put(string name, [FromBody] CreateRecipe recipe)
		{
			_recipeService.UpdateRecipe(name, recipe);
		}

		// DELETE api/<RecipeController>/5
		[HttpDelete("{name}")]
		public void Delete(string name)
		{
			_recipeService.DeleteRecipe(name);
		}
	}
}
