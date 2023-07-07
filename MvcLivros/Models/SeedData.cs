using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcLivros.Data;
using System;
using System.Linq;

namespace MvcLivros.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcLivrosContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcLivrosContext>>()))
        {
            // Look for any books.
            if (context.Livro.Any())
            {
                return;   // DB has been seeded
            }
            context.Livro.AddRange(
                new Livro
                {
                    Titulo = "O Senhor dos Anéis: A Sociedade do Anel",
                    DataLancamento = DateTime.Parse("1954-7-29"),
                    Genero = "Fantasia",
                    Preco = 49.99M
                },
                new Livro
                {
                    Titulo = "Trono de Vidro Vol. I ",
                    DataLancamento = DateTime.Parse("2013-08-06"),
                    Genero = "Fantasia",
                    Preco = 52.60M
                },
                new Livro
                {
                    Titulo = "Caixa de Passaros",
                    DataLancamento = DateTime.Parse("2015-1-26"),
                    Genero = "Terror",
                    Preco = 49.90M
                },
                new Livro
                {
                    Titulo = "império do Vampiro",
                    DataLancamento = DateTime.Parse("2022-1-17"),
                    Genero = "Suspense",
                    Preco = 79.99M
                }
            );
            context.SaveChanges();
        }
    }
}