﻿using FourPointImport.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FourPointImport.Services
{
    public class BillingDetailService : IGenericService<BillingDetail>

    {
        protected ApiDbContext _db;

        public BillingDetailService([NotNull] ApiDbContext db)
        {
            _db = db;
        }
        public virtual async Task<BillingDetail> CreateAsync(BillingDetail entity)
        {
            await _db.Set<BillingDetail>().AddAsync(entity);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            return entity;
        }
        public virtual async Task DeleteAsync(int id)
        {
            //see if the record exists
            var entity = await ReadAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("Unable to find record with id = " + id.ToString());
            }
            entity.Archive = true;
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        public virtual async Task<List<BillingDetail>> ReadAllAsync(bool tracking = true)
        {
            IQueryable<BillingDetail> query = _db.Set<BillingDetail>();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }
        public virtual async Task<BillingDetail> ReadAsync(int id, bool Tracking = true)
        {
            var query = _db.Set<BillingDetail>().AsQueryable();
            if (!Tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => entity.id == id);
        }
        public virtual async Task<BillingDetail> ReadAsyncB(string Agnt, bool Tracking = true)
        {
            var query = _db.Set<BillingDetail>().AsQueryable();
            if (!Tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => entity.BdAgnt == Agnt);
        }

        public virtual async Task<BillingDetail> UpdateAsync(int id, BillingDetail updateEntity)
        {
            //check that the record exists
            var entity = await ReadAsync(id);
            if (entity == null)
                throw new Exception("Unable to find record with id " + id.ToString());
            //update changes if any of the values have been modified
            _db.Entry(entity).CurrentValues.SetValues(updateEntity);
            _db.Entry(entity).State = EntityState.Modified;
            if (_db.Entry(entity).Properties.Any(property => property.IsModified))
            {
                await _db.SaveChangesAsync();
            }
            return entity;
        }
    

    }
}