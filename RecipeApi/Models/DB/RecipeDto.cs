﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RecipeApi.Models
{
	public class RecipeDto
	{
		[BsonId]
		[BsonElement(elementName: "_id")]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		[BsonGuidRepresentation(GuidRepresentation.Standard)]
		public Guid OwnerUserId { get; set; }
		public bool IsPoolRecipe { get; set; }
		public bool CreatedFromPool { get; set; }
		public string RecipeName { get; set; }
		public string RecipeNationality { get; set; }
		public List<Ingredient> Ingredients { get; set; }
		public List<Step> Steps { get; set; }
		public int PrepTimeMinutes { get; set; }
		public int CookTimeMinutes { get; set; }
		public int ReadyInMinutes { get; set; }
		public string Creator { get; set; }
		public string Notes { get; set; }
		public string OriginalSource { get; set; }
		public string ApprovalStatus { get; set; }

		//TODO Pictures
	}
}
