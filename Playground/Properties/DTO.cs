﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;
using MinimalApis.Extensions.Metadata;

public abstract class ApiInput<TInput> : IProvideEndpointParameterMetadata where TInput : ApiInput<TInput>
{
    public static async ValueTask<TInput?> BindAsync(HttpContext context, ParameterInfo parameter)
    {
        // Just JSON deserialize the body to TInput but this could be augmented to retrieve values for specific
        // properties on TInput from different parts of the request based on the property attributes like
        // FromQuery, FromRoute, etc.
        var input = await context.Request.ReadFromJsonAsync<TInput>();

        return input;
    }

    public static IEnumerable<object> GetMetadata(ParameterInfo parameter, IServiceProvider services)
    {
        yield return new Mvc.ConsumesAttribute(typeof(TInput), "application/json");
    }
}

public class CreateTodoInput : ApiInput<CreateTodoInput>
{
    [Required, MinLength(2)]
    public string? Title { get; set; }
}

public class UpdateTodoInput : ApiInput<UpdateTodoInput>
{
    public int Id { get; set; }

    [Required, MinLength(2)]
    public string? Title { get; set; }

    public bool IsComplete { get; set; }
}

public class DeleteTodoInput : ApiInput<DeleteTodoInput>
{
    public int Id { get; set; }
}