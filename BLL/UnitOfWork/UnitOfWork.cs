﻿using BLL.Repository;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DataContext _context;
        private IGenericRepository<T> _entity;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public IGenericRepository<T> Entity 
        {
            get { return _entity ?? (_entity = new GenericRepository<T>(_context)); }
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
