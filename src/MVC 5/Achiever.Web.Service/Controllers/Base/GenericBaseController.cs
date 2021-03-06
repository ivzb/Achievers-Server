﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using Achiever.Data.Common.Models;
using Achiever.Services.Data.Interfaces;
using Achiever.Web.Infrastructure.Mapping;
using Achiever.Web.ViewModels.Abstract;

namespace Achiever.Web.Service.Controllers.Base
{
    public abstract class GenericBaseController<T, K> : BaseController
        where T : BaseModel<int>
        where K : BaseViewModel
    {
        protected IDefaultService<T> service;

        public GenericBaseController(IDefaultService<T> service)
        {
            this.service = service;
        }

        protected HttpResponseMessage Get(int id)
        {
            try
            {
                T val = service.Get(id);
                K result = Mapper.Map<T, K>(val);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                // todo: return 404
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        } 
        protected HttpResponseMessage GetValues(Expression<Func<T, bool>> predicate = null)
        {
            try
            {
                IQueryable<T> result = service.Get();
                if (predicate != null)
                {
                    result = result.Where(predicate);
                }
                
                IList<K> responseResult = result.To<K>().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, responseResult);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        protected HttpResponseMessage AddValue(K model)
        {
            try
            {
                if (model == null)
                {
                    this.ModelState.AddModelError("model", "The model is empty");
                }
                 
                if (!this.ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
                }
                
                T entity = Mapper.Map<T>(model);
                this.service.Add(entity);
                
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        protected HttpResponseMessage UpdateValue(K model)
        {
            try
            {
                if (model == null)
                {
                    this.ModelState.AddModelError("model", "The model is empty");
                }
                
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
                }
                
                T entity = this.service.Get(model.Id);
                this.Mapper.Map<K, T>(model, entity);
                this.service.Update(entity);
                
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}