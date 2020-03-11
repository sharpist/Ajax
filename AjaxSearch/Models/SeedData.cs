using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace AjaxSearch.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices
                .GetRequiredService<AppDbContext>();

            context.Database.Migrate();

            if (!context.Books.Any()) {
                context.Books.AddRange(
                    new Book {
                        Name = "Анна Каренина",
                        Author = "Л. Толстой",
                        Price = 120.25M
                    },
                    new Book {
                        Name = "Крейцерова соната",
                        Author = "Л. Толстой",
                        Price = 90.75M
                    },
                    new Book {
                        Name = "Евгений Онегин",
                        Author = "А. Пушкин",
                        Price = 125.00M
                    },
                    new Book {
                        Name = "Пиковая дама",
                        Author = "А. Пушкин",
                        Price = 100.50M
                    },
                    new Book {
                        Name = "Капитанская дочка",
                        Author = "А. Пушкин",
                        Price = 90.75M
                    },
                    new Book {
                        Name = "Признания Мегрэ",
                        Author = "Ж. Сименон",
                        Price = 120.25M
                    },
                    new Book {
                        Name = "Красные огни",
                        Author = "Ж. Сименон",
                        Price = 90.75M
                    },
                    new Book {
                        Name = "Шпион, или Повесть о нейтральной территории",
                        Author = "Ф. Купер",
                        Price = 125.00M
                    },
                    new Book {
                        Name = "Открыватель следов",
                        Author = "Ф. Купер",
                        Price = 100.50M
                    },
                    new Book {
                        Name = "Последний из могикан",
                        Author = "Ф. Купер",
                        Price = 90.75M
                    },
                    new Book {
                        Name = "Над пропастью во ржи",
                        Author = "Д. Сэлинджер",
                        Price = 120.25M
                    },
                    new Book {
                        Name = "Опрокинутый лес",
                        Author = "Д. Сэлинджер",
                        Price = 90.75M
                    });

                context.SaveChanges();
            }
        }
    }
}
