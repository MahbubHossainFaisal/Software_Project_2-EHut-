﻿
using DAL.Models;
using DAL.Repository;
using DAL.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ShopReviewServices
    {
        ShopReviewRepo repo = new ShopReviewRepo();
        public List<ShopReview> GetAll()
        {
            var data = repo.GetAll();
            return data;
        }

        public ShopReview Get(int id)
        {
            var data = repo.Get(id);
            return data;
        }
        public List<ShopReview>  ReviewsByShopId(int shopId)
        {
            return repo.ReviewsByShopId(shopId);
        }
        public List<ShopReview> ReviewsByProductId(int pId)
        {
            return repo.ReviewsByProductId(pId);
        }

        public List<ShopReview> ReviewsByProductIdAndShopId(int shopId , int pId)
        {
            return repo.ReviewsByProductIdAndShopId(shopId,pId);
        }
        public ShopReview GetByPhone(string phone)
        {
            var data = repo.GetByPhone(phone);
            return data;
        }

        public List<DeliveredReviewViewModel> GetDeliveredProductsReview(int shopId)
        {
            ProductServices productServices=new ProductServices();
            List<DeliveredReviewViewModel> drvModels = new List<DeliveredReviewViewModel>();
            DeliveredReviewViewModel model;
            var data= repo.GetDeliveredProductsReview(shopId);
            foreach (var item in data)
            {
                model = new DeliveredReviewViewModel();
                model.ProductId = item.ProductId;
                model.Name=productServices.Get(item.ProductId).Name;
                model.Price = item.Price;
                model.Comment = item.Comment;
                model.Ratting=item.Ratting;
                drvModels.Add(model);
            }
            return drvModels;
        }

        public ShopReview Insert(ShopReview model)
        {
            var entity = model;
            bool done = repo.Insert(entity);

            if (done)
            {
                return model;
            }
            else
                return null;
        }


        public ShopReview Update(ShopReview model)
        {
            var entity = model;
            bool done = repo.Update(entity);
            if (done)
            {
                return model;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            bool done = repo.Delete(id);
            if (done)
            {
                return true;
            }
            else
                return false;
        }
    }
}
