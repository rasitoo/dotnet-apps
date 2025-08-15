﻿using P05_01_DI_Productos_TAPIADOR_rodrigo.Data.Entities;
using P05_01_DI_Productos_TAPIADOR_rodrigo.Data.Repositories;

namespace P05_01_DI_Productos_TAPIADOR_rodrigo.Services.Services;

internal class CategoryService : IRepositoryService<Category>
{
    internal CategoryRepository CategoryRepository { get; set; }
    public void Add(Category objeto)
    {
        CategoryRepository.Add(objeto);
    }

    public void Delete(int id)
    {
        CategoryRepository.Delete(id);
    }

    public Category Get(int id)
    {
        return CategoryRepository.Get(id);
    }

    public List<Category> GetAll()
    {
        return CategoryRepository.GetAll();
    }

    public void Update(int pos, Category objeto)
    {
        CategoryRepository.Update(pos, objeto);
    }
}
